using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    public class Cargo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "A entrada deve possuir 03 a 100 caracteres.")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
    }
}
