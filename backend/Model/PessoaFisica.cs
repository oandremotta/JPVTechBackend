using System;
using System.ComponentModel.DataAnnotations;

namespace backend.Model
{
    public class PessoaFisica
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        [StringLength(160, ErrorMessage = "O nome completo deve ter no máximo {1} caracteres.")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataDeNascimento { get; set; }

        [Required(ErrorMessage = "O valor da renda é obrigatório.")]
        [Range(0, Double.MaxValue, ErrorMessage = "O valor da renda deve ser um número positivo.")]
        public double ValorDaRenda { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter 11 caracteres.")]
        public string Cpf { get; set; }
    }
}
