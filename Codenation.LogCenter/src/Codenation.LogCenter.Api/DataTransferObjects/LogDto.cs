using System;

namespace Codenation.LogCenter.Api.DataTransferObjects
{
    public class LogDto
    {
        public int Id { get; set; }

        public string Level { get; set; }

        public string Title { get; set; }

        public string Details { get; set; }

        public string Origin { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UserEmail { get; set; }
    }
}
