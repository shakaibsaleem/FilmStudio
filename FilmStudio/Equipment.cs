using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStudio
{
    public class Equipment
    {
        public int QuantityTotal, QuantityAvailable;
        public string ID, Description, Remarks;

        public Equipment()
        {
            ID = "1";
            QuantityTotal = 4;
            QuantityAvailable = 4;
            Description = "description";
            Remarks = "remarks";
        }

        public Equipment(int quantityTotal, string description)
        {
            ID = "1";
            QuantityTotal = quantityTotal;
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Remarks = "remarks";
        }

        public Equipment(string iD, int quantityTotal, int quantityAvail, string description, string remarks)
        {
            ID = iD ?? throw new ArgumentNullException(nameof(iD));
            QuantityTotal = quantityTotal;
            QuantityAvailable = quantityAvail;
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
