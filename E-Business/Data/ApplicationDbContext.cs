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
    }
}
