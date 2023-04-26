using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class FormGame : Form
    {
        bool kDown = false;

        // Размер холста в пикселях
        private const int
            cMapX = 10, // По ширине
            cMapY = 24, // По высоте
            cCell = 25; // Размер пикселя

        // Начальная позиция появления тетрамино (фигурки)
        private const int
            StartPosX = cMapX / 2 - 1,  // По ширине
            StartPosY = 0;              // По высоте

        // Сетка холста в виде двумерной матрицы
        private int[,] canvasMap = new int[cMapY, cMapX];

        // Активная фигура
        Tetramino activeShape;

        public FormGame()
        {
            // Инициализация компонентов формы
            InitializeComponent();
            
            // Собственная инициализация
            Init0();
        }

        public void Init0()
        {
            pbCanvasMap.Size = new Size(cMapX * cCell + 1, cMapY * cCell + 1);

            activeShape = new Tetramino(StartPosX, StartPosY, cMapX, cMapY);

            timerDraw.Interval = 500;
            
            timerDraw.Start();
        }

        private void timerDraw_Tick(object sender, EventArgs e)
        {
            activeShape.Move(Tetramino.WereMove.Down);

            RepaintMap();
        }

        private void RepaintMap()
        {
            // Перерисовываем всю поверхость
            ResetArea();

            SynchCanvasMapAndShape();

            pbCanvasMap.Invalidate();
        }

        public void SynchCanvasMapAndShape()
        {
            for (int i = 0; i < 3; i++) 
            { 
                for(int j = 0; j < 2; j++)
                {
                    // Проверка на нижнюю границу
                    bool isNotEndCanv = (j + activeShape.posX >= 0 && j + activeShape.posX < cMapX);
                    // Проверка на боковые границы
                    bool isNotEdgeCanv = (i + activeShape.posY < cMapY);
                    
                    if (isNotEndCanv && isNotEdgeCanv)
                        canvasMap[i + activeShape.posY, j + activeShape.posX] = activeShape.matrixShape[i, j];
                }
            }
        }

        public bool Collide()
        {


            return false;
        }

        public void DrawMap(Graphics grph)
        {
            for (int i = 0; i < cMapY; i++)
            {
                for (int j = 0; j < cMapX; j++)
                {
                    if (canvasMap[i, j] == 1)
                    {
                        grph.FillRectangle(Brushes.Red, new Rectangle(j * cCell + 1, i * cCell + 1, cCell - 1, cCell - 1));
                    }
                }
            }
        }

        public void ResetArea()
        {
            for (int i = 0; i < cMapY; i++)
            {
                for (int j = 0; j < cMapX; j++)
                {
                    canvasMap[i, j] = 0;
                }
            }
        }

        public void DrawGrid(Graphics grph)
        {
            kDown = true;
            for (int i = 0; i <= cMapY; i++)
            {
                // Отрисовка горизонтальных линий
                grph.DrawLine(
                    Pens.Black, 
                    new Point(0, 0 + i * cCell), 
                    new Point(0 + cMapY * cCell, 0 + i * cCell)
                );
            }
           
            for (int j = 0; j <= cMapX; j++)
            {
                // Отрисовка вертикальных линий
                grph.DrawLine(
                    Pens.Black,
                    new Point(0 + j * cCell, 0),
                    new Point(0 + j * cCell, 0 + cMapX * cCell * (cMapY - cMapX))
                );
            }
        }

        // ======================= Events =======================

        private void pbCanvasMapPaint(object sender, PaintEventArgs e)
        {
            DrawGrid(e.Graphics);
            DrawMap(e.Graphics);
        }

        private void FormGame_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    timerDraw.Stop();
                    break;

                case Keys.Down:
                    kDown = true;
                    activeShape.Move(Tetramino.WereMove.Down);
                    break;

                case Keys.Left:
                    activeShape.Move(Tetramino.WereMove.Left);
                    break;

                case Keys.Right:
                    activeShape.Move(Tetramino.WereMove.Right);

                    break;
            }
            RepaintMap();
        }
    }
}
