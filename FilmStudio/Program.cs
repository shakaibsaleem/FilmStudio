using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilmStudio
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmLogin());
            //Application.Run(new frmEquipment());
            //Application.Run(new frmBooking());
            //Application.Run(new frmMenu());

            frmLogin login = new frmLogin();
            //Application.Run(login);
            
            if (!login.success)
            {
                Application.Run(new frmMenu());
            }
        }
    }
}
