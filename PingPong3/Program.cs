using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPong3
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //FIN: !! Create main method
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            StartForm MainForm = new StartForm(5);
            Application.Run(MainForm);
            //P1Form.Show();/
            //Form1 P2Form = new Form1();
            //Application.Run(P2Form);
            //P2Form.Show();
        }
    }
}
