using Domain.Entities.App;
using Domain.Entities.Keys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }

        public DbSet<Note> NotesEntity { get; set; }

        public DbSet<ApiKey> ApiKeysEntity { get; set; }
    }
}
