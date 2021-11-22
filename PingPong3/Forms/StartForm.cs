using PingPong3.Patterns.Observer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPong3
{
    public partial class StartForm : Form
    {
        Subject server = new Server();
        public static StartForm _StartForm;
        public StartForm()
        {
            InitializeComponent();

            _StartForm = this;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Form1 P1Form = new Form1();
            server.attach(P1Form);
            P1Form.Show();
            Form2 P2Form = new Form2();
            server.attach(P2Form);
            P2Form.Show();
        }

        private void messagesLog_TextChanged(object sender, EventArgs e)
        {

        }

        private void ClassicStartButton_Click(object sender, EventArgs e)
        {
            ClassicForm1 P1Form = new ClassicForm1();
            server.attach(P1Form);
            P1Form.Show();
            //Form2 P2Form = new Form2();
            //server.attach(P2Form);
            //P2Form.Show();
        }
    }
}
