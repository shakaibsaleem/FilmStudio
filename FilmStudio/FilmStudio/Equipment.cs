using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStudio
{
    class Equipment
    {
        public int Id, QtyAvailable, QtyBooked;
        public string Description, Make, Model, Remarks;

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
