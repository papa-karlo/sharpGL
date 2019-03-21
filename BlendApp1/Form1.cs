using System;
using System.Windows.Forms;


using SharpGL;
using SharpGL.SceneGraph.Shaders;

namespace ScopeApp1
{

    public partial class Form1 : Form
    {

        public const float size_p = 25.0f;
        public const float size_m = -25.0f;

        // размеры окна 
        double ScreenW, ScreenH;

        // отношения сторон окна вимзуализации
        // для корректного переволда координат мыши в координаты, 
        // принятые в программе
        private float devX;
        private float devY;

        // Массив x,y точек графика
        private float[,] GrapValuesArray;
        // элементов в массиве
        private int elements_count = 0;
        // флаг заполнения масива точек
        private bool not_calculate = true;

        // номер ячейки, для координат красной точки
        private int pointposition = 0;

        // вспомогательные переменные для построения линий от курсора мыши 
        // к координатным осям
        private float lineX, lineY;

        // текущие координаты курсора мыши
        private float Mcoord_X = 0;
        private float Mcoord_Y = 0;

        private float phase = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            //  Get the OpenGL object.
            OpenGL gl = AnT.OpenGL;

            //  Clear the color and depth buffer.
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.Viewport(0,0,AnT.Size.Width, AnT.Size.Height);
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            //  Load the identity matrix.
            gl.LoadIdentity();
            //gl.Ortho(-AnT.Size.Width/2.0f, AnT.Size.Width / 2.0f, -AnT.Size.Height / 2.0f, AnT.Size.Height / 2.0f, 0.0f, 1.0f);

            //gl.Ortho(-10, 10, -10, 10, -10, 10);
            
            // размер проекции в зависимости от размеров AnT
            if ( (float)AnT.Size.Width <= (float)AnT.Size.Height)
            {
                ScreenW = size_p;
                ScreenH = size_p * (float)AnT.Size.Height / (float)AnT.Size.Width;
                //gl.Ortho2D(0.0, ScreenW, 0.0, ScreenH);
            }
            else
            {
                ScreenW = size_p * (float)AnT.Size.Width / (float)AnT.Size.Width;
                ScreenH = size_p;
                //gl.Ortho2D(0.0, ScreenW, 0.0, ScreenH);
            }
            gl.Ortho2D(-ScreenW, ScreenW, -ScreenH, ScreenH);

            // коэффициенты для перевода координат оконной системы в систему OpenGL
            devX = (float)(ScreenW * 2.0f) / (float)AnT.Size.Width;
            devY = (float)(ScreenH * 2.0f) / (float)AnT.Size.Height;

            // установка объектно-видовой матрицы
            gl.MatrixMode(OpenGL.GL_MODELVIEW);

            gl.Enable(OpenGL.GL_BLEND);
            //gl.BlendEquationEXT(OpenGL.GL_FUNC_ADD_EXT);

            gl.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);

            //gl.BlendFunc(OpenGL.GL_ONE, OpenGL.GL_ONE_MINUS_SRC_ALPHA);

            //gl.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_SRC_ALPHA);

            //gl.BlendFunc(OpenGL.GL_SRC_COLOR, OpenGL.GL_ONE_MINUS_SRC_ALPHA);

            //gl.BlendFunc(OpenGL.GL_ONE, OpenGL.GL_ONE_MINUS_SRC_ALPHA);

            //gl.BlendFunc(OpenGL.GL_DST_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);
            //gl.BlendFunc(OpenGL.GL_ONE, OpenGL.GL_ONE_MINUS_SRC_ALPHA);
            //gl.BlendFunc(OpenGL.GL_ZERO, OpenGL.GL_ONE_MINUS_CONSTANT_ALPHA_EXT);

            //gl.Enable(OpenGL.GL_POINT_SMOOTH);
            gl.Disable(OpenGL.GL_DEPTH_TEST);

            //gl.BlendColor(0.1f, 0.1f, 0.1f, 0.0f);

            // gl.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE);
            gl.LoadIdentity();

