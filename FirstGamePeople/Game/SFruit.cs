using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGamePeople.Game
{
    public class SFruit : SRenderObject
    {
        private SHealth _health = new SHealth();
        private SPosition _position = new SPosition();

        public SHealth Health { get => _health; set => _health = value; }
        public SPosition Position { get => _position; set => _position = value; }

        public SFruit(int x, int y, int health) : base()
        {
            _position.X = x;
            _position.Y = y;
            _position.Width = 5;
            _position.Height = 5;

            _health.Health = health;
        }
       

        public override void Draw(SScreen screen)
        {
            if (_health.Health > 0)
            {
                screen.DrawString(_position.X, _position.Y + 0, "  ^  ");
                screen.DrawString(_position.X, _position.Y + 1, " /.\\");
                screen.DrawString(_position.X, _position.Y + 2, "/...\\");
                screen.DrawString(_position.X, _position.Y + 3, "\\___/");
                screen.DrawString(_position.X, _position.Y + 4, "  /  ");
            }
            else
            {
                screen.DrawString(_position.X, _position.Y + 0, "  /  ");
                screen.DrawString(_position.X, _position.Y + 1, "<^^^>");
                screen.DrawString(_position.X, _position.Y + 2, "<^^^>");
                screen.DrawString(_position.X, _position.Y + 3, "<^^^>");
                screen.DrawString(_position.X, _position.Y + 4, "<___>");
            }
                

        }
        
    }
}
