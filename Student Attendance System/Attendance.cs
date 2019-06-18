using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class Attendance
    {
        public int student_id { get; set; }
        public string Attendance_check { get; set; }
        public DateTime attendance_date { get; set; }

        public Attendance(int sid, string ac, DateTime ad)
        {
            this.student_id = sid;
            this.Attendance_check = ac;
            this.attendance_date = ad;

        }
    }
}
