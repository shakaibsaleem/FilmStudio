using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStudio
{
    public class Staff
    {
        public int StaffID;
        public string StaffName;

        public Staff()
        {
            StaffID = 0;
            StaffName = "New Staff";
        }

        public Staff(int staffID, string staffName)
        {
            StaffID = staffID;
            StaffName = staffName ?? throw new ArgumentNullException(nameof(staffName));
        }
    }
}
