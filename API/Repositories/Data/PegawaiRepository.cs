using API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using API.Context;
using API.Models;
using System.Collections.Generic;
using System.Linq;

namespace API.Repositories.Data
{
    public class PegawaiRepository : IPegawaiRepository
    {
        MyContext myContext;

        public int Delete(int id)
        {
            var pegawai = myContext.Pegawaii.Where(a => a.idPegawai == id).FirstOrDefault();
            myContext.Pegawaii.Remove(pegawai);
            var result = myContext.SaveChanges();
            return result;
        }

        public List<Pegawai> Get()
        {
            var data = myContext.Pegawaii.Include(x => x.Golongan).ToList();
            return data;
        }

        public Models.Pegawai GetById(int id)
        {
            var employee = myContext.Pegawaii.Where(x => x.idPegawai == id).Include(x => x.Golongan).FirstOrDefault();
            return employee;
        }

        public int Post(Pegawai pegawai)
        {

            myContext.Pegawaii.Add(pegawai);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Put(Pegawai pegawai)
        {
            var data = GetById(pegawai.idPegawai);
            data.idPegawai = pegawai.idPegawai;
            data.nipPegawai = pegawai.nipPegawai;
            data.namePegawai = pegawai.namePegawai;
            data.jabatanPegawai= pegawai.jabatanPegawai;
            data.IdGolongan  = pegawai.IdGolongan;
            myContext.Pegawaii.Update(data);
            var result = myContext.SaveChanges();
            return result;

        }
    }
}
