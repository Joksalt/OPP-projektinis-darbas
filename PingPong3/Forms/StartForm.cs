﻿using System;
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

        public static StartForm _StartForm;
        public StartForm()
        {
            InitializeComponent();

            _StartForm = this;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Form1 P1Form = new Form1();
            P1Form.Show();
            Form2 P2Form = new Form2();
            P2Form.Show();
        }

        private void messagesLog_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
