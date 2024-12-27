using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.NotesDTOs.ModifyNote
{
    public record ModifyNoteResponse(bool Flag, string message = null!);
}
