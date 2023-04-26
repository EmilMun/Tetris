using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private int _cMapX, _cMapY;

        public Tetramino(int _x, int _y, int cMapX, int cMapY)
        {
            this._posX = _x;
            this._posY = _y;

            _cMapX = cMapX;
            _cMapY = cMapY;

            _matrixShape = cTetraminoS;
        }

        public void Move(WereMove _move)
        {
            switch (_move)
            {
                case WereMove.Down:
                    if (_posY + 3 < _cMapY)
                        _posY++;
                    break;
                
                case WereMove.Right:
                    if (_posX + 2 < _cMapX)
                        _posX++;
                    break; 
                
                case WereMove.Left:
                    if (_posX > 0)
                        _posX--;
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
