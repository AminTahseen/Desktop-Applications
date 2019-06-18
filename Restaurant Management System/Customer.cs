using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class Customer
    {
        private string cname;
        private string cpno;

        public string customer_name {
            get
            {
                return cname;
            }
            set
            {
                if (value == "")
                {
                    throw new Exception("Customer Name Cannot Be Empty !");
                }
                else
                {
                    cname = value;
                }
            }
        }
        public string customer_PhoneNo {
            get
            {
                return cpno;
            }
            set
            {
                if (value == "")
                {
                    throw new Exception("Customer Contact Cannot Be Empty !");
                }
                else
                {
                   cpno = value;
                }
            }
        }

        public Customer(string cname, string cpno) {
            this.customer_name = cname;
            this.customer_PhoneNo = cpno;
        }

    }
}
