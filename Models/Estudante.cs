using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroEstudanteApi.Models
{
    public class Estudante
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome do estudante é obrigatorio!")]
        public string? Nome { get; set; }

    }
}