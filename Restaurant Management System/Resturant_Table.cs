using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class Resturant_Table
    {
        private int seats;
        public int No_Of_Seat {
            get
            {
                return seats;
            }
            set
            {
                if (value == 0)
                {
                    throw new Exception("Restaurants Seats Cannot Be 0 !");
                }
                else
                {
                    seats = value;
                }
            }
        }
        public Resturant_Table(int seats) {
            this.No_Of_Seat = seats;
        }
    }
}
