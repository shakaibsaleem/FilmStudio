using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStudio
{
    public class Staff
    {
        public string StaffID,StaffName;

        public Staff()
        {
            StaffID = "1";
            StaffName = "New Staff";
        }

        public Staff(string staffID, string staffName)
        {
            StaffID = staffID ?? throw new ArgumentNullException(nameof(staffID));
            StaffName = staffName ?? throw new ArgumentNullException(nameof(staffName));
        }
    }
}
