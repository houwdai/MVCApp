using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using API.Models;
using System.Collections.Generic;
using System;
using MVCApp.Context;
using System.Linq;

namespace MVCApp.Controllers
{
    public class TIketController : Controller
    {
        MyContext myContext;

        public TIketController(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public IActionResult Index()
        {
            var data = myContext.TiketPesawat.ToList();
            return View(data);
        }
        //public IActionResult Index()
        //{
        //    SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-3EQ7S2P;Initial Catalog=SuratPerjalananDinass;Integrated Security=True");
        //    List<TiketPesawat> TiketList = new List<TiketPesawat>();
        //    SqlCommand cmd = sqlConnection.CreateCommand();
        //    cmd.CommandText = "Select * from tiketPesawat order by id ";
        //    try
        //    {
        //        sqlConnection.Open();
        //        using (SqlDataReader reader = cmd.ExecuteReader())
        //        {
        //            if (reader.Read())
        //            {
        //                while (reader.Read())
        //                {
        //                    TiketPesawat tiket = new TiketPesawat();

        //                    tiket.id = Convert.ToInt32(reader[0]);
        //                    tiket.harga = Convert.ToInt32(reader[1]);
        //                    tiket.ruteTujuan = reader[3].ToString();
        //                    tiket.ruteAwal = reader[2].ToString();

        //                    TiketList.Add(tiket);

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

        //    return View(TiketList);
        //}
    }
}
