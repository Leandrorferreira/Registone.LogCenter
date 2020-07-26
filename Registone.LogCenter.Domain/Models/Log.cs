using System;

namespace Registone.LogCenter.Domain.Models
{
    public class Log
    {       
        public int Id { get; set; }
        public string Level { get; set; }
        public string Title { get; set; }
        public bool Filed { get; set; }
        public string Details { get; set; }
        public string Origin { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual User User { get; set; }
    }
}
