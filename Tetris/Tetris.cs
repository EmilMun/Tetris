using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class FormGame : Form
    {
        const int cMapX = 24, cMapY = 16, cCell = 25;

        int[,] canvasMap = new int[cMapX, cMapY];

        bool flag = false;

        Tetramino activeShape;

        public FormGame()
        {
            InitializeComponent();
            Init0();
        }

        public void Init0()
        {
            activeShape = new Tetramino(3, 0);

            timerDraw.Interval = 500;
            timerDraw.Tick += new EventHandler(timer_Tick);
            timerDraw.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ResetArea();

            activeShape.Move(Tetramino.WereMove.Down);

            SynchCanvasMapAndShape();

            pbCanvasMap.Invalidate();
        }
        public void SynchCanvasMapAndShape()
        {
            for (int i = 0; i < 3; i++) 
            { 
                for(int j = 0; j < 2; j++)
                {
                    canvasMap[i + activeShape.posY, j + activeShape.posX] = activeShape.matrixShape[i, j];
                }
            }
        }

        private void pbCanvasMapPaint(object sender, PaintEventArgs e)
        {
            DrawGrid(e.Graphics);
            DrawMap(e.Graphics);
        }

        public void DrawMap(Graphics grph)
        {
            for(int i = 0; i < cMapX; i++)
            {
                for (int j = 0; j < cMapY; j++)
                {
                    if (canvasMap[i, j] == 1)
                    {
                        grph.FillRectangle(Brushes.Red, new Rectangle(50 + j * cCell + 1, 50 + i * cCell + 1, cCell - 1, cCell - 1));
                    }
                }
            }
        }

        public void ResetArea()
        {
            for (int i = 0; i < cMapX; i++)
            {
                for (int j = 0; j < cMapY; j++)
                {
                    canvasMap[i, j] = 0;
                }
            }
        }

        public void DrawGrid(Graphics grph)
        {
            for(int i = 0; i <= cMapX; i++)
            {
                // Отрисовка горизонтальных линий
                grph.DrawLine(
                    Pens.Black, 
                    new Point(0, 0 + i * cCell), 
                    new Point(0 + cMapX * cCell, 0 + i * cCell)
                );
            }
           
            for (int j = 0; j <= cMapY; j++)
            {
                // Отрисовка вертикальных линий
                grph.DrawLine(
                    Pens.Black,
                    new Point(0 + j * cCell, 0),
                    new Point(0 + j * cCell, 0 + cMapY * cCell * (cMapX - cMapY))
                );
            }
        }

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams handleParam = base.CreateParams;
        //        handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
        //        return handleParam;
        //    }
        //}
    }
}
