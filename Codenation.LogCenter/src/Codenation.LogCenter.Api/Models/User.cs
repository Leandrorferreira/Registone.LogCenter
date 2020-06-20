using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.LogCenter.Api.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]       
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(30)]
        public string Role { get; set; }

        public virtual ICollection<Log> Logs { get; set; }
    }
}
