using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parent1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Form1_Load(object sender, System.EventArgs e)
        {
 /*           Form2 newMDIChild = new Form2(this);
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            newMDIChild.TopMost = true;
            // Display the new form.
            newMDIChild.Show();*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 newMDIChild = new Form2(this);
            //Form2 newMDIChild = new Form2();
            // Set the Parent Form of the Child window.
             newMDIChild.MdiParent = this;
            /*         newMDIChild.TopMost = true;
                     newMDIChild.TransparencyKey = BackColor;
                     newMDIChild.Opacity = 0.83;*/
            // Display the new form.
            newMDIChild.Show();
        }

        private void kryptonDockingManager1_PageCloseRequest(object sender, ComponentFactory.Krypton.Docking.CloseRequestEventArgs e)
        {

        }
    }
}
