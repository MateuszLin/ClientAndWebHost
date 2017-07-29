using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientA
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            bool db = true;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!(LiteDatabase.CkeckingDb()))
            { 
                MessageBox.Show("Can't connect and create Database.\nProgram will run without saving messages");
                db = false;
            }
            Application.Run(new ClientForm(db));
        }

    }
}
