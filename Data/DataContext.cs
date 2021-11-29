using Microsoft.EntityFrameworkCore;
using asp_net_course_udemy.Models;
namespace dot_net_role_playing_game.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Character> Characters { get; set; }
    }
}