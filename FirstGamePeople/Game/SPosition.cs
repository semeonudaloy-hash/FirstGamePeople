using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGamePeople.Game
{
    public class SPosition
    {
        private int _x = 0;
        private int _y = 0;
        private int _width = 0;
        private int _height = 0;

        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }
    }
}
