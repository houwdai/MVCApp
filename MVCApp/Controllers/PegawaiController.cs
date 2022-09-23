using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace MVCApp.Controllers
{
    public class PegawaiController : Controller
    {
        public string connectionString = "Data Source=DESKTOP-3EQ7S2P;Initial Catalog=SuratPerjalananDinass;Integrated Security=True";
        
        [HttpGet]
        public IActionResult Index()
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-3EQ7S2P;Initial Catalog=SuratPerjalananDinass;Integrated Security=True");
            List<Pegawai> pegawailist = new List<Pegawai>();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = "Select * from pegawai";
            try
            {
                sqlConnection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {

                        while (reader.Read())
                        {
                            Pegawai pegawai = new Pegawai();

                            pegawai.idPegawai = Convert.ToInt32(reader[0]);
                            pegawai.namePegawai = reader[1].ToString();
                            pegawai.nipPegawai = Convert.ToInt32(reader[2]);
                            pegawai.jabatanPegawai = reader[3].ToString();
                            pegawai.golonganPegawai = reader[4].ToString();
                            pegawailist.Add(pegawai);
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

            return View(pegawailist);
        }


        //GET: /CreatePegawai
        public IActionResult Create ()
        {
            return View(new Pegawai());
        }

        [HttpPost]
        // POST : /Create/Pegawai
        public IActionResult Create (Pegawai pegawaii)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-3EQ7S2P;Initial Catalog=SuratPerjalananDinass;Integrated Security=True");

            SqlCommand com = new SqlCommand("AddPegawai", sqlConnection);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@namaPegawai", pegawaii.namePegawai);
            com.Parameters.AddWithValue("@nipPegawai", pegawaii.nipPegawai);
            com.Parameters.AddWithValue("@jabatanPegawai", pegawaii.jabatanPegawai);
            com.Parameters.AddWithValue("@golonganPegawai", pegawaii.golonganPegawai);

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
        public IActionResult Delete(int id)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            {
                Pegawai pegawai = new Pegawai();

                sqlConnection.Open();
                SqlTransaction transaction = sqlConnection.BeginTransaction();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.Transaction = transaction;
                try
                {
                    cmd.CommandText = "DELETE FROM pegawai WHERE idPegawai=@id";
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter.ParameterName = "@id";
                    sqlParameter.Value = pegawai.namePegawai;
                    cmd.Parameters.Add(sqlParameter);
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
            return View(id);

        }

        public IActionResult Edit (int id)
        {
            return View();
        }
    }
}
