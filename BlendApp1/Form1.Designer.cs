namespace ScopeApp1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.AnT = new SharpGL.OpenGLControl();
            this.PointInGrap = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AnT)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.AnT);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(832, 738);
            this.panel1.TabIndex = 0;
            // 
            // AnT
            // 
            this.AnT.DrawFPS = false;
            this.AnT.Location = new System.Drawing.Point(0, 0);
            this.AnT.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.AnT.Name = "AnT";
            this.AnT.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.AnT.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.AnT.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.AnT.Size = new System.Drawing.Size(831, 752);
            this.AnT.TabIndex = 0;
            this.AnT.Load += new System.EventHandler(this.AnT_Load);
            this.AnT.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AnT_MouseMove);
            // 
            // PointInGrap
            // 
            this.PointInGrap.Enabled = true;
            this.PointInGrap.Interval = 10;
            this.PointInGrap.Tick += new System.EventHandler(this.PointInGrap_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 768);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Output function graph";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AnT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private SharpGL.OpenGLControl AnT;
        private System.Windows.Forms.Timer PointInGrap;
    }
}

