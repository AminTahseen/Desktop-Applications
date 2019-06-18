using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public interface IReserveTable_Interface
    {
        void Create(int customer_id, int table_id);
        object Read();
        void Update(int rid, int customer_id, int table_id);
        void Delete(int rid);
    }
}
