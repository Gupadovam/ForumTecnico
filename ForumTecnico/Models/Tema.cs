using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ForumTecnico.Models
{
    public class Tema
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "A descrição do tema é obrigatória.")]
        [DisplayName("Descrição do Tema")]
        public string? Tem_descricao { get; set; }

        [DisplayName("Data de Criação")]
        public DateTime Tem_momento { get; set; }

        [Required(ErrorMessage = "O login do usuário é obrigatório.")]
        [DisplayName("Autor")]
        public string? Usu_login { get; set; }
    }
}