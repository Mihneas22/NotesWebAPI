using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.App
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        public string? MainKey { get; set; }

        public string? Name { get; set; }

        public string? Text { get; set; }

        public float? Progress { get; set; }

        public List<string>? Tags { get; set; }

        public List<string>? SharedKeys { get; set; }

        public DateTime FinalTerm { get; set; }

        public DateTime AddedDateTime { get; set; }
    }
}
