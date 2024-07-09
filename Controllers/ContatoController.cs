
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_ASPNET.Context;
using MVC_ASPNET.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVC_ASPNET.Controllers
{
    public class ContatoController : Controller
    {
        private readonly AgendaContext _context;

        public ContatoController(AgendaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var contatos = _context.Contatos.ToList(); //Pegando todos os meus contatos e colocando em uma lista
            return View(contatos); //passando a lista para a view
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Contato contato) // importar MVC_ASPNET.Models;
        {
            if (ModelState.IsValid) //verificar se os dados são validos, por ex: se o campo nome for obrigatório e não tiver sido preenchido, vai cair no else ao invés do if, pq não será valido
            {
                _context.Contatos.Add(contato);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index)); //redirecionamos para o Index, no caso a nossa tela de listagem
            }
            return View(contato);
        }

        public IActionResult Editar(int id)
        {
            var contato = _context.Contatos.Find(id);

            if (contato == null)
              return NotFound();

            return View(contato);
        }

        [HttpPost]
        public IActionResult Editar(Contato contato) // importar MVC_ASPNET.Models;
        {
            var contatoBanco = _context.Contatos.Find(contato.Id);

            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;

            _context.Contatos.Update(contatoBanco); 
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int id)
        {
            var contato = _context.Contatos.Find(id);

            if (contato == null)
              return RedirectToAction(nameof(Index));

            return View(contato);
        }

        public IActionResult Deletar(int id)
        {
            var contato = _context.Contatos.Find(id);

            if (contato == null)
              return RedirectToAction(nameof(Index));

            return View(contato);
        }

        [HttpPost]
        public IActionResult Deletar(Contato contato)
        {
            var contatoBanco = _context.Contatos.Find(contato.Id);

            _context.Contatos.Remove(contatoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
// temos dois criar, o primeiro é do tipo get, se n há nenhum [http] é
// pq já é get, é opcional colocar as chaves quando é get
// temos dois criar pois quando acessamos a pagina pela primeira vez é carregado o primeiro Criar, que aponta para a View
// com os campos vazios, a partir do momento que eu clico em "Criar" na view eu mando as informações para a controller, onde cairá no Criar POST
// onde pego essas informações e salvo no Banco de dados