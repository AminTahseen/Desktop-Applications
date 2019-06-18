using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public interface IRestaurantTable_Interface
    {
        void Create(int No_Of_Seats);
        object Read();
        void Update(int Table_ID, int No_Of_Seats);
        void Delete(int T_ID);
    }
}
