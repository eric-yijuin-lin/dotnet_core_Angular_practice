using Microsoft.EntityFrameworkCore;
using PracticeAppAPI.Models;

namespace PracticeAppAPI.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }

        public DbSet<Value> Values {get; set;}
    }
}