using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FirstGamePeople.Game
{
    public class SGame
    {
        private SScreen _screen = null;
        private STimers _timers = null;
        private SCharacter _human = null;
        private SCharacter _human1 = null;
        private SCharacter _human2 = null;
        private List<SFruit> _fruits = new List<SFruit>();
        private List<SWall> _walls = new List<SWall>();

        private int _direction = 1; 
        
        public string Initialize()
        {
            _timers = new STimers();
            _screen = new SScreen(100, 29);
            //_walls.Add(new SWall(1, 1, 10));
            //_walls.Add(new SWall(5, 5, 0));
            //_walls.Add(new SWall(10, 10, -10));
            //_walls.Add(new SWall(15, 15, -20));
            //_fruits.Add(new SFruit(40, 10, -10));
            //_fruits.Add(new SFruit(50, 10, 10));
            //_fruits.Add(new SFruit(40, 20, 10));
            //_fruits.Add(new SFruit(50, 20, -10));
            _human = new SCharacter(20, 10, 100);
            _human1 = new SCharacter(10, 10, 100);
            _human2 = new SCharacter(30, 10, 100);
            return "";
        }

        public void Start()
        {
            ConsoleKeyInfo keyInfo;

           
            while (true)
            {
                //Опрос клавиатуры и реакция на нажатые клавиши
                if (Console.KeyAvailable)
                {
                    keyInfo = Console.ReadKey(true);

                    while (Console.KeyAvailable)
                    {
                        keyInfo = Console.ReadKey(true);
                    }

                    if(keyInfo.Key == ConsoleKey.Escape)
                    {
                        break;
                    }

                    EventKey(keyInfo);
                }

                Process();
                

                //отрисовка всех игровых объектов
                _screen.Clear();
                for (int i = 0; i < SRenderObject.RenderList.Count; i++)
                {
                    SRenderObject.RenderList[i].Draw(_screen);
                }
                _screen.Draw();

                _timers.Tick();

                Thread.Sleep(20);
            }

            Console.Clear();

            Console.WriteLine("Good bye!!!");
        }

        public void EventKey(ConsoleKeyInfo keyInfo)
        {
            //////////////////////////
            if (keyInfo.Key == ConsoleKey.W)
            {
                _human?.RunTop();
            }
            if (keyInfo.Key == ConsoleKey.S)
            {
                _human?.RunBottom();
            }
            if (keyInfo.Key == ConsoleKey.D)
            {
                _human?.RunRight();
            }
            if (keyInfo.Key == ConsoleKey.A)
            {
                _human?.RunLeft();
            }
            if (keyInfo.Key == ConsoleKey.E)
            {
                _human?.IncreaseSpeed();
            }
            if (keyInfo.Key == ConsoleKey.Q)
            {
                _human?.DecreaseSpeed();
            }
            if (keyInfo.Key == ConsoleKey.P)
            {
                for (int i = 0; i < SRenderObject.RenderList.Count; i++)
                {
                    if (SRenderObject.RenderList[i] is SCharacter)
                    {
                        SRenderObject.RenderList[i].Unregister();
                        _human = null;
                        break;
                    }
                }
            }
            if (keyInfo.Key == ConsoleKey.N)
            {
                if(_human == null)
                    _human = new SCharacter(1, 1, 100);
            }
        }

        public void Process()
        {
            if(_timers.GetTimer("blink") == 0)
            {
                if(_human.IsOpenEyes)
                {
                    _human.CloseEyes();

                    _timers.StartTimer("blink", 5);
                }
                else
                {
                    _human.OpenEyes();

                    _timers.StartTimer("blink", 20);
                }
            }

            if (_timers.GetTimer("blink1") == 0)
            {
                if (_human1.IsOpenEyes)
                {
                    _human1.CloseEyes();

                    _timers.StartTimer("blink1", 10);
                }
                else
                {
                    _human1.OpenEyes();

                    _timers.StartTimer("blink1", 40);
                }
            }

            if (_timers.GetTimer("blink2") == 0)
            {
                if (_human2.IsOpenEyes)
                {
                    _human2.CloseEyes();

                    _timers.StartTimer("blink2", 5);
                }
                else
                {
                    _human2.OpenEyes();

                    _timers.StartTimer("blink2", 5);
                }
            }



            if (_timers.GetTimer("walk") == 0)
            {
                _timers.StartTimer("walk", 10);

                if(_human.Position.Y <= 0)
                {
                    _direction = 1;
                }
                if(_human.Position.Y > 24)
                {
                    _direction = -1;
                }

                _human.Position.Y = _human.Position.Y + _direction;
            }
        }
    }
}
