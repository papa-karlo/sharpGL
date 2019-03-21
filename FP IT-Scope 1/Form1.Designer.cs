namespace FP_IT_Scope_1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.sizeablePanel1 = new SizeablePanel();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(904, 100);
            this.TopPanel.TabIndex = 0;
            this.TopPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.TopPanel_Paint);
            this.TopPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseDown);
            this.TopPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseMove);
            this.TopPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseUp);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon2";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // sizeablePanel1
            // 
            this.sizeablePanel1.BackColor = System.Drawing.Color.White;
            this.sizeablePanel1.Location = new System.Drawing.Point(130, 207);
            this.sizeablePanel1.Name = "sizeablePanel1";
            this.sizeablePanel1.Size = new System.Drawing.Size(747, 108);
            this.sizeablePanel1.TabIndex = 1;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(904, 697);
            this.Controls.Add(this.sizeablePanel1);
            this.Controls.Add(this.TopPanel);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label InSysLabel;
        private SharpGL.OpenGLControl openGLControl1;
        private ButtonR buttonR1;
        private CustomWindowsForm.ShapedButton shapedButton1;
        private CustomWindowsForm.ButtonX buttonX1;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private SizeablePanel sizeablePanel1;
    }
}

