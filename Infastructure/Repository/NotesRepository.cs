using Application.DTOs.NotesDTOs.AddNote;
using Application.DTOs.NotesDTOs.GetNotesByApiKey;
using Application.Repository;
using Infastructure.Context;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.App;

namespace Infastructure.Repository
{
    public class NotesRepository : INotes
    {
        private ApplicationDbContext dbContext;

        public NotesRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<AddNoteResponse> AddNoteAsync(AddNoteDTO addNoteDTO)
        {
            var apikey = await dbContext.ApiKeysEntity.FirstOrDefaultAsync(u => u.Key == addNoteDTO.ApiKey);

            if(apikey == null)
                return new AddNoteResponse(false, "Invalid API key.");

            if(addNoteDTO == null)
                return new AddNoteResponse(false, "Invalid data entered.");

            dbContext.NotesEntity.Add(new Note
            {
                MainKey = addNoteDTO.ApiKey,
                Name = addNoteDTO.Name,
                Text = addNoteDTO.Text,
                Progress = 0f,
                Tags = addNoteDTO.Tags,
                SharedKeys = addNoteDTO.SharedKeys,
                FinalTerm = DateTime.Now,
                AddedDateTime = DateTime.Now
            });
            await dbContext.SaveChangesAsync();

            return new AddNoteResponse(true, "Added Note");
        }

        public async Task<GetNotesByApiKeyResponse> GetNotesByApiKeyAsync(GetNotesByApiKeyDTO getNotesByApiKeyDTO)
        {
            var apikey = await dbContext.ApiKeysEntity.FirstOrDefaultAsync(u => u.Key == getNotesByApiKeyDTO.ApiKey);

            if (apikey == null)
                return new GetNotesByApiKeyResponse(false, "Invalid API key.");

            var noteList = await dbContext.NotesEntity.Where(u => u.MainKey == getNotesByApiKeyDTO.ApiKey).ToListAsync();

            if (noteList == null)
                return new GetNotesByApiKeyResponse(false, "Notes not found...");
            else
                return new GetNotesByApiKeyResponse(true, "Notes found!", noteList);
        }
    }
}
