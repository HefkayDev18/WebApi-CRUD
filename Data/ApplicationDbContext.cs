using EMP_WebApiCRUD.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EMP_WebApiCRUD.Data
{
    public class ApplicationDbContext : DbContext
    {
        //Would have specified type of DbContext if i had multiple DbContext
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
