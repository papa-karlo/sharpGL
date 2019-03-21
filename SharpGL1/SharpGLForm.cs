using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SharpGL;
using SharpGL.SceneGraph.Transformations;
using SharpGL.SceneGraph.Quadrics;

namespace SharpGL1
{
    /// <summary>
    /// The main form class.
    /// </summary>
    public partial class SharpGLForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SharpGLForm"/> class.
        /// </summary>
        public SharpGLForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the OpenGLDraw event of the openGLControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RenderEventArgs"/> instance containing the event data.</param>
        private void openGLControl_OpenGLDraw(object sender, RenderEventArgs e)
        {
            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;

            //  Clear the color and depth buffer.
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            gl.MatrixMode(OpenGL.GL_PROJECTION);
            
            //  Load the identity matrix.
            gl.LoadIdentity();

            //gl.Ortho(0.0, (double)Width, (double)Height, 0.0, -1.0, 1.0);
            gl.Ortho(-10, 10, -10, 10, -10, 10);

            //  подгоняем окно просмотра под размеры окна OpenGL в форме 
            //gl.Perspective(60.0f, (double)Width / (double)Height, 0.01, 100.0);

            //  Задаем координаты камеры куда она будет смотреть 
            //gl.LookAt(-5, 5, -5, 0, 0, 0, 0, 1, 0);

            //  Back to the modelview.
            gl.MatrixMode(OpenGL.GL_MODELVIEW);

            //  Rotate around the Y axis.
            gl.Rotate(rotation, 0.0f, 1.0f, 0.0f);

            //  Draw a coloured pyramid.
            gl.Begin(OpenGL.GL_TRIANGLES);
            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(0.0f, 1.0f, 0.0f);
            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(-1.0f, -1.0f, 1.0f);
            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(1.0f, -1.0f, 1.0f);
            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(0.0f, 1.0f, 0.0f);
            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(1.0f, -1.0f, 1.0f);
            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(1.0f, -1.0f, -1.0f);
            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(0.0f, 1.0f, 0.0f);
            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(1.0f, -1.0f, -1.0f);
            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(-1.0f, -1.0f, -1.0f);
            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(0.0f, 1.0f, 0.0f);
            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(-1.0f, -1.0f, -1.0f);
            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(-1.0f, -1.0f, 1.0f);
            gl.End();

            //  Clear the color and depth buffer.
 //           gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);


            // draw samples
            gl.DrawText(100, 100, 1, 1, 1, "HEL", 10, "Hello, OpenGL!");

            //gl.Begin(OpenGL.GL_TRIANGLES);
            //gl.Color(1.0f, 0.0f, 0.0f);

            gl.Begin(OpenGL.GL_LINES);
            gl.Color(1f, 0, 0); // red
            gl.Vertex(-0f, 2f); 
            gl.Vertex(-5f, 2f);
            gl.End();

            gl.Color(1.0, 0.2, 0.1);

            double x, y, z;
            double X = -Math.PI, Y = 0;
            double Z = 0;
            gl.Begin(OpenGL.GL_TRIANGLE_STRIP);

           // gl.Vertex(-4, 1, 1);

            while (X < Math.PI)
            {
                while (Y < 2 * Math.PI)
                {
                    x = -4+1.0 * Math.Cos(X) * Math.Cos(Y);
                    y = 1.0 * Math.Cos(X) * Math.Sin(Y);
                    z = 1.0 * Math.Sin(X);
                    gl.Vertex(x, y, z);

                    x = -4 + 1 * Math.Cos(X) * Math.Cos(Y);
                    y = 1 * Math.Cos(X + 0.1) * Math.Sin(Y);
                    z = 1 * Math.Sin(X);
                    gl.Vertex(x, y, z);

                    x = -4 + 1 * Math.Cos(X + 0.1) * Math.Cos(Y);
                    y = 1 * Math.Cos(X) * Math.Sin(Y);
                    z = 1 * Math.Sin(X + 0.1);
                    gl.Vertex(x, y, z);
                    Y += 0.1;
                }
                Y = 0;
                X += 0.1;
            }
            gl.End();
            //  Nudge the rotation.
            //rotation += 1.0f;
            rotation += 0.5f;
            /*
            IntPtr quadratic = gl.NewQuadric(); //crear el objeto cuadric
            gl.QuadricNormals(quadratic, OpenGL.GLU_SMOOTH);
            gl.QuadricTexture(quadratic, (int)OpenGL.GLU_TRUE);
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            // включаем режим текстурирования , указывая идентификатор mGlTextureObject 
            uint[] gtexture = new uint[1];
            //uint mGlTextureObject;
            //gl.BindTexture(OpenGL.GL_TEXTURE_2D, mGlTextureObject);
            gl.GenTextures(1, gtexture);
            gl.BindTexture(OpenGL.GL_TEXTURE_2D, gtexture[0]);
            gl.LoadIdentity();
*/
        }



        /// <summary>
        /// Handles the OpenGLInitialized event of the openGLControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            //  TODO: Initialise OpenGL here.

            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;

            //  Set the clear color.
            gl.ClearColor(0, 0, 0, 0);
        }

        /// <summary>
        /// Handles the Resized event of the openGLControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void openGLControl_Resized(object sender, EventArgs e)
        {
            //  TODO: Set the projection matrix here.

            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;

            //  Set the projection matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);

            //  Load the identity.
            gl.LoadIdentity();

            //  Create a perspective transformation.
            gl.Perspective(60.0f, (double)Width / (double)Height, 0.01, 100.0);

            //  Use the 'look at' helper function to position and aim the camera.
            gl.LookAt(-5, 5, -5, 0, 0, 0, 0, 1, 0);

            //  Set the modelview matrix.
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }

        /// <summary>
        /// The current rotation.
        /// </summary>
        private float rotation = 0.0f;

        private void openGLControl_Load(object sender, EventArgs e)
        {

        }

        private void SharpGLForm_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
 
        }
    }
}
