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
        private List<SFruit> _fruits = new List<SFruit>();
        private List<SWall> _walls = new List<SWall>();

        private int _direction = 1; 
        
        public string Initialize()
        {
            _timers = new STimers();
            _screen = new SScreen(100,29);
            for (int i = 0; i < (int)_screen.Cols/2; i++)
            {
                _walls.Add(new SWall(2 * i, 0, 0));
                _walls.Add(new SWall(2 * i, _screen.Rows-2, 0));
            }
            for (int i = 0; i < (int)_screen.Rows/2; i++)
            {
                _walls.Add(new SWall(0, 2 * i, 0));
                _walls.Add(new SWall(_screen.Cols-2, 2 * i , 0));
            }
            for (int i = 0; i < (int)_screen.Rows / 3; i++)
            {
                _walls.Add(new SWall(33, 2 * i + 2, 0));
                
            }
            for (int i = 0; i < (int)_screen.Rows / 3; i++)
            {
                _walls.Add(new SWall(66, 2 * i + 9, 0));

            }

            _fruits.Add(new SFruit(4, 8, -10));
            _fruits.Add(new SFruit(90, 4, 10));

            _fruits.Add(new SFruit(4, 21, -10));
            _fruits.Add(new SFruit(90, 21, 10));

            _human = new SCharacter(15, 10, 100);
            
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
            SDirect direct = SDirect.None;
            
            switch(keyInfo.Key)
            {
                case ConsoleKey.W:
                    direct = SDirect.Top;
                    break;
                case ConsoleKey.S:
                    direct = SDirect.Bottom;
                    break;
                case ConsoleKey.A:
                    direct = SDirect.Left;
                    break;
                case ConsoleKey.D:
                    direct = SDirect.Right;
                    break;
                case ConsoleKey.E:
                    _human?.IncreaseSpeed();
                    break;
                case ConsoleKey.Q:
                    _human?.DecreaseSpeed();
                    break;
                default:
                    return;
            }

            if (_human != null)
            {
                _human.DebugText = _human.Speed.ToString();
            }

            if (direct != SDirect.None && _human != null)
            {
                int speed = _human.Speed;

                if ((direct == SDirect.Top || direct == SDirect.Bottom) && speed >= 2)
                {
                    speed = speed / 2;
                }

                for (int i = 0; i < speed; i++)
                {
                    List<SRenderObject> list = SRenderObject.CheckCollision(_human, direct, 1);

                    bool passMove = true;

                    for (int j = 0; j < list.Count; j++)
                    {
                        if (list[j] is SWall)
                        {
                            passMove = false;
                            break;
                        }
                    }

                    if(passMove)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            if (list[j] is SFruit fruit)
                            {
                                _human?.AddHealth(fruit.Health.Health);
                                _human?.EatedFruit();
                                list[j].Unregister();
                            }
                        }
                    }

                    if (passMove)
                    {
                        _human?.Run(direct, 1);
                    }
                    else
                    {
                        break;
                    }
                }
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

        }
    }
}
