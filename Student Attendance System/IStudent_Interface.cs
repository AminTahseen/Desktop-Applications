using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISD_LAB_PROJECT.Interfaces
{
    public interface IStudent_Interface
    {
        void Create(string name, string batch, string addr, string pno, string fname, byte[] img);
        object Read();
        void Update(int sid,string name, string batch, string addr, string pno, string fname, byte[] img);
        void Delete(int sid);
    }
}
