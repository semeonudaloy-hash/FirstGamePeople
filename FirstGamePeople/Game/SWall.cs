using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGamePeople.Game
{
    public class SWall : SRenderObject
    {
        private SHealth _health = new SHealth();
        private SPosition _position = new SPosition();

        public SHealth Health { get => _health;}
        public SPosition Position { get => _position;}
        public SWall(int x, int y, int health) 
        {
            _position.X = x;
            _position.Y = y;
            _position.Width = 2;
            _position.Height = 2;

            if(health > 0)
            { 
                _health.Health = 0;
            }
            else
            {
                _health.Health = health; 
            }
        }
        public override void Draw(SScreen screen)
        {
            //string str = "00";

            //if(_health.Health < 0)
            //{
            //    str = "XX";
            //}

            //for(int i = 0;i<2;i++)
            //{
            //    screen.DrawString(_position.X, _position.Y + i, str);
            //}

            if (_health.Health < 0)
            {
                screen.DrawString(_position.X, _position.Y, "XX");
                screen.DrawString(_position.X, _position.Y + 1, "XX");
            }
            else
            {
                screen.DrawString(_position.X, _position.Y, "00");
                screen.DrawString(_position.X, _position.Y + 1, "00");
            } 
        }
    }
}
