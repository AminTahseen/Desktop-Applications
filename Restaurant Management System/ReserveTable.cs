using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class ReserveTable
    {
        private int cid;
        private int tid;
        public int Customer_id
        {
            get
            {
                return cid;
            }
            set
            {
                if (value == 0)
                {
                    throw new Exception("Customer ID Cannot Be 0 !");
                }
                else
                {
                    cid = value;
                }
            }
        }
        public int Table_id
        {
            get
            {
                return tid;
            }
            set
            {
                if (value == 0)
                {
                    throw new Exception("Table ID Cannot Be 0 !");
                }
                else
                {
                    tid = value;
                }
            }
        }

        public ReserveTable(int ci, int ti) {
            this.Customer_id = ci;
            this.Table_id = ti;
        }

    }
}
