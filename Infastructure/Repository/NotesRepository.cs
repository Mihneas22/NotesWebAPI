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
using Application.DTOs.NotesDTOs.DeleteNote;
using Application.DTOs.NotesDTOs.ModifyNote;

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

        public async Task<DeleteNoteResponse> DeleteNoteAsync(DeleteNoteDTO deleteNoteDTO)
        {
            var apikey = await dbContext.ApiKeysEntity.FirstOrDefaultAsync(u => u.Key == deleteNoteDTO.ApiKey);

            if (apikey == null)
                return new DeleteNoteResponse(false, "Invalid API key.");

            var note = await dbContext.NotesEntity.FirstOrDefaultAsync(u => u.Name == deleteNoteDTO.Name && u.MainKey == deleteNoteDTO.ApiKey);
            if(note == null)
                return new DeleteNoteResponse(false, "Note not found...");

            dbContext.NotesEntity.Remove(note);
            await dbContext.SaveChangesAsync();

            return new DeleteNoteResponse(true, "Note deleted");
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

        public async Task<ModifyNoteResponse> ModifyNotesAsync(ModifyNoteDTO modifyNoteDTO)
        {
            var apikey = await dbContext.ApiKeysEntity.FirstOrDefaultAsync(u => u.Key == modifyNoteDTO.ApiKey);

            if (apikey == null)
                return new ModifyNoteResponse(false, "Invalid API key.");

            var note = await dbContext.NotesEntity.FirstOrDefaultAsync(u => u.Name == modifyNoteDTO.OriginalName && u.MainKey == modifyNoteDTO.ApiKey);
            if (note == null)
                return new ModifyNoteResponse(false, "Note not found...");

            note.Name = modifyNoteDTO.Name;
            note.Text = modifyNoteDTO.Text;
            note.Progress = modifyNoteDTO.Progress;
            note.Tags = modifyNoteDTO.Tags;
            note.SharedKeys = modifyNoteDTO.SharedKeys;
            note.AddedDateTime = DateTime.Now;

            await dbContext.SaveChangesAsync();

            return new ModifyNoteResponse(true, "Succesfull Update");
        }
    }
}
