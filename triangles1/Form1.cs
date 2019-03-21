using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SharpGL;

namespace triangles1
{
    public partial class Form1 : Form
    {
        public const float size_p = 25.0f;
        public const float size_m = -25.0f;

        // размеры окна 
        double ScreenW=30.0f, ScreenH=30.0f;

        // отношения сторон окна вимзуализации
        // для корректного переволда координат мыши в координаты, 
        // принятые в программе
        private float devX;
        private float devY;

        double a = 1, b = 0, c = 0;

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            // генерация коэффициента 
            a = (double)trackBar1.Value / 1000.0;
            // вывод значения коэффициента, управляемого данным ползунком. 
            // (под TrackBa'ом) 
            label4.Text = a.ToString(); 
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            // генерация коэффициента 
            b = (double)trackBar2.Value / 1000.0;
            // вывод значения коэффициента, управляемого данным ползунком. 
            // (под TrackBa'ом) 
            label5.Text = b.ToString();
        }

        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            Draw();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // старт таймера, отвечающего за вызов функции 
            // визуализирующей кадр 
            RenderTimer.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // выход из приложения 
            Application.Exit();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            // генерация коэффициента 
            c = (double)trackBar3.Value / 1000.0;
            // вывод значения коэффициента, управляемого данным ползунком. 
            // (под TrackBa'ом) 
            label6.Text = c.ToString();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //  Get the OpenGL object.
            OpenGL gl = AnT.OpenGL;

            //  Clear the color and depth buffer.
            //gl.ClearColor(1.0f, 1.0f, 1.0f, 1.0f);
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.Viewport(0, 0, AnT.Size.Width, AnT.Size.Height);
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            //  Load the identity matrix.
            gl.LoadIdentity();

            // размер проекции в зависимости от размеров AnT
            if (AnT.Width <= AnT.Height)
                gl.Ortho2D(0.0, 30.0, 0.0, 30.0 * (float)AnT.Height / (float)AnT.Width);
            else
                gl.Ortho2D(0.0, 30.0 * (float)AnT.Width / (float)AnT.Height, 0.0, 30.0);
            
            // коэффициенты для перевода координат оконной системы в систему OpenGL
            devX = (float)(ScreenW * 2.0f) / (float)AnT.Size.Width;
            devY = (float)(ScreenH * 2.0f) / (float)AnT.Size.Height;

            // установка объектно-видовой матрицы
            gl.MatrixMode(OpenGL.GL_MODELVIEW);

            gl.LoadIdentity();

        }

        // функция Draw 
        private void Draw()
        {
            //  Get the OpenGL object.
            OpenGL gl = AnT.OpenGL;
            // очищаем буфер цвета 
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT);
            // активируем рисование в режиме GL_TRIANGLES, при котором задание 
            // трех вершин с помощью функции glVertex2d или glVertex3d 
            // будет объединяться в трехгранный полигон (треугольник) 
            gl.Begin(OpenGL.GL_TRIANGLES);
            // устанавливаем параметр цвета, основанный на параметрах a b c 
            gl.Color(a, b, c);
            //gl.Color(1.0f, 1.0f, 1.0f);
            // рисуем вершину в координатах 5,5 
            gl.Vertex(5.0, 5.0);
            // устанавливаем параметр цвета, основанный на параметрах с a b 
            gl.Color(c, a, b);
            // рисуем вершину в координатах 25,5 
            gl.Vertex(25.0, 5.0);
            // устанавливаем параметр цвета, основанный на параметрах b c a 
            gl.Color(b, c, a);
            // рисуем вершину в координатах 25,5 
            gl.Vertex(5.0, 25.0);
            // завершаем режим рисования примитивов 
            gl.End();
            // дожидаемся завершения визуализации кадра 
            gl.Flush();
            // обновляем изображение в элементе AnT 
            AnT.Invalidate();
        } 

    }
}
