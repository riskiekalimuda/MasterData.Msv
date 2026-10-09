using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace MasterData.Msv.Models
{
    public partial class MasterDataMsvDbContext:DbContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
           modelBuilder.AddTransactionalOutboxEntities();
        }
    }
}