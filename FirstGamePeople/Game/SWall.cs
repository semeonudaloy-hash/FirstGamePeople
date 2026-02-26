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
        
        public SHealth Health { get => _health;}
        
        public SWall(int x, int y, int health) : base()
        {
            Position.Location = new SPoint(x, y);
            Position.Size = new SSize(2, 2);
            
            if (health > 0)
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
                screen.DrawString(Position.Location.X, Position.Location.Y, "XX");
                screen.DrawString(Position.Location.X, Position.Location.Y + 1, "XX");
            }
            else
            {
                screen.DrawString(Position.Location.X, Position.Location.Y, "00");
                screen.DrawString(Position.Location.X, Position.Location.Y + 1, "00");
            } 
        }
    }
}
