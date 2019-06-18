using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public interface IOrder_Interface
    {
        void Create(int customer_id,int item_id,int quantity);
        object Read();
        void Update(int Oid,int customer_id, int item_id, int quantity);
        void Delete(int Oid);
    }
}
