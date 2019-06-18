using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class Food_Item
    {
        private string fname;
        private int fserve;
        private decimal fprice;

        public string Food_Name {
            get {
                return fname;
            }
            set {
                if (value == "")
                {
                    throw new Exception("Food Name Cannot Be Empty !");
                }
                else {
                    fname = value;
                }
            }
        }
        public int Food_Serving {
            get
            {
                return fserve;
            }
            set
            {
                if (value == 0)
                {
                    throw new Exception("Food Serving Cannot Be 0 !");
                }
                else
                {
                    fserve = value;
                }
            }
        }
        public decimal Food_Price
        {
            get
            {
                return fprice;
            }
            set
            {
                if (value == 0)
                {
                    throw new Exception("Food Price Cannot Be 0 !");
                }
                else
                {
                    fprice = value;
                }
            }
        }
        public byte[] Food_image { get; set; }

        public Food_Item(string name, int serve, decimal price,byte[] img) {
            this.Food_Name = name;
            this.Food_Serving = serve;
            this.Food_Price = price;
            this.Food_image = img;
        }
    }
}
