using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    public class Unidade
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Unidade Pai")]
        public Unidade UnidadePai {get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Descrição")]
        public string Descricao {get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Localidade")]
        public string Localidade {get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Tipo de Unidade")]
        public TipoUnidade TipoUnidade {get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Funcionarios")]
        public List<Funcionario> Funcionarios  {get; set; }

        public Unidade(int id, Unidade unidadePai, string descricao, string localidade, TipoUnidade tipoUnidade, List<Funcionario> funcionarios)
        {
            Id = id;
            UnidadePai = unidadePai;
            Descricao = descricao;
            Localidade = localidade;
            TipoUnidade = tipoUnidade;
            Funcionarios = funcionarios;
        }
    }
}
