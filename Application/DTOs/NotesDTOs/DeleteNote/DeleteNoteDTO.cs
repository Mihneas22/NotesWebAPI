﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.NotesDTOs.DeleteNote
{
    public class DeleteNoteDTO
    {
        public string ApiKey { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
    }
}
