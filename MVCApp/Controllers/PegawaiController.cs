using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

        public IActionResult Create()
        {
            return View(new Pegawai());
        }

        [HttpPost]
        // POST : /Create/Pegawai
        public IActionResult Create(Pegawai pegawaii)
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


        // EDIT GET
        [HttpGet("Edit/{id:int}")]
        public IActionResult Edit(int id)
        {
            SqlParameter sqlParameterId = new SqlParameter();
            sqlParameterId.ParameterName = "@idPegawai";
            sqlParameterId.Value = id;
            string query = "select * from pegawai where idPegawai = @idPegawai";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.Add(sqlParameterId);

            try
            {
                connection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            ViewData["idPegawai"] = reader[0];
                            ViewData["namePegawai"] = reader[1];
                            ViewData["nipPegawai"] = reader[2];
                            ViewData["jabatanPegawai"] = reader[3];
                            ViewData["golonganPegawai"] = reader[4];
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Rows");
                    }
                    reader.Close();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            return View();
        }

        [HttpPost]
        //UPDATE PEGAWAI
        // POST: Student/Edit/5
        public bool Edit (Pegawai pegawai)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-3EQ7S2P;Initial Catalog=SuratPerjalananDinass;Integrated Security=True");
            Pegawai pegawai1 = new Pegawai();
            SqlCommand com = new SqlCommand("UpdatePegawai", sqlConnection);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@namaPegawai", pegawai1.namePegawai);
            com.Parameters.AddWithValue("@nipPegawai", pegawai1.nipPegawai);
            com.Parameters.AddWithValue("@jabatanPegawai", pegawai1.jabatanPegawai);
            com.Parameters.AddWithValue("@golonganPegawai", pegawai1.golonganPegawai);

            sqlConnection.Open();
            int i = com.ExecuteNonQuery();
            sqlConnection.Close();
            if (i >= 1)
            {
                return ViewBag.Message = "Data berhasil ditambah";
            }
            else
            {
                return ViewBag.Message = "Pegawai Gagal Ditambah"; ;
            }

        }

        //DELETE ACTION without dialog
        public IActionResult Delete(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-3EQ7S2P;Initial Catalog=SuratPerjalananDinass;Integrated Security=True");

            SqlCommand cmd = new SqlCommand("DeletePegawai", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idPegawai", id);

            sqlConnection.Open();
            int i = cmd.ExecuteNonQuery();
            sqlConnection.Close();

            return RedirectToAction("Index");

        }




    } }
