using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
   public interface ICustomer_Interface
   {
        void Create(string cust_name, string customer_pno);
        object Read();
        void Update(int cid, string cname, string cpno);
        void Delete(int cust_id);
   }
}
