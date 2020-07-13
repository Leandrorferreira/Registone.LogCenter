using System.ComponentModel.DataAnnotations;

namespace Registone.LogCenter.Domain.DataTransferObjects
{
    public class LogRegisterDto
    {
        [Required(ErrorMessage = "Level is required.")]
        public string Level { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Details is required.")]
        public string Details { get; set; }

        [Required(ErrorMessage = "Origin is required.")]
        public string Origin { get; set; }

        [Required(ErrorMessage = "Level is required.")]
        public string UserEmail { get; set; }
    }
}
