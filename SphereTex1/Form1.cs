using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

using SharpGL;
using SharpGL.SceneGraph.Assets;

namespace Sphere1
{

    public partial class Form1 : Form
    {
        float rtri = 0;
        float rotate = 0.0f;
        IntPtr quadratic;

        private float[] xcoord = new float[1024];
        private float[] ycoord = new float[1024];

        //  The texture identifier.
        Texture texture = new Texture();

        public Form1()
        {
            InitializeComponent();
            //  Get the OpenGL object, for quick access.
            SharpGL.OpenGL gl = AnT.OpenGL;

            //  A bit of extra initialisation here, we have to enable textures.
            gl.Enable(OpenGL.GL_TEXTURE_2D);

            //  Create our texture object from a file. This creates the texture for OpenGL.
            //texture.Create(gl, "earthmap1k.jpg");
            //texture.Create(gl, "realistic_earth.jpg");
            //texture.Create(gl, "earth.jpg");
            texture.Create(gl, "earth_flip.jpg");
            //texture.Create(gl, "earth.bmp");
            //texture.Create(gl, "crate.bmp");
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

            gl.Perspective(60, (float)AnT.Width / (float)AnT.Height, 0.1, 200);

            // установка объектно-видовой матрицы
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            
            
            gl.Enable(OpenGL.GL_DEPTH_TEST);
            gl.Enable(OpenGL.GL_NORMALIZE);
            gl.Enable(OpenGL.GL_COLOR_MATERIAL);
            gl.ColorMaterial(OpenGL.GL_FRONT, OpenGL.GL_AMBIENT_AND_DIFFUSE);
            

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
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            gl.LoadIdentity();
            gl.Translate(0.0f, 0.0f, -10.0f);
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            texture.Bind(gl);


            // view stars
            Random rnd = new Random();
            gl.Color(1.0f, 1.0f, 1.0f, 0.9f);
            gl.PointSize(2); // размер точек 5 пикселей
            int cnt = 0;
            gl.Begin(OpenGL.GL_POINTS);
            for (int i=0; i < 1000 ; i++ )
            {
                xcoord[cnt] = 0.01f * (float)rnd.Next(-800, 800);
                ycoord[cnt] = 0.01f * (float)rnd.Next(-800, 800);
                gl.Vertex(xcoord[cnt], ycoord[cnt]);
                cnt++;
            }
            cnt++;
            gl.End();

            //gl.Color(1.0f, 1.0f, 1.0f,1.0f);
            //gl.PushMatrix();

            gl.Rotate(120, 1, 0, 0);
            rotate = 90;
            gl.Rotate(rotate, 0, 0, 1);

            //gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_LINE);
            gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_FILL);

            quadratic = gl.NewQuadric();
            gl.QuadricTexture(quadratic, (int)OpenGL.GL_TRUE);
            gl.QuadricNormals(quadratic, (int)OpenGL.GLU_SMOOTH);
            gl.TexGen(OpenGL.GL_S, OpenGL.GL_TEXTURE_GEN_MODE, OpenGL.GL_SPHERE_MAP);
            gl.TexGen(OpenGL.GL_T, OpenGL.GL_TEXTURE_GEN_MODE, OpenGL.GL_SPHERE_MAP);
            // The next commands sets the texture parameters
     //       gl.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_WRAP_S, OpenGL.GL_REPEAT); // If the u,v coordinates overflow the range 0,1 the image is repeated
            //gl.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_WRAP_T, OpenGL.GL_REPEAT);
            //gl.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MAG_FILTER, OpenGL.GL_LINEAR); // The magnification function ("linear" produces better results)
            //gl.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MIN_FILTER, OpenGL.GL_LINEAR_MIPMAP_NEAREST); //The minifying function

            //  Bind the texture.
            texture.Bind(gl);
            //gl.Sphere(quadratic, 2, 32, 32);
//            gl.Sphere(quadratic, 0.9, 36, 72);

            //draw textured sphere
            gl.PushMatrix();
         //   gl.Translate(0, 0, 0);
            gl.Scale(1.5, 1.5, 1.5);
            gl.Sphere(quadratic, 2.0, 64, 128);
            gl.PopMatrix();

            gl.Flush();
            AnT.Invalidate();

            gl.DeleteQuadric(quadratic);

            timer1.Enabled = true;
            timer1.Interval = 10;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //  Get the OpenGL object.
            OpenGL gl = AnT.OpenGL;

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            gl.LoadIdentity();
            gl.Translate(0.0f, 0.0f, -10.0f);
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            texture.Bind(gl);

            // view stars
            Random rnd = new Random();
            gl.PointSize(2); // размер точек 2 пикселей
            gl.Color(0.7f, 0.7f, 0.7f, 0.7f);
            int cnt = 0;
            gl.Begin(OpenGL.GL_POINTS);
            for (int i = 0; i < 1000; i++)
            {
                gl.Vertex(xcoord[cnt], ycoord[cnt]);
                cnt++;
            }
            gl.End();
            gl.PointSize(1); // размер точек 1 пикселей

            //gl.Color(1.0f, 1.0f, 1.0f,1.0f);
            //gl.PushMatrix();

            gl.Rotate(120, 1, 0, 0);
            rotate += 0.2f;
            if (rotate > 360.0f)
            {
                rotate -= 360.0f;
            }
            gl.Rotate(rotate, 0, 0, 1);

            //gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_LINE);
            gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_FILL);

            quadratic = gl.NewQuadric();
            gl.QuadricTexture(quadratic, (int)OpenGL.GL_TRUE);
            gl.QuadricNormals(quadratic, (int)OpenGL.GLU_SMOOTH);
            gl.TexGen(OpenGL.GL_S, OpenGL.GL_TEXTURE_GEN_MODE, OpenGL.GL_SPHERE_MAP);
            gl.TexGen(OpenGL.GL_T, OpenGL.GL_TEXTURE_GEN_MODE, OpenGL.GL_SPHERE_MAP);
            // The next commands sets the texture parameters
            //       gl.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_WRAP_S, OpenGL.GL_REPEAT); // If the u,v coordinates overflow the range 0,1 the image is repeated
            //gl.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_WRAP_T, OpenGL.GL_REPEAT);
            gl.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MAG_FILTER, OpenGL.GL_LINEAR); // The magnification function ("linear" produces better results)
            //gl.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MIN_FILTER, OpenGL.GL_LINEAR_MIPMAP_NEAREST); //The minifying function

            //gl.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_WRAP_T, OpenGL.GL_MIRRORED_REPEAT);

            //  Bind the texture.
            texture.Bind(gl);
            //gl.Sphere(quadratic, 2, 32, 32);
            //            gl.Sphere(quadratic, 0.9, 36, 72);

            //draw textured sphere
            gl.PushMatrix();
            //   gl.Translate(0, 0, 0);
            gl.Scale(1.5, 1.5, 1.5);
            gl.Sphere(quadratic, 2.0, 64, 128);
//            gl.PopMatrix();

            gl.PopMatrix();

            gl.Flush();
            AnT.Invalidate();

            gl.DeleteQuadric(quadratic);

        }
    }
}

