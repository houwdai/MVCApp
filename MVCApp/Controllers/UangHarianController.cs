using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MVCApp.Models;
using System.Collections.Generic;
using System;

namespace MVCApp.Controllers
{
    public class UangHarianController : Controller
    {
        public IActionResult Index()
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-3EQ7S2P;Initial Catalog=SuratPerjalananDinass;Integrated Security=True");
            List<UangHarian> HarianList = new List<UangHarian>();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = "Select * from uangHarian";
            try
            {
                sqlConnection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        while (reader.Read())
                        {
                            UangHarian harian = new Models.UangHarian();
                           
                            harian.Id = Convert.ToInt32(reader[0]);
                            harian.provinsi = reader[1].ToString();
                            harian.luarkota = Convert.ToInt32(reader[2]);
                            harian.dalamkota = Convert.ToInt32(reader[3]);
                            harian.diklat = Convert.ToInt32(reader[4]);

                           HarianList.Add(harian);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data Found");
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }

            return View(HarianList);
        }
    }
}
