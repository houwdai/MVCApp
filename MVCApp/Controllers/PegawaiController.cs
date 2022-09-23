using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MVCApp.Models;
using System;
using System.Collections.Generic;
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
        public IActionResult Create()
        {
            using SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-3EQ7S2P;Initial Catalog=SuratPerjalananDinass;Integrated Security=True");
            {
                Pegawai pegawai = new Pegawai();
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.Transaction = sqlTransaction;

                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@nama";
                sqlParameter.Value = pegawai.namePegawai;
                cmd.Parameters.Add(sqlParameter);

                SqlParameter sqlParameter2 = new SqlParameter();
                sqlParameter2.ParameterName = "@nip";
                sqlParameter2.Value = pegawai.nipPegawai;
                cmd.Parameters.Add(sqlParameter2);


                SqlParameter sqlParameter3 = new SqlParameter();
                sqlParameter3.ParameterName = "@jabatan";
                sqlParameter3.Value = pegawai.jabatanPegawai;
                cmd.Parameters.Add(sqlParameter3);

                SqlParameter sqlParameter4 = new SqlParameter();
                sqlParameter4.ParameterName = "@golongan";
                sqlParameter4.Value = pegawai.golonganPegawai;
                cmd.Parameters.Add(sqlParameter4);
                try
                {
                    cmd.CommandText = "INSERT INTO pegawai " + "(namaPegawai, nipPegawai, jabatanPegawai, golonganPegawai) " +
                        "values (@nama, @nip, @jabatan, @golongan)";

                    cmd.ExecuteNonQuery();
                    sqlTransaction.Commit();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
            return View();

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
