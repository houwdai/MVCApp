using API.Models;
using System.Collections.Generic;

namespace API.Repositories.Interface
{
    public interface IPegawaiRepository
    {
        //Ambil all data 
        List<Pegawai> Get();

        //ambil data pegawai by id
        Pegawai GetById(int id);

        //create
        int Post(Pegawai pegawai);

        //update
        int Put(Pegawai pegawai);

        //delete
        int Delete(int id);
    }
}
