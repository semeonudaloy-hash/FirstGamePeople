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
        private SPosition _position = new SPosition();
        private bool _isOpenEyes = true;
        private int _speed = 1;

        public SHealth Health { get => _health;}
        public SPosition Position { get => _position;}
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
            _position.X = x;
            _position.Y = y;
            _position.Width = 6;
            _position.Height = 4;

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
            screen.DrawString(_position.X, _position.Y - 1, " \\  / ");
            screen.DrawString(_position.X, _position.Y + 0, "/----\\");
            if (_isOpenEyes)
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

        public void Run(SDirect direct)
        {
            switch (direct)
            {
                case SDirect.Left:
                    _position.X = _position.X - _speed;
                    break;
                case SDirect.Right:
                    _position.X = _position.X + _speed;
                    break;
                case SDirect.Top:
                    _position.Y = _position.Y - _speed;
                    break;
                case SDirect.Bottom:
                    _position.Y = _position.Y + _speed;
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
 