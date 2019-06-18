using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class Order
    {
        private int cid;
        private int iId;
        private int quant;

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
        public int item_id
        {
            get
            {
                return iId;
            }
            set
            {
                if (value == 0)
                {
                    throw new Exception("Item ID Cannot Be 0 !");
                }
                else
                {
                    iId = value;
                }
            }
        }
        public int Food_quantity
        {
            get
            {
                return quant;
            }
            set
            {
                if (value == 0)
                {
                    throw new Exception("Quantity Cannot Be 0 !");
                }
                else
                {
                   quant = value;
                }
            }
        }

        public Order(int c, int i, int q) {
            this.Customer_id = c;
            this.item_id = i;
            this.Food_quantity = q;
        }
    }
}
