using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Registone.LogCenter.Domain.Models
{
    [Table("Log")]
    public class Log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Level { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public bool Filed { get; set; }

        [Required]
        [StringLength(200)]
        public string Details { get; set; }

        [Required]
        [StringLength(50)]
        public string Origin { get; set; }

        [Required]
        [Column("UserId")]
        public int UserId { get; set; }

        public DateTime CreatedAt { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
