﻿using System.Windows.Forms;
using NbFramework.CodeGenerate.NbRefs;

namespace NbFramework.CodeGenerate
{
    public partial class NbRefForm : Form
    {
        public NbRefForm()
        {
            InitializeComponent();
        }

        private void NbRefForm_Load(object sender, System.EventArgs e)
        {

        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            this.txtResult.Text = NbRefCodeHelper.Generate();
        }
    }
}
