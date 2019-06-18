using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
   public interface IFoodItem_Interface
    {
        void Create(string item_name, int serve,decimal price,byte[] img);
        object Read();
        void Update(int id,string item_name, int serve, decimal price, byte[] img);
        void Delete(int id);
    }
}
