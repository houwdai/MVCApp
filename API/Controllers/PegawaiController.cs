using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Context;
using API.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using API.Repositories.Data;
using Microsoft.AspNetCore.Http;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PegawaiController : ControllerBase
    {
        PegawaiRepository pegawaiRepository;
        MyContext myContext;

        //public PegawaiController(PegawaiRepository pegawaiRepository)
        //{
        //    this.pegawaiRepository = pegawaiRepository;
        //}
        public PegawaiController(MyContext myContext)
        {
            this.myContext = myContext;
        }

        //GET ALL DATA
        [HttpGet]
        public IActionResult Index()
        {
            var data = myContext.Pegawaii.ToList();
            if (data.Count == 0)
                return Ok(new { message = "Sukses mengambil data", StatusCode = 200, data = "null" });
            return Ok(new { message = "Sukses mengambil data", StatusCode = 200, data = data });

            //return View(data);
        }

        //GET ALL DATA
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    var data = pegawaiRepository.Get();
        //    if (data.Count == 0) 
        //        return Ok(new {message = "Sukses mengambil data", StatusCode = 200, data = "null"});
        //    return Ok(new { message = "Sukses mengambil data", StatusCode = 200, data = data });

        //    //return View(data);
        //}
        //GET DATA BY ID
        //GET
        [HttpGet("Details/{id:int}")]
        public IActionResult Details(int id)
        {
            //Employee employee = myContext.Employees.Find(id);
            var employee = pegawaiRepository.GetById(id);
            if (employee == null)
                return Ok(new { message = "Sukses mengambil data", StatusCode = 200, data = "null" });
            return Ok(new { message = "Sukses mengambil data", StatusCode = 200, data = employee });

            //return View(employee);
        }
       
        [HttpPost]
        //// POST : /Create/Pegawai
        public IActionResult Create(Pegawai pegawai)
        {
            var result = pegawaiRepository.Post(pegawai);
            if (result >0 )
                    //return RedirectToAction("Index");
                return Ok(new { message = "Sukses menambahkan data data", StatusCode = 200});
            return BadRequest(new { message = "Gagal menambahkan data", StatusCode = 200});
            //return View();
        }

        ////EDIT GET
        //[HttpGet("Edit/{id:int}")]
        //public IActionResult Edit(int id)
        //{
        //    var reader = myContext.Pegawaii.Find(id);
        //    ViewData["idPegawai"] = reader.idPegawai;
        //    ViewData["namePegawai"] = reader.namePegawai;
        //    ViewData["nipPegawai"] = reader.nipPegawai;
        //    ViewData["jabatanPegawai"] = reader.jabatanPegawai;
        //    ViewData["golonganPegawai"] = reader.IdGolongan;
        //    return View();
        //}

        //UPDATE PEGAWAI
        // POST: Student/Edit/5
        [HttpPut, ActionName("Edit")]

        public IActionResult Edit(Pegawai pegawai)
        {
            var data = pegawaiRepository.Put(pegawai);
            if (data > 0)
                return Ok(new { message = "Berhasil mengupdate data data", statusCode = 200 });
            return BadRequest(new { messagae = "Gagal mengambil data", statusCode = 400 });

            //return RedirectToAction("Index");
        }



        [HttpGet("Delete/{id:int}")]

        public IActionResult Delete(int id)
        {
            var pegawai = pegawaiRepository.Delete(id);
            if (pegawai > 0 )
                return Ok(new { message = "Sukses menghapus data", StatusCode = 200 });
            return BadRequest(new { message = "gagal Mengambil data", StatusCode = 400 });
            //return RedirectToAction("Index");
        }



        //public string connectionString = "Data Source=DESKTOP-3EQ7S2P;Initial Catalog=SuratPerjalananDinass;Integrated Security=True";

        //[HttpGet]
        //public IActionResult Index()
        //{
        //    SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-3EQ7S2P;Initial Catalog=SuratPerjalananDinass;Integrated Security=True");
        //    List<Pegawai> pegawailist = new List<Pegawai>();
        //    SqlCommand cmd = sqlConnection.CreateCommand();
        //    cmd.CommandText = "Select * from pegawai";
        //    try
        //    {
        //        sqlConnection.Open();
        //        using (SqlDataReader reader = cmd.ExecuteReader())
        //        {
        //            if (reader.Read())
        //            {

        //                while (reader.Read())
        //                {
        //                    Pegawai pegawai = new Pegawai();

        //                    pegawai.idPegawai = Convert.ToInt32(reader[0]);
        //                    pegawai.namePegawai = reader[1].ToString();
        //                    pegawai.nipPegawai = Convert.ToInt32(reader[2]);
        //                    pegawai.jabatanPegawai = reader[3].ToString();
        //                    pegawai.golonganPegawai = reader[4].ToString();
        //                    pegawailist.Add(pegawai);
        //                }
        //            }
        //            else
        //            {
        //                Console.WriteLine("No data Found");
        //            }
        //            reader.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.InnerException);
        //    }

        //    return View(pegawailist);
        //}

        //public IActionResult Create()
        //{
        //    return View(new Pegawai());
        //}

        //[HttpPost]
        //// POST : /Create/Pegawai
        //public IActionResult Create(Pegawai pegawaii)
        //{
        //    SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-3EQ7S2P;Initial Catalog=SuratPerjalananDinass;Integrated Security=True");

        //    SqlCommand com = new SqlCommand("AddPegawai", sqlConnection);
        //    com.CommandType = CommandType.StoredProcedure;
        //    com.Parameters.AddWithValue("@namaPegawai", pegawaii.namePegawai);
        //    com.Parameters.AddWithValue("@nipPegawai", pegawaii.nipPegawai);
        //    com.Parameters.AddWithValue("@jabatanPegawai", pegawaii.jabatanPegawai);
        //    com.Parameters.AddWithValue("@golonganPegawai", pegawaii.golonganPegawai);

        //    sqlConnection.Open();
        //    int i = com.ExecuteNonQuery();
        //    sqlConnection.Close();
        //    if (i >= 1)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return ViewBag.Message = "Pegawai Gagal Ditambah"; ;
        //    }
        //}


        //// EDIT GET
        //[HttpGet("Edit/{id:int}")]
        //public IActionResult Edit(int id)
        //{
        //    SqlParameter sqlParameterId = new SqlParameter();
        //    sqlParameterId.ParameterName = "@idPegawai";
        //    sqlParameterId.Value = id;
        //    string query = "select * from pegawai where idPegawai = @idPegawai";

        //    SqlConnection connection = new SqlConnection(connectionString);
        //    SqlCommand sqlCommand = new SqlCommand(query, connection);
        //    sqlCommand.Parameters.Add(sqlParameterId);

        //    try
        //    {
        //        connection.Open();
        //        using (SqlDataReader reader = sqlCommand.ExecuteReader())
        //        {
        //            if (reader.HasRows)
        //            {
        //                while (reader.Read())
        //                {

        //                    ViewData["idPegawai"] = reader[0];
        //                    ViewData["namePegawai"] = reader[1];
        //                    ViewData["nipPegawai"] = reader[2];
        //                    ViewData["jabatanPegawai"] = reader[3];
        //                    ViewData["golonganPegawai"] = reader[4];
        //                }
        //            }
        //            else
        //            {
        //                Console.WriteLine("No Data Rows");
        //            }
        //            reader.Close();
        //        }
        //        connection.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.InnerException);
        //    }
        //    return View();
        //}

        //[HttpPost]
        ////UPDATE PEGAWAI
        //// POST: Student/Edit/5
        //public bool Edit (Pegawai pegawai)
        //{
        //    SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-3EQ7S2P;Initial Catalog=SuratPerjalananDinass;Integrated Security=True");
        //    Pegawai pegawai1 = new Pegawai();
        //    SqlCommand com = new SqlCommand("UpdatePegawai", sqlConnection);
        //    com.CommandType = CommandType.StoredProcedure;
        //    com.Parameters.AddWithValue("@namaPegawai", pegawai1.namePegawai);
        //    com.Parameters.AddWithValue("@nipPegawai", pegawai1.nipPegawai);
        //    com.Parameters.AddWithValue("@jabatanPegawai", pegawai1.jabatanPegawai);
        //    com.Parameters.AddWithValue("@golonganPegawai", pegawai1.golonganPegawai);

        //    sqlConnection.Open();
        //    int i = com.ExecuteNonQuery();
        //    sqlConnection.Close();
        //    if (i >= 1)
        //    {
        //        return ViewBag.Message = "Data berhasil ditambah";
        //    }
        //    else
        //    {
        //        return ViewBag.Message = "Pegawai Gagal Ditambah"; ;
        //    }

        //}

        ////DELETE ACTION without dialog
        //public IActionResult Delete(int id)
        //{
        //    SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-3EQ7S2P;Initial Catalog=SuratPerjalananDinass;Integrated Security=True");

        //    SqlCommand cmd = new SqlCommand("DeletePegawai", sqlConnection);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    cmd.Parameters.AddWithValue("@idPegawai", id);

        //    sqlConnection.Open();
        //    int i = cmd.ExecuteNonQuery();
        //    sqlConnection.Close();

        //    return RedirectToAction("Index");

        //}




    }
}
