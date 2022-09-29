//using API.Repositories.Data;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class GolonganController : Controller
//    {
//        // GET: GolonganController
//        public ActionResult Index()
//        {
//            return View();
//        }

//        // GET: GolonganController/Details/5
//        public ActionResult Details(int id)
//        {
//            var data = GolonganRepository.Get();
//            return View();
//        }

//        // GET: GolonganController/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: GolonganController/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: GolonganController/Edit/5
//        public ActionResult Edit(int id)
//        {
//            return View();
//        }

//        // POST: GolonganController/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(int id, IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: GolonganController/Delete/5
//        public ActionResult Delete(int id)
//        {
//            return View();
//        }

//        // POST: GolonganController/Delete/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Delete(int id, IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }
//    }
//}
