using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Keys
{
    public class ApiKey
    {
        [Key]
        public int Id { get; set; }

        public string? Key { get; set; }

        public DateTime? AddedTime {  get; set; }
    }
}
