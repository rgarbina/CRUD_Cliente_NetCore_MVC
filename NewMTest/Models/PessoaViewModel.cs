using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewMTest.Models
{
    public class PessoaViewModel
    {
        public PessoaViewModel()
        {
            Ativado = true;
        }

        public long PessoaId { get; set; }
        public bool Ativado { get; set; }

        [Required(ErrorMessage = "O campo Nome é necessario para o cadastro!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Data Nascimento é necessario para o cadastro!")]
        [DataType(DataType.Date)]
        [Display(Name = "Data Nascimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo Endereço é necessario para o cadastro!")]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [MaxLength(300)]
        [StringLength(300, ErrorMessage = "Observação não pode conter mais do que 300 caracteres.")]
        [Display(Name = "Observação")]
        public string Observacao { get; set; }

        [Required(ErrorMessage = "O campo Celular é necessario para o cadastro!")]
        [Phone(ErrorMessage = "Digite Telefone valido!")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "O campo E-Mail é necessario para o cadastro!")]
        [Display(Name = "E-Mail")]
        [EmailAddress(ErrorMessage = "Digite E-Mail valido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo CPF é necessario para o cadastro!")]
        [Display(Name = "CPF")]
        [DisplayFormat(DataFormatString = "{0:###.###.###-##}")]
        [Remote(action: "VerificaCPF", controller: "Pessoas")]
        public string Cpf { get; set; }
    }
}
