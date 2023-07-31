using E_Business.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Business.Data
{
    public class ApplicationDbContext : DbContext
    //DbContext是Microsoft.EntityFrameworkCore里面打包好的功能,类似于react router,
    //DbContext是用来链接数据库
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) :base(options)
        //简写ctor, constructor
        //ApplicationDbContext是constructor
        {

        }
        public DbSet <Category> Categories { get; set; }
        //Dbset是用来查看Models里面的Category文件内的数据库schema并且移至到本地数据库
        //需要在Package Manager Consoles 首先输入:add-migration AddcategoryTableToDb
        //再输入：update-database

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Comendy", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Love", DisplayOrder = 3 }
                );
        }
    }
}
