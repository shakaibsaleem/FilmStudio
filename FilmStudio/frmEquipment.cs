using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FilmStudio
{
    public partial class frmEquipment : Form
    {
        public Equipment myEquipment;
        mySQLcon myCon;
        SqlConnection con;

        public frmEquipment()
        {
            InitializeComponent();
            //myEquipment = new Equipment(1,2,0, "Black Magic 4K cinema", "Blackmagic Design", "CINECAMPROD4KEF","");
            myEquipment = new Equipment();
        }

        //public frmEquipment(Equipment eq)
        //{
        //    InitializeComponent();
        //    //myEquipment = new Equipment(eq.Id, eq.QtyAvailable, eq.QtyBooked, eq.Description, eq.Make, eq.Model, eq.Remarks);
        //    myEquipment = new Equipment(eq.ID, eq.QtyAvailable, eq.QtyBooked, eq.Description, eq.Remarks);
        //}

        private void frmEquipment_Load(object sender, EventArgs e)
        {
            myCon = new mySQLcon();
            con = myCon.con;

            //txtItemId.Text = myEquipment.ID.ToString();
            //txtQtyAvailable.Text = myEquipment.QtyAvailable.ToString();
            //txtQtyBooked.Text = myEquipment.QtyBooked.ToString();
            ////txtMake.Text = myEquipment.Make.ToString();
            ////txtModel.Text = myEquipment.Model.ToString();
            //txtDescription.Text = myEquipment.Description.ToString();
            //txtRemarks.Text = myEquipment.Remarks.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtDescription.Text.Length == 0)
            {
                MessageBox.Show("Please enter a Description to identify this item, then Add", "Description field is blank");
            }
            else if (txtQuantity.Text.Length == 0)
            {
                MessageBox.Show("Please enter total quantity of this item, then Add", "Quantity field is blank");
            }
            else
            {
                SqlDataReader rd;
                SqlTransaction tran = con.BeginTransaction();

                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.Transaction = tran;
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = "insert into Equipments (Description, " +
                        "QuantityTotal,Remarks) values ('" + myEquipment.Description +
                        "','" + Convert.ToInt32(myEquipment.QuantityTotal) + "','" + myEquipment.Remarks + "')";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "select top 1 EquipmentID from Equipments order by EquipmentID desc";
                    rd = cmd.ExecuteReader();
                    if (rd.Read() == true)
                    {
                        myEquipment.ID = rd[0].ToString();
                    }
                    rd.Close();
                    tran.Commit();
                    //state = "Incomplete";
                    //UpdateFields(state);

                    //temp scene
                    MessageBox.Show(myEquipment.Description + " has been added to Equipments", "Equipment added");
                    Close();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show(ex.Message, "Error in btnAdd");
                }
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            myEquipment.QuantityTotal = Convert.ToInt32(txtQuantity.Text);
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            myEquipment.Description = txtDescription.Text;
        }

        private void txtRemarks_TextChanged(object sender, EventArgs e)
        {
            myEquipment.Remarks = txtRemarks.Text;
        }
    }
}
