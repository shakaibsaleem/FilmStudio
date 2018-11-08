using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStudio
{
    public class Equipment
    {
        public int Id, QtyAvailable, QtyBooked;
        public string Description, Make, Model, Remarks;

        public Equipment()
        {
            Id = 0;
            QtyAvailable = 0;
            QtyBooked = 0;
            Description = "New Equipment";
            Make = "Make";
            Model = "Model";
            Remarks = "No remarks";
        }

        public Equipment(int id, int qtyAvailable, int qtyBooked, string description, string make, string model, string remarks)
        {
            Id = id;
            QtyAvailable = qtyAvailable;
            QtyBooked = qtyBooked;
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Make = make ?? throw new ArgumentNullException(nameof(make));
            Model = model ?? throw new ArgumentNullException(nameof(model));
            Remarks = remarks ?? throw new ArgumentNullException(nameof(remarks));
        }
    }
}
