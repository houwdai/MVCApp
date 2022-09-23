using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MVCApp.Models;
using System.Collections.Generic;
using System;

namespace MVCApp.Controllers
{
    public class RepresentasiController : Controller
    {
        public IActionResult Index()
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-3EQ7S2P;Initial Catalog=SuratPerjalananDinass;Integrated Security=True");
            List<Representasi> RepresentasiList = new List<Representasi>();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = "Select * from uangRepresentasi";
            try
            {
                sqlConnection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        while (reader.Read())
                        {
                            Representasi representasi = new Representasi();

                            representasi.id = reader[0].ToString();
                            representasi.uraian = reader[1].ToString();
                            representasi.luarkota = Convert.ToInt32(reader[2]);
                            representasi.dalamkota = Convert.ToInt32(reader[3]);

                            RepresentasiList.Add(representasi);
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

            return View(RepresentasiList);
        }

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

       public IActionResult Edit(int id)
        {
            return View();
        }
    }
}