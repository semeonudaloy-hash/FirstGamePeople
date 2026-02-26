using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FirstGamePeople.Game
{
    public class SFruit : SRenderObject
    {
        private SHealth _health = new SHealth();
        
        public SHealth Health { get => _health; set => _health = value; }
        
        public SFruit(int x, int y, int health) : base()
        {
            Position.Location = new SPoint(x, y);
            Position.Size = new SSize(5, 5);
            _health.Health = health;
        }
       

        public override void Draw(SScreen screen)
        {
            if (_health.Health > 0)
            {
                screen.DrawString(Position.Location.X, Position.Location.Y + 0, "  ^  ");
                screen.DrawString(Position.Location.X, Position.Location.Y + 1, " /.\\");
                screen.DrawString(Position.Location.X, Position.Location.Y + 2, "/...\\");
                screen.DrawString(Position.Location.X, Position.Location.Y + 3, "\\___/");
                screen.DrawString(Position.Location.X, Position.Location.Y + 4, "  /  ");
            }
            else
            {
                screen.DrawString(Position.Location.X, Position.Location.Y + 0, "  /  ");
                screen.DrawString(Position.Location.X, Position.Location.Y + 1, "<^^^>");
                screen.DrawString(Position.Location.X, Position.Location.Y + 2, "<^^^>");
                screen.DrawString(Position.Location.X, Position.Location.Y + 3, "<^^^>");
                screen.DrawString(Position.Location.X, Position.Location.Y + 4, "<___>");
            }
        }
    }
}
