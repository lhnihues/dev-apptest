using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace DevAppTest.Models
{
    [Table("usuario")]
    public class Usuario
    {
        [Display(Name ="ID")]
        [Column("id")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Column("nome")]
        public string? Nome { get; set; }

        [Display(Name = "Sexo")]
        [Column("sexo")]
        public string? Sexo { get; set; }

        [Display(Name = "Data de Cadastro")]
        [Column("data_cadastro")]
        public DateTime Data_Cadastro { get; set; }

    }
}
