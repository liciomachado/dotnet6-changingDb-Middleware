using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Testes.changeDB.pg.Model
{
    [Table("usuarios", Schema = "Application")]
    public class Usuario
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("nome")]
        public string Username { get; set; }
        [Required]
        [Column("email")]
        public string Email { get; set; }
        [Required]
        [Column("dbempresa")]
        public string DbCompany { get; set; }
    }
}
