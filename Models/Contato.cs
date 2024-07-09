using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_ASPNET.Models
{
    public class Contato
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório.")]
        [RegularExpression(@"^[a-zA-Z\s\^´~¨]*$", ErrorMessage = "O campo deve conter apenas letras, espaços e os caracteres especiais ^´~¨.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório.")]
        [RegularExpression(@"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$", ErrorMessage = "O campo deve conter um número de telefone válido.")]
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
    }
}