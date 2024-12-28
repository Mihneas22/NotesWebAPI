using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.NotesDTOs.GetNotesByTags
{
    public class GetNotesByTagsDTO
    {
        public string ApiKey { get; set; } = string.Empty;

        public List<string> Tags { get; set; } = new List<string>();
    }
}
