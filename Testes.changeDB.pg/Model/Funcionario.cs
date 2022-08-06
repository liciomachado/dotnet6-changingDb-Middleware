using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Testes.changeDB.pg
{
    [Table("funcionarios", Schema = "loja")]
    public class Funcionario
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("nome")]
        public string Nome { get; set; }
        [Required]
        [Column("sobrenome")]
        public string Sobrenome { get; set; }
    }

}
