using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGamePeople.Game
{
    public class SSize
    {
        private int _width = 0;
        private int _height = 0;

        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }

        public SSize()
        {
        }
        
        public SSize(int width, int height)
        {
            _width = width;
            _height = height;
        }
    }
}
