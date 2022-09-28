using API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using API.Context;
using System.Collections.Generic;
using System.Linq;

namespace API.Repositories.Data
{
    public class Pegawai : IPegawaiRepository
    {
        MyContext myContext;

        public int Delete(int id)
        {
            var pegawai = myContext.Pegawaii.Where(a => a.idPegawai == id).FirstOrDefault();
            myContext.Pegawaii.Remove(pegawai);
            var result = myContext.SaveChanges();
            return result;
        }

        public List<Models.Pegawai> Get()
        {
            var data = myContext.Pegawaii.Include(x => x.Golongan).ToList();
            return data;
        }

        public Models.Pegawai GetById(int id)
        {
            var employee = myContext.Pegawaii.Where(x => x.idPegawai == id).Include(x => x.Golongan).FirstOrDefault();
            return employee;
        }

        public int Post(Models.Pegawai pegawai)
        {

            myContext.Pegawaii.Add(pegawai);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Put(Models.Pegawai pegawai)
        {
            var data = GetById(pegawai.idPegawai);
            myContext.Pegawaii.Update(pegawai);
            var result = myContext.SaveChanges();
            return result;

        }
    }
}
