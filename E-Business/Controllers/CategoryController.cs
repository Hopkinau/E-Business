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
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name","The DisplayOrder cannot same as name");
            }
           
            if (ModelState.IsValid)
             //if modelstate in the Model.category is valid, the data will save to the database
             //the validation will check the maxlength etch
            {
                _db.Categories.Add(obj);
                //track of what data is has to add
                _db.SaveChanges();
                //go to the database create the category}
                TempData["success"] = "category create successfully";
                return RedirectToAction("Index");
                //show on the category view page
            }
            return View();


        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //1.check id is whether correct number 
            Category categoryFromDb=_db.Categories.Find(id);
            //2.check whether id is inside of databse, using find method

            //3 simllar method 
            //Category categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //Category categoryFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault;
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
       
        [HttpPost]
        public IActionResult Edit(Category obj)
        {

            if (ModelState.IsValid)
            
            {
                _db.Categories.Update(obj);
                
                _db.SaveChanges();
                TempData["success"] = "category edit successfully";

                return RedirectToAction("Index");
                
            }
            return View();


        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //1.check id is whether correct number 
            Category categoryFromDb = _db.Categories.Find(id);
            //2.check whether id is inside of databse, using find method

           
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            
                _db.Categories.Remove(obj);

                _db.SaveChanges();
            TempData["success"] = "category delete successfully";

            return RedirectToAction("Index");

            
     


        }
    }
}
