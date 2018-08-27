using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Funcionario
    {
        [Key]
        public int Id { get; set; }

        public int IdUnidade { get; set; }

        public int IdCargo { get; set; }

        [DisplayName("Chefe Imediato")]
        public Funcionario ChefeImediato { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Cargo")]
        public Cargo Cargo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Cpf")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("RG")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Matrícula")]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [Range(1000, 100000, ErrorMessage = "A salário deve ser maior que mil e menor que 100 mil.")]
        [DisplayName("Salário")]
        public double Salario { get; set; }

        [DisplayName("Ativo")]
        public bool IsAtivo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Sexo")]
        public char Sexo { get; set; }

        [DisplayName("Unidade")]
        public Unidade Unidade { get; set; }

        /*public Funcionario(int id, Funcionario chefeImediato, Cargo cargo, string nome, string cpf, string rg, string matricula, double salario, bool isAtivo, char sexo, Unidade unidade)
        {
            Id = id;
            ChefeImediato = chefeImediato;
            Cargo = cargo;
            Nome = nome;
            Cpf = cpf;
            Rg = rg;
            Matricula = matricula;
            Salario = salario;
            IsAtivo = isAtivo;
            Sexo = sexo;
            Unidade = unidade;
        }*/
    }
}
