using Domain.Entities.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.NotesDTOs.GetNotesByTags
{
    public record GetNotesByTagsResponse(bool Flag, string message = null!,List<Note> notes = null!);
}
