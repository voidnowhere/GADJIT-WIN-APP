﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GADJIT_WIN_CLIENT
{
    public partial class DiagnosticTicketForClient : Form
    {
        public DiagnosticTicketForClient()
        {
            InitializeComponent();
        }

        private void PictureBoxExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
    }
}