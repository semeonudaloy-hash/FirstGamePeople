using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGamePeople.Game
{
    public class SPoint
    {
        private int _x = 0;
        private int _y = 0;

        
        public int Y { get => _y; set => _y = value; }
        public int X { get => _x; set => _x = value; }

        public SPoint()
        {
            
        }
        
        public SPoint(int x, int y)
        {
            _x = x;
            _y = y;
        }

    }
}
