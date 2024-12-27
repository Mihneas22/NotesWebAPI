using Domain.Entities.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.NotesDTOs.GetNotesByApiKey
{
    public record GetNotesByApiKeyResponse(bool Flag, string message = null!, List<Note> notes = null!);
}
