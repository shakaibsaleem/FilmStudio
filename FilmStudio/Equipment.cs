﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStudio
{
    public class Equipment
    {
        public int QtyAvailable, QtyBooked;
        public string ID, Description, Remarks;

        public Equipment()
        {
            ID = "1";
            QtyAvailable = 4;
            QtyBooked = 0;
            Description = "description";
            Remarks = "remarks";
        }

        public Equipment(int qtyAvailable, int qtyBooked, string description)
        {
            ID = "1";
            QtyAvailable = qtyAvailable;
            QtyBooked = qtyBooked;
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Remarks = "remarks";
        }

        public Equipment(string iD, int qtyAvailable, int qtyBooked, string description, string remarks)
        {
            ID = iD ?? throw new ArgumentNullException(nameof(iD));
            QtyAvailable = qtyAvailable;
            QtyBooked = qtyBooked;
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Remarks = remarks ?? throw new ArgumentNullException(nameof(remarks));
        }

        public override string ToString()
        {
            return Description;
            //return Description + " - " + QtyAvailable + " available";
        }
    }
}
