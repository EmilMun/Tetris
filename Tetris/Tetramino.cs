using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class Tetramino
    {
        public enum WereMove { Down, Right, Left};

        private readonly int[,] cTetraminoS = 
        { 
            { 1, 0 }, 
            { 1, 1 }, 
            { 0, 1 } 
        };

        private int _posX;
        private int _posY;
        private int[,] _matrixShape;

        public Tetramino(int _x, int _y)
        {
            this._posX = _x;
            this._posY = _y;

            _matrixShape = cTetraminoS;
        }

        public void Move(WereMove _move)
        {
            switch (_move)
            {
                case WereMove.Down:
                    _posY++;
                    break;
                
                case WereMove.Right:
                    _posX++;
                    break; 
                
                case WereMove.Left:
                    _posY--;
                    break;

                default:

                    break;
            }
        }
        public int posX
        {
            get { return _posX; }
            set { _posX = value; }
        }
        public int posY
        {
            get { return _posY; }
            set { _posY = value; }
        }
        public int[,] matrixShape 
        { 
            get { return _matrixShape; } 
        } 
    }
}
