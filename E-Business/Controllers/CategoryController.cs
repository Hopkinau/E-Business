using E_Business.Data;
using E_Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Business.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        //2。这个是global 级别的varibale,叫做_db, 这个_db等于db就是数据库
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        //1.先创建一个construte mode,指定数据库文件ApplicationDbContext叫做db,
        //然后让全局的_db ===constructure的db
        public IActionResult Index()
        {
            List<Category> objCategoryList =_db.Categories.ToList();
            //数据都存在objCategoryList这个List里面
            //3.引用_db的数据库数据
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        //这个新的action是create category button的新页面
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            _db.Categories.Add(obj);
            //track of what data is has to add
            _db.SaveChanges();
            //go to the database create the category
            return RedirectToAction("Index");
        }

    }
}
