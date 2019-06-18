using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
   public interface IAttendance_Interface
   {
        void Create(int sid, string ac, DateTime ad);
        object Read();
        void Update(int aid, int sid, string ac, DateTime ad);
        void Delete(int aid);
    }
}
