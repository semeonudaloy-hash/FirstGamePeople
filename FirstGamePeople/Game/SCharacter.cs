using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGamePeople.Game
{
    public class SCharacter : SRenderObject
    {

        private SHealth _health = new SHealth();
        private SPosition _position = new SPosition();
        private bool _openEyes = true;

        public SHealth Health { get => _health;}
        public SPosition Position { get => _position;}
        public bool OpenEyes { get => _openEyes; set => _openEyes = value; }

        public SCharacter(int x, int y, int health)
        {
          
            _position.X = x;
            _position.Y = y;
            _position.Width = 6;
            _position.Height = 4;

            if (health > 0)
            {
                _health.Health = health;
            }
            else //<=0
            {
                _health.Health = 100;
            }
        }

        public override void Draw(SScreen screen)
        {
            screen.DrawString(_position.X, _position.Y + 0, "/----\\");
            if (_openEyes)
            {
                screen.DrawString(_position.X, _position.Y + 1, "|0  0|");
            }
            else
            {
                screen.DrawString(_position.X, _position.Y + 1, "|-  -|");
            }
     
            screen.DrawString(_position.X, _position.Y + 2, "| -- |");
            screen.DrawString(_position.X, _position.Y + 3, "\\____/");
        }
    }
}
 