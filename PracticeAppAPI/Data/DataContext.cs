using Microsoft.EntityFrameworkCore;
using PracticeAppAPI.Models;

namespace PracticeAppAPI.Data
{
    public class DataContext: DbContext
    {
        /*
        EF commands:
        add migration:              dotnet ef migrations add <migration_name>
        remove last migration:      dotnet ef migrations remove 
        update table:               dotnet ef database update
        revert update:              dotnet ef database update <target_migration>
        */
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }

        public DbSet<Value> Values {get; set;}
        public DbSet<User> Users {get;set;}
    }
}