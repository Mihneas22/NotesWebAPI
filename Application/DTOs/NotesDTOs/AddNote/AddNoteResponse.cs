using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.NotesDTOs.AddNote
{
    public record AddNoteResponse(bool Flag, string message = null!);
}
