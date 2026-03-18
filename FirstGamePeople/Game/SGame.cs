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
        Random _rand = null;

        private int _direction = 1; 
        
        public string Initialize()
        {
            _rand = new Random();
            _rand = new Random(_rand.Next(0, 500));

            _timers = new STimers();
            _timers.StartTimer("decrease_life", 50);

            _screen = new SScreen(100,29);
            for (int i = 0; i < (int)_screen.Cols/2; i++)
            {
                new SWall(2 * i, 0, 0);
                new SWall(2 * i, _screen.Rows-2, 0);
            }
            for (int i = 0; i < (int)_screen.Rows/2; i++)
            {
                new SWall(0, 2 * i, 0);
                new SWall(_screen.Cols-2, 2 * i , 0);
            }
            for (int i = 0; i < (int)_screen.Rows / 3; i++)
            {
                new SWall(33, 2 * i + 2, 0);
                
            }
            for (int i = 0; i < (int)_screen.Rows / 3; i++)
            {
                new SWall(66, 2 * i + 9, 0);

            }

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

                    if (keyInfo.Key == ConsoleKey.Escape)
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
                default:
                    return;
            }

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

            if (_timers.GetTimer("decrease_life") == 0)
            {
                for (int i = 0; i < SRenderObject.RenderList.Count; i++)
                {
                    var item = SRenderObject.RenderList[i];

                    if (item is SCharacter character)
                    {
                        character.Health.Health--;
                    }

                    if (item is SFruit fruit)
                    {
                        if (fruit.Health.Health > 0)
                        {
                            fruit.Health.Health--;
                        }

                        if (fruit.Health.Health < 0)
                        {
                            fruit.Health.Health++;
                        }

                        if(fruit.Health.Health == 0)
                        {
                            fruit.Unregister();
                        }
                    }
                }

                _timers.StartTimer("decrease_life", 50);
            }

            int countFruit = 0;
            int countHaveToFruit = 4;

            for (int i = 0; i < SRenderObject.RenderList.Count; i++)
            {
                if (SRenderObject.RenderList[i] is SFruit)
                {
                    countFruit++;
                }
            }

            if(countFruit <  countHaveToFruit)
            {
                for(int i = countHaveToFruit; i > countFruit;i--)
                {
                    int isPoison = _rand.Next(0, 3) < 2 ? 1 : -1;
                    int health = _rand.Next(5,11) * isPoison;
                    int x = 0;
                    int y = 0;

                    while (true)
                    {
                        x = _rand.Next(2, _screen.Cols - 7);
                        y = _rand.Next(2, _screen.Rows - 7);

                        SPosition fruitRect = new SPosition()
                        {
                            Location = new SPoint(x, y),
                            Size = new SSize(5, 5),
                        };

                        bool noIntersect = true;

                        for (int j = 0; j < SRenderObject.RenderList.Count; j++)
                        {
                            if (SRenderObject.RenderList[j].Position.IntersectRect(fruitRect))
                            {
                                noIntersect = false;
                                break;
                            }
                        }

                        if (noIntersect)
                        {
                            break;
                        }
                    }

                    SFruit fruit = new SFruit(x, y, health);
                }
            }
        }
    }
}
