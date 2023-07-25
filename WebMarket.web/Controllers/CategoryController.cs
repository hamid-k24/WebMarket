using Microsoft.AspNetCore.Mvc;
using WebMarket.DataAccess.Repository;
using WebMarket.DataAccess.Repository.IRepository;
using WebMarket.Models;

namespace WebMarket.web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> CategoryList = _unitOfWork.Category.GetAll();// az deta taype var ham mishod estefade kard ama bekhatere amniyat va ... az IEnumerable estefade kardim
            return View(CategoryList);
        }

        // get 
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        //post
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())

                ModelState.AddModelError("Name", " مقدار فیلد ترتیب نمایش نباید با مقدار فیلد نام برابر باشد"); //Name  یعنی زیر این فیلد بنویسد

            {

            }
            if (ModelState.IsValid) {
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = " دسته جدید با موفقیت ایجاد شد";
                return RedirectToAction("Index"); // برای قشنگی کار و هدایت به صفحه لیست دسته ها 
            }
            return View(obj);     
        }
        //Get
        public IActionResult Edit(int? id)
        {
            
            if (id == null || id == 0)
            {
                return NotFound();
            }
           // var categoryFromDb = _db.Categories.Find(id); // برای پیدا کردن ایدی مشخص از دیتا بیس
            var categoryFromFirst = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);// هر سه روش جواب میدهد ولی روش اول ساده تر است
            //var categoryFromSinglet = _db.Categories.SingleOrDefault(u => u.Id == id);
            if (categoryFromFirst == null)
            {
                return NotFound();
            }
            return View(categoryFromFirst);
        }
        //post
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())

                ModelState.AddModelError("Name", " مقدار فیلد ترتیب نمایش نباید با مقدار فیلد نام برابر باشد"); //Name  یعنی زیر این فیلد بنویسد

            {

            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = " دسته با موفقیت ویرایش شد";
                return RedirectToAction("Index"); // برای قشنگی کار و هدایت به صفحه لیست دسته ها 
            }
            return View(obj);
        }

        //Get
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var categoryFromDb = _db.Categories.Find(id); // برای پیدا کردن ایدی مشخص از دیتا بیس
            var categoryFromFirst = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);// هر سه روش جواب میدهد ولی روش اول ساده تر است
            //var categoryFromSinglet = _db.Categories.SingleOrDefault(u => u.Id == id);
            if (categoryFromFirst == null)
            {
                return NotFound();
            }
            return View(categoryFromFirst);
        }
        //post
        [HttpPost]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = " دسته با موفقیت حذف شد";
            return RedirectToAction("Index"); // برای قشنگی کار و هدایت به صفحه لیست دسته ها 
            
            
        }
    }
}
