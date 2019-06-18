using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class Student
    {
        private string sname;
        private string sbatch;
        private string saddr;
        private string spno;
        private string sfname;

        public string Std_name {
            get{
                return sname;
            }
            set {
                if (value == "")
                {
                    throw new Exception("Student Name Cannot Be Null !");
                }
                else {
                    sname = value;
                }
            }
        }
        public string Std_Batch {
            get
            {
                return sbatch;
            }
            set
            {
                if (value == "")
                {
                    throw new Exception("Student Batch Cannot Be Null !");
                }
                else
                {
                    sbatch = value;
                }
            }
        }
        public string Std_Address {
            get
            {
                return saddr;
            }
            set
            {
                if (value == "")
                {
                    throw new Exception("Student Address Cannot Be Null !");
                }
                else
                {
                    saddr = value;
                }
            }
        }
        public string Std_PhoneNo {
            get
            {
                return spno;
            }
            set
            {
                if (value == "")
                {
                    throw new Exception("Student Phone No. Cannot Be Null !");
                }
                else
                {
                    spno = value;
                }
            }
        }
        public string Std_Fname {
            get
            {
                return sfname;
            }
            set
            {
                if (value == "")
                {
                    throw new Exception("Student Father Name Cannot Be Null !");
                }
                else
                {
                    sfname = value;
                }
            }
        }
        public byte[] Std_Pic { get; set; }
       
        public Student(string name,string batch,string addr,string pno,string fname,byte[] img)
        {
            this.Std_name = name;
            this.Std_Batch = batch;
            this.Std_Address = addr;
            this.Std_PhoneNo = pno;
            this.Std_Fname = fname;
            this.Std_Pic = img;
        }
    }
   
}
