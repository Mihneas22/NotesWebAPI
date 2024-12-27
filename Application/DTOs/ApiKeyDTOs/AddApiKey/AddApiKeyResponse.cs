using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ApiKeyDTOs.AddApiKey
{
    public record AddApiKeyResponse(bool Flag, string message = null!);
}
