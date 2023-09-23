﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteTecnico.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "É necessário informar o nome do usuário.")]
        [MaxLength(20)]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "É necessário informar um sobrenome.")]
        [MaxLength(100)]
        public string? Sobrenome { get; set; }

        [Required(ErrorMessage = "É necessário informar um e-mail.")]
        [MaxLength(50)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "É necessário informar uma data de nascimento.")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "É necessário informar uma escolaridade.")]
        public int IdEscolaridade { get; set; }

        public Escolaridade? Escolaridade { get; set; }
    }
}
