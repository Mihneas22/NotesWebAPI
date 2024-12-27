using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.NotesDTOs.DeleteNote
{
    public record DeleteNoteResponse(bool Flag, string message = null!);
}
