using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FP_IT_Scope_1
{
    public partial class Form1 : Form
    {
        private SystemMenu m_SystemMenu = null;
        public const Int32 WM_SYSCOMMAND = 0x112;
        private const int m_AboutID = 0x100;
        private const int menu0 = 0x101;
        private const int menu1 = 0x102;
        private const int menu2 = 0x103;

        private void Form1_Load(object sender, System.EventArgs e)
        {
            m_SystemMenu = SystemMenu.FromForm(this);
            m_SystemMenu.AppendSeparator();
            m_SystemMenu.AppendMenu(m_AboutID, "About this...");

            m_SystemMenu.InsertSeparator(0);
            m_SystemMenu.InsertMenu(0, menu0, "Menu");

            m_SystemMenu.InsertMenu(menu1, SystemMenu.ItemFlags.mfBarBreak, 1, "ButtonBar1");
            m_SystemMenu.AppendSeparator();
            m_SystemMenu.InsertMenu(menu2, SystemMenu.ItemFlags.mfByPosition, 2, "ButtonBar2");

            m_SystemMenu = SystemMenu.FromForm(this);
            m_SystemMenu.InsertMenu(m_AboutID, SystemMenu.ItemFlags.mfChecked, 3, "ButtonBar3");
        }

        protected override void WndProc(ref Message msg)
        {
            if (msg.Msg == (int)SystemMenu.WindowMessages.wmSysCommand)
            {
                switch (msg.WParam.ToInt32())
                {
                    case 3:
                        {
                            MessageBox.Show(this, "Test", "Menu3");

                        }
                        break;
                    case m_AboutID:
                        {
                            MessageBox.Show(this, "Test", "About");

                        }
                        break;
                }
            }
            base.WndProc(ref msg);
        }

        public Form1()
        {
            InitializeComponent();
            //            this.WindowState = FormWindowState.Maximized;
            //задаем всплывающий текст-подсказку (появляется при наведении указателя на иконку в трее)
            notifyIcon1.Text = "Текст-подсказка";
            //устанавливаем значок, отображаемый в трее:
            //либо один из стандартных:
            //_notifyIcon.Icon = SystemIcons.Error;
            //либо свой из файла:
            notifyIcon1.Icon = new Icon("logo_insys.ico");
            //подписываемся на событие клика мышкой по значку в трее
            notifyIcon1.MouseClick += new MouseEventHandler(notifyIcon1_MouseClick);
            //подписываемся на событие изменения размера формы
            this.Resize += new EventHandler(Form1_Resize);

        }

        Point offset;
        bool isTopPanelDragged = false;
        bool allowResize = false;

        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isTopPanelDragged = true;
                Point pointStartPosition = this.PointToScreen(new Point(e.X, e.Y));
                offset = new Point();
                //offset.X = this.Location.X - pointStartPosition.X;
                //offset.Y = this.Location.Y - pointStartPosition.Y;
                offset.X = TopPanel.Location.X - pointStartPosition.X;
                offset.Y = TopPanel.Location.Y - pointStartPosition.Y;
            }
            else
            {
                isTopPanelDragged = false;
            }
        }

        private void TopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isTopPanelDragged)
            {
                Point newPoint = TopPanel.PointToScreen(new Point(e.X, e.Y));
                newPoint.Offset(offset);
                //this.Location = newPoint;
                TopPanel.Location= newPoint;
            }
        }

        private void TopPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isTopPanelDragged = false;
            allowResize = false;
        }

        private void InSysLabel_MouseDown(object sender, MouseEventArgs e)
        {
            allowResize = true;
            TopPanel_MouseDown(sender, e);
        }

        private void InSysLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (allowResize)
            {
                this.TopPanel.Height = TopPanel.Top + e.Y;
                this.TopPanel.Width = TopPanel.Left + e.X;
            }
            TopPanel_MouseMove(sender, e);
        }

        private void InSysLabel_MouseUp(object sender, MouseEventArgs e)
        {
            TopPanel_MouseUp(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openGLControl1_Load(object sender, EventArgs e)
        {
            
        }

        ///
        /// здесь хранится состояние окна до сворачивания (максимизированное или нормальное)
        ///
        private FormWindowState _OldFormState;

        ///
        /// обрабатываем событие клика мышью по значку в трее
        ///
        void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            //проверяем, какой кнопкой было произведено нажатие
            if (e.Button == MouseButtons.Left)//если левой кнопкой мыши
            {
                //проверяем текущее состояние окна
                if (WindowState == FormWindowState.Normal || WindowState == FormWindowState.Maximized)//если оно развернуто
                {
                    //сохраняем текущее состояние
                    _OldFormState = WindowState;
                    //сворачиваем окно
                    WindowState = FormWindowState.Minimized;
                    //скрываться в трей оно будет по событию Resize (изменение размера), которое сгенерировалось после минимизации строчкой выше
                }
                else//в противном случае
                {
                    //и показываем на нанели задач
                    Show();
                    //разворачиваем (возвращаем старое состояние "до сворачивания")
                    WindowState = _OldFormState;
                }
            }
        }

        ///
        /// обрабатываем событие изменения размера
        ///
        void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)//если окно "свернуто"
            {
                //то скрываем его
                Hide();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void TopPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
