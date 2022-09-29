using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MVCApp.Context;
using MVCApp.Models;
using System.Data;

namespace MVCApp.Controllers
{
    public class AdminController : Controller
    {
        MyContext myContext;
        public AdminController(MyContext myContext)
        {
            this.myContext = myContext;
        }
        // GET: AdminControllers
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdminControllers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminControllers/Create
        public ActionResult Create()
        {
            return View(new Admin());
        }

       
        [HttpPost]
        //// POST : /Create/Pegawai
        public IActionResult Create(Admin admin)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-3EQ7S2P;Initial Catalog=SuratPerjalananDinass;Integrated Security=True");

            SqlCommand com = new SqlCommand("AdAmin", sqlConnection);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@username", admin.username);
            string pass = admin.password;
            pass = Hashing.HashPasswor(admin.password);
            com.Parameters.AddWithValue("@password", pass);

            sqlConnection.Open();
            int i = com.ExecuteNonQuery();
            sqlConnection.Close();
            if (i >= 1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return ViewBag.Message = "Pegawai Gagal Ditambah"; ;
            }
        }
            //if (ModelState.IsValid)
            //{
            //    myContext.Admin.Add(admin);
            //    admin.password = Hashing.HashPasswor(admin.password);
            //    var result = myContext.SaveChanges();
            //    if (result > 0)
            //        return RedirectToAction("Index");
            //}

        // GET: AdminControllers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminControllers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminControllers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminControllers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
