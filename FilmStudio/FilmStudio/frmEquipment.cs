using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilmStudio
{
    public partial class frmEquipment : Form
    {
        public Equipment myEquipment;

        public frmEquipment()
        {
            InitializeComponent();
            myEquipment = new Equipment(1,2,0, "Black Magic 4K cinema", "Blackmagic Design", "CINECAMPROD4KEF","");
        }

        public frmEquipment(Equipment eq)
        {
            InitializeComponent();
            myEquipment = new Equipment(
                eq.Id,
                eq.QtyAvailable,
                eq.QtyBooked,
                eq.Description,
                eq.Make,
                eq.Model,
                eq.Remarks
                );
        }

        private void frmEquipment_Load(object sender, EventArgs e)
        {
            txtItemId.Text = myEquipment.Id.ToString();
            txtQtyAvailable.Text = myEquipment.QtyAvailable.ToString();
            txtQtyBooked.Text = myEquipment.QtyBooked.ToString();
            txtMake.Text = myEquipment.Make.ToString();
            txtModel.Text = myEquipment.Model.ToString();
            txtDescription.Text = myEquipment.Description.ToString();
            txtRemarks.Text = myEquipment.Remarks.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