            // старт счетчика таймера
            PointInGrap.Start();

        }

        private void AnT_MouseMove(object sender, MouseEventArgs e)
        {
            // current coords
            Mcoord_X = e.X;
            Mcoord_Y = e.Y;
            // вычисляем параметры для будущей дорисовки линий от указателя мыши 
            // к координатным осям
            lineX = (float)(devX * e.X) - (float)ScreenW;
            lineY = (float)ScreenH - (float)(devY * e.Y);
        }

        private void PrintText2D(float x, float y, string text)
        {
            OpenGL gl = AnT.OpenGL;
            gl.DrawText((int)x, (int)y, 1, 1, 1, "", 10, text);
        }

        private void functionCalculation()
        {
            float x=0, y=0;
            // массив для хранения size_p*2*10 точек
            int array_size = (int)(size_p * 2 * 10);
            GrapValuesArray = new float[array_size, 2];
            elements_count = 0;
            // вычисления всех значение y для x, принадлежащего промежутку 
            // от size_m до +size_p с шагом 0.1f
            //for ( x = size_m; x<size_p; x+=0.1f)
            for (x = -4*5; x < +4*5; x += 0.1f)
            {
                // вычисление синуса
                y = (float)Math.Sin(x+phase) * 5 + 0;
                GrapValuesArray[elements_count, 0] = x;
                GrapValuesArray[elements_count, 1] = y;
                elements_count++;
            }
            not_calculate = false;
            phase += 0.03f;
        }

        private void DrawDiagram()
        {
            if (not_calculate)
            {
                functionCalculation();
            }

            OpenGL gl = AnT.OpenGL;
            // старт отрисовки в режиме визуализации точек, объединяемых в линии
            gl.Begin(OpenGL.GL_LINE_STRIP);
            gl.Color(0.0f, 0.0f, 1.0f, 0.7f); // установка зеленого 
            //gl.Color(0.0f, 1.0f, 0.0f); // установка зеленого 
            //gl.Color(1.0f, 1.0f, 0.0f); // установка желтого
            // рисуем начальную точку
            gl.Vertex(GrapValuesArray[0, 0], GrapValuesArray[0, 1]);
            // проходим по массиву точек
            for(int ax = 1; ax < elements_count; ax += 2)
            {
                gl.Vertex(GrapValuesArray[ax, 0], GrapValuesArray[ax, 1]);
            }
            gl.End();

            gl.PointSize(5); // размер точек 5 пикселей
            gl.Color(1.0f, 0.0f, 0.0f); // красный цвет

            // режим вывода точек
            gl.Begin(OpenGL.GL_POINTS);
            // выводим красную точку, используя ту ячейку массива, до которой мы дошли 
            // (вычисляется в функции обработчике событий таймера)
            gl.Vertex(GrapValuesArray[pointposition, 0], GrapValuesArray[pointposition, 1]);
            gl.End();

            gl.PointSize(1); // устанавливаем размер точек 1 пиксел
/*
            //uint program = gl.CreateProgram();
            uint geom = gl.CreateShader(OpenGL.GL_GEOMETRY_SHADER);
            uint shader = 0;
            string geometryShaderSourceString = null;
            gl.ShaderSource(shader, geometryShaderSourceString);
            gl.CompileShader(shader);
            //gl.AttachShader(program, geom);
            */
            not_calculate = true;
        }

        private void Draw()
        {
            OpenGL gl = AnT.OpenGL;
            // gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            // Shade diagram
            gl.Color(0.0f, 0.0f, 0.0f, 0.01f); // установка черного с прозрачностью
            gl.Rect(-25.0f, 25.0f, 25.0f, -25.0f);

            gl.LoadIdentity();
            //gl.Color(0, 0, 0); // установка черного 
            gl.Color(1.0f, 1.0f, 1.0f); // установка белого 

            // помещаем состояние матрицы в стек матриц
            //gl.PushMatrix();

            // выполняем перемещение в пространстве по осям X и Y
            //gl.Translate(size_p, size_p, 0);

            // активируем режим рисования
            gl.PointSize(1); // устанавливаем размер точек 1 пиксел
            /*
            gl.Begin(OpenGL.GL_POINTS);
            // создаем сетку из точек
            for(int ax = -size_m; ax < size_p; ax+=2)
            {
                for(int bx = -size_m; bx < size_p; bx+=2)
                {
                    gl.Vertex(ax, bx);
                }
            }
            gl.End();
            */

            // рисуем сетку
            gl.Color(0.5f, 0.5f, 0.5f, 0.5f); // установка серого
            gl.Begin(OpenGL.GL_LINES);
            // vertical
            for(int ii=0;ii<5;ii++)
            {
                gl.Vertex(-4 - 4 * ii, -4 * 4);
                gl.Vertex(-4 - 4 * ii, 4 * 4);
                gl.Vertex(4 + 4 * ii, -4 * 4);
                gl.Vertex(4 + 4 * ii, 4 * 4);
            }

            // horizontal
            for (int ii = 0; ii < 4; ii++)
            {
                gl.Vertex(-5 * 4, -4 - 4 * ii);
                gl.Vertex(5 * 4, -4 - 4 * ii);
                gl.Vertex(-5 * 4, 4 + 4 * ii);
                gl.Vertex(5 * 4, 4 + 4 * ii);
            }
            gl.End();
            gl.Color(1.0f, 1.0f, 1.0f); // установка белого 

            // рисуем оси (режим отрисовки линий) 
            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(0, 4*4);
            gl.Vertex(0, -4*4);
            gl.Vertex(4*5, 0);
            gl.Vertex(-4*5, 0);
            // вертикальная стрелка
            gl.Vertex(0, 4*4);
            gl.Vertex(0.1, 4 * 4 - 0.5);
            gl.Vertex(0, 4 * 4);
            gl.Vertex(-0.1, 4 * 4 - 0.5);
            // горизонтальная стрелка
            gl.Vertex(4 * 5, 0);
            gl.Vertex(4 * 5 - 0.5, 0.1);
            gl.Vertex(4 * 5, 0);
            gl.Vertex(4 * 5 - 0.5, -0.1);
            gl.End();

            //gl.DrawBuffer(OpenGL.GL_DOUBLEBUFFER);

            // подписи осей
            //PrintText2D(size_p-0.5f, 0, "x");
            gl.DrawText((int)(size_p/devX + (5*4 + 0.5) / devX), (int)(ScreenH/devY)+10,
                        1.0f, 1.0f, 1.0f,
                        "", 12,
                        "X");
            //            PrintText2D(0.5f, size_p-0.5, "y");
            gl.DrawText((int)((ScreenW + 1.0f) / devY) + 20,
                        (int)(ScreenH/devY + (4*4 + 0.5)/devY),
                        1.0f, 1.0f, 1.0f,
                        "", 12,
                        "Y");

            // Рисуем график
            //gl.PointSize(3); // устанавливаем размер точек 3 пиксел
            //gl.Color(0.0f, 1.0f, 0.0f); // установка зеленого 
            
            DrawDiagram();

            gl.Color(1.0f, 1.0f, 1.0f); // установка белого 

            // возвращаем матрицу из стека
            gl.PopMatrix();


            //PrintText2D(devX * Mcoord_X + 0.2f - (float)ScreenW, (float)ScreenH - devY * Mcoord_Y + 0.4f, "[x:" + (devX * Mcoord_X - size_p).ToString() + ";y:" + ((float)ScreenH - devY * Mcoord_Y - size_p).ToString() + "]");
            gl.DrawText((int)(Mcoord_X + 10),
                        (int)((ScreenH*2.0/devY) - Mcoord_Y + size_p),
                        1.0f, 0.0f, 0.0f,    // красный цвет
                        "", 12, // font size = 12
                        "[x:" + (lineX).ToString() + ";y:" + (lineY).ToString() + "]");

            gl.Color(1.0f, 0.0f, 0.0f); // красный цвет
            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(lineX, 0);
            gl.Vertex(lineX, lineY);
            gl.Vertex(0, lineY);
            gl.Vertex(lineX, lineY);
            gl.End();
            
            // дожидаемся завершения визуализации кадра
            //gl.Flush();
            gl.Finish();
//            gl.DrawBuffers()
            // обновть
            AnT.Invalidate();
        }

        private void AnT_Load(object sender, EventArgs e)
        {

        }

        private void PointInGrap_Tick(object sender, EventArgs e)
        {
            // если дошли до последнего элемента массива
            if (pointposition == elements_count - 1)
                pointposition = 0; // first element

            //for (int ii = 0; ii < 100; ii++)
                Draw();

            // next element
            pointposition++;
        }

        public Form1()
        {
            InitializeComponent();
        }

        // ! Инициализация шейдеров
        private void initShader()
        { //! Исходный код шейдеров
            string vsSource =
                "attribute vec2 coord;\n "+          
                "void main() {\n"+
                " gl_Position = vec4(coord, 0.0, 1.0);\n"+
                "}\n";
            string fsSource =
                "uniform vec4 color;\n"+
                "void main() {\n"+
                " gl_FragColor = color;\n"+
                "}\n";
            // ! Переменные для хранения идентификаторов шейдеров
            //Shader vShader, fShader; // ! Создаем вершинный шейдер

            OpenGL gl = AnT.OpenGL;

            VertexShader vShader = new VertexShader();
            // ! Передаем исходный код 
            vShader.SetSource( vsSource);
            // ! Компилируем шейдер 
            vShader.Compile();
        }

        }
    }
