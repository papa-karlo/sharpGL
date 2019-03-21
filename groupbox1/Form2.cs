using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SharpGL.SceneGraph.Shaders;



namespace parent1
{
    [ToolboxItem(true)]
    [DesignTimeVisible(true)]

    public partial class Form2 : System.Windows.Forms.Form
    {
        private Form1 fmParent = null;

        public Form2()
        {
            InitializeComponent();
        }

        //Добавляем конструктор, принимающий ссылку на родительскую форму
        public Form2(Form1 fmParent)
        {
            this.fmParent = fmParent;
            this.AllowTransparency = true;
            this.BackColor = Color.AliceBlue;//цвет фона  
            this.TransparencyKey = this.BackColor;//он же будет заменен на прозрачный цвет
            InitializeComponent();
        }

        private void Form2_Move(object sender, EventArgs e)
        {
            // 
            /*int xcoord_parent = this.fmParent.Location.X;
            int ycoord_parent = this.fmParent.Location.Y;
            int xcoord = Location.X;
            int ycoord = Location.Y;

            if (xcoord <=0) 
                this.SetDesktopLocation(0, ycoord);
            if (ycoord <= 0)
                this.SetDesktopLocation(xcoord, 0);

            this.Update();*/
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}

