using Application.DTOs.ApiKeyDTOs.AddApiKey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public interface IApiKey
    {
        Task<AddApiKeyResponse> AddApiKeyAsync(AddApiKeyDTO addApiKeyDTO);
    }
}
