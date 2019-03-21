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

namespace Sphere1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void test_func(int[] arg)
        {
            arg[0] = 0x12345678;
        }
         
        private void Form1_Load(object sender, EventArgs e)
        {
            //  Get the OpenGL object.
            OpenGL gl = AnT.OpenGL;

            //  Clear the color and depth buffer.
            gl.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.Viewport(0, 0, AnT.Size.Width, AnT.Size.Height);
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            //  Load the identity matrix.
            gl.LoadIdentity();

            gl.Perspective(45, (float)AnT.Width / (float)AnT.Height, 0.1, 200);

            // установка объектно-видовой матрицы
            gl.MatrixMode(OpenGL.GL_MODELVIEW);

            gl.Enable(OpenGL.GL_DEPTH_TEST);
            gl.Enable(OpenGL.GL_NORMALIZE);
            gl.Enable(OpenGL.GL_COLOR_MATERIAL);
            /*
            int tex = gl.Tex

            Bitmap bitmap = new System.Drawing.Bitmap("earth.bmp"); // When I use this texture, it works fine
            uint[] textureID = new uint[1];
            gl.GenTextures(1, textureID);
            gl.BindTexture(OpenGL.GL_TEXTURE_2D, textureID[0]);
            gl.TexImage2D(OpenGL.GL_TEXTURE_2D,
                0,
                3, 
                bitmap.Width, 
                bitmap.Height, 
                0, OpenGL.GL_BGRA,
                OpenGL.GL_UNSIGNED_BYTE, 
                bitmap.
                bitmap.LockBits(new )


            gl.TexImage2D()
            getBitmap()

            Image image1 = Image.FromFile("earth.bmp", true);
            _textureId = loadTexture(Image);
*/
            gl.LoadIdentity();

            //------------------------
            //  Get the OpenGL object.
            gl = openGLControl1.OpenGL;

            //  Clear the color and depth buffer.
            gl.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.Viewport(0, 0, openGLControl1.Size.Width, openGLControl1.Size.Height);
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            //  Load the identity matrix.
            gl.LoadIdentity();

            gl.Perspective(45, (float)openGLControl1.Width / (float)openGLControl1.Height, 0.1, 200);

            // установка объектно-видовой матрицы
            gl.MatrixMode(OpenGL.GL_MODELVIEW);

            gl.Enable(OpenGL.GL_DEPTH_TEST);
            gl.Enable(OpenGL.GL_NORMALIZE);
            gl.Enable(OpenGL.GL_COLOR_MATERIAL);
            gl.LoadIdentity();

            int[] gl_major = new int[] { 0 };
            int[] gl_minor = new int[] { 0 };
            gl.GetInteger(OpenGL.GL_MAJOR_VERSION, gl_major);
            gl.GetInteger(OpenGL.GL_MINOR_VERSION, gl_major);

            test_func(gl_major);

            string gl_ver = gl.GetString(OpenGL.GL_VERSION);
            string gl_render = gl.GetString(OpenGL.GL_RENDERER);
            string gl_vendor = gl.GetString(OpenGL.GL_VENDOR);
            string gl_glsl_ver = gl.GetString(OpenGL.GL_SHADING_LANGUAGE_VERSION);

            int[] nExtensions = new int[] { 0 };
            gl.GetInteger(OpenGL.GL_NUM_EXTENSIONS, nExtensions);
            string[] s_ext = new string[nExtensions[0]];
            for (uint i = 0; i < nExtensions[0]; i++)
                s_ext[i] = gl.GetString(OpenGL.GL_EXTENSIONS, i);

            gl.LoadIdentity();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  Get the OpenGL object.
            OpenGL gl = AnT.OpenGL;

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();
            gl.Color(1.0f, 1.0f, 0);
            gl.PushMatrix();
            gl.Translate(0, 0, -6);
            gl.Rotate(45, 1, 1, 0); 

            gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_LINE);
            IntPtr quadratic = gl.NewQuadric(); 
            gl.Sphere(quadratic, 2, 32, 32);
            
            gl.PopMatrix();
            gl.Flush();
            AnT.Invalidate();

            //----------------------------------
            gl = openGLControl1.OpenGL;

           // gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();
            gl.Color(1.0f, 1.0f, 0);
            gl.PushMatrix();
            gl.Translate(0, 0, -6);
            gl.Rotate(45, 1, 1, 0); 

            gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_LINE);
            quadratic = gl.NewQuadric();
            gl.Sphere(quadratic, 2, 32, 32);

            gl.PopMatrix();
            gl.Flush();
            openGLControl1.Invalidate();

        }
    }
}

