using Application.DTOs.ApiKeyDTOs.AddApiKey;
using Application.Repository;
using Domain.Entities.Keys;
using Infastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Repository
{
    public class ApiKeyRepository : IApiKey
    {
        private ApplicationDbContext dbContext;

        public ApiKeyRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<AddApiKeyResponse> AddApiKeyAsync(AddApiKeyDTO addApiKeyDTO)
        {
            if (addApiKeyDTO == null)
                return new AddApiKeyResponse(false, "Invalid API Key");

            dbContext.Add(new ApiKey
            {
                Key = addApiKeyDTO.Key,
                AddedTime = DateTime.Now,
            });
            await dbContext.SaveChangesAsync();

            return new AddApiKeyResponse(true, "Succesfull Add!");
        }
    }
}
