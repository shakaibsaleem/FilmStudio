using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStudio
{
    class Equipment
    {
        private int Id, QtyAvailable, QtyBooked;
        private String Description, Make, Model, Remarks;

        public Equipment()
        {
            Id = 0;
            QtyAvailable = 0;
            QtyBooked = 0;
            Description = "";
            Make = "";
            Model = "";
            Remarks = "";
        }
    }
}
