using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGamePeople.Game
{
    public enum SDirect
    {
        Left,
        Right, 
        Top,
        Bottom
    }

    public class SCharacter : SRenderObject
    {

        private SHealth _health = new SHealth();
        private bool _isOpenEyes = true;
        private int _speed = 1;

        public SHealth Health { get => _health;}
        public bool IsOpenEyes { get => _isOpenEyes;}
        public int Speed
        {
            get => _speed;
            set
            {
                if(value <= 10 && value >= 1)
                    _speed = value;
            }
        }

        public SCharacter(int x, int y, int health) : base()
        {
            Position.Location = new SPoint(x, y);
            Position.Size = new SSize(6, 4);
           
            if (health > 0)
            {
                _health.Health = health;
            }
            else // <=0
            {
                _health.Health = 100;
            }
        }

        public override void Draw(SScreen screen)
        {
            //screen.DrawString(_position.X, _position.Y - 2, _speed.ToString());
            screen.DrawString(Position.Location.X, Position.Location.Y - 1, " \\  / ");
            screen.DrawString(Position.Location.X, Position.Location.Y + 0, "/----\\");
            if (_isOpenEyes)
            {
                screen.DrawString(Position.Location.X, Position.Location.Y + 1, "|0  0|");
            }
            else
            {
                screen.DrawString(Position.Location.X, Position.Location.Y + 1, "|-  -|");
            }
     
            screen.DrawString(Position.Location.X, Position.Location.Y + 2, "| -- |");
            screen.DrawString(Position.Location.X, Position.Location.Y + 3, "\\____/");
        }

        public void Run(SDirect direct)
        {
            switch (direct)
            {
                case SDirect.Left:
                    Position.Location.X = Position.Location.X - _speed;
                    break;
                case SDirect.Right:
                    Position.Location.X = Position.Location.X + _speed;
                    break;
                case SDirect.Top:
                    Position.Location.Y = Position.Location.Y - _speed;
                    break;
                case SDirect.Bottom:
                    Position.Location.Y = Position.Location.Y + _speed;
                    break;
            }
        }

        public void RunLeft()
        {
            Run(SDirect.Left);
        }

        public void RunRight()
        {
            Run(SDirect.Right);
        }

        public void RunTop()
        {
            Run(SDirect.Top);
        }

        public void RunBottom()
        {
            Run(SDirect.Bottom);
        }

        public void IncreaseSpeed()
        {
            Speed++;
        }

        public void DecreaseSpeed()
        {
            Speed--;  
        }

        public void OpenEyes()
        {
            _isOpenEyes = true;
        }

        public void CloseEyes()
        {
            _isOpenEyes = false;
        }
    }
}
 