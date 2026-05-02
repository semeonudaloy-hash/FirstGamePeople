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
        Bottom,
        None
    }

    public class SCharacter : SRenderObject
    {
        private SHealth _health = new SHealth();
        private bool _isOpenEyes = true;
        private bool _havetable = true;
        private string _debugText = "";
        private int _speed = 5;
        private int _eatingFruit = 0;

        public SHealth Health { get => _health;}
        public bool Havetable { get => _havetable;}
        public bool IsOpenEyes { get => _isOpenEyes;}
        public string DebugText { get => _debugText; set => _debugText = value; }
        public int Speed { get => _speed;}
        public int EatingFruit { get => _eatingFruit;}

        public SCharacter(int x, int y, int health ) : base()
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
        
        public void EatedFruit()
        {
            _eatingFruit++;
            
        }

        public void AddHealth(int health)
        {
            _health.Health += health;
        }

        public override void Draw(SScreen screen)
        {
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
            if(_havetable)
            {
                screen.DrawString(0, 0, $"=============================");
                screen.DrawString(0, 1, $"#                           #");
                screen.DrawString(0, 2, $"#                           #");
                screen.DrawString(0, 3, $"#                           #");
                screen.DrawString(0, 4, $"#                           #");
                screen.DrawString(0, 5, $"=============================");
                screen.DrawString(3, 2, $"Количество фруктов - {_eatingFruit}");

                screen.DrawString(3, 3, $"Количество жизни   - {_health.Health}");
            }
           
           

        }

        public void Run(SDirect direct, int move)
        {
            switch (direct)
            {
                case SDirect.Left:
                    Position.Location.X = Position.Location.X - move;
                    break;
                case SDirect.Right:
                    Position.Location.X = Position.Location.X + move;
                    break;
                case SDirect.Top:
                    Position.Location.Y = Position.Location.Y - move;
                    break;
                case SDirect.Bottom:
                    Position.Location.Y = Position.Location.Y + move;
                    break;
            }
        }

        public void OpenEyes()
        {
            _isOpenEyes = true;
        }

        public void CloseEyes()
        {
            _isOpenEyes = false;
        }

        public void IncreaseSpeed()
        {
            if(_speed < 10)
                _speed++;
        }
        public void DecreaseSpeed()
        {
            if (_speed > 1)
                _speed--;
        }
        public void SeeTable()
        {
            _havetable = true;
        }
        public void NotSeeTable()
        {
            _havetable = false;
        }
        public void RandomPosition()
        {
            
            Random rand1 = new Random();
            int xRandom = rand1.Next(0, 100);
            Random rand2 = new Random();
            int yRamdom = rand2.Next(0, 29);
            Position.Location = new SPoint(xRandom, yRamdom);
        }
        
    }
}
 