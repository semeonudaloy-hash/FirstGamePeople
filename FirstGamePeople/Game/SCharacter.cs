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

        public SHealth Health { get => _health;}
        public SPosition Position { get => _position;}
        
        public SCharacter(int x, int y, int health)
        {
            _position.X = x;
            _position.Y = y;
            _position.Width = 6;
            _position.Height = 4;
            _health.Health = health;
        }

        public override void Draw(SScreen screen)
        {
            screen.DrawString(10, 3, "/----\\");
            screen.DrawString(10, 4, "|0  0|");
            screen.DrawString(10, 5, "| -- |");
            screen.DrawString(10, 6, "\\____/");

        }
    }
}
 