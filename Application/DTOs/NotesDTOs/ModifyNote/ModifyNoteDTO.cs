using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.NotesDTOs.ModifyNote
{
    public class ModifyNoteDTO
    {
        public string ApiKey { get; set; } = string.Empty;

        public string OriginalName { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Text { get; set; } = string.Empty;

        public float Progress { get; set; } = 0f;

        public List<string> Tags { get; set; } = new List<string>();

        public List<string> SharedKeys { get; set; } = new List<string>();
    }
}
