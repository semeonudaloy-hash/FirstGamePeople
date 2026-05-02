using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGamePeople.Game.Scenes
{
    public class SGameScene : SScene
    {
        private SCharacter _human = null;
        private SPauseBlock _pauseBlock = null;
        Random _rand = null;

        private bool _pause = false;

        public SGameScene(SGame game) : base(game) { }


        /// <summary>
        /// прорисовывает стены,прорисовывает персонажа, ставит в рандомном положении фрукты, инициализирует таймеры
        /// </summary>
        public override void Initialize()
        {
            _pause = false;
            _rand = new Random();
            _rand = new Random(_rand.Next(0, 500)); 

            Game.Timers.StartTimer("decrease_life", 50);

            for (int i = 0; i < Game.Screen.Cols / 2; i++)
            {
                new SWall(2 * i, 0, 0);
                new SWall(2 * i, Game.Screen.Rows - 2, 0);
            }
            for (int i = 0; i < (int)Game.Screen.Rows / 2; i++)
            {
                new SWall(0, 2 * i, 0);
                new SWall(Game.Screen.Cols - 2, 2 * i, 0);
            }
            for (int i = 0; i < (int)Game.Screen.Rows / 3; i++)
            {
                new SWall(33, 2 * i + 2, 0);

            }
            for (int i = 0; i < (int)Game.Screen.Rows / 3; i++)
            {
                new SWall(66, 2 * i + 9, 0);

            }

            _human = new SCharacter(15, 10, 10);
        }

        /// <summary>
        /// привязка кнопок к перемещению по сцене, прописываем ему скорость
        /// </summary>
        public override bool EventKey(ConsoleKeyInfo keyInfo)
        {
            if(keyInfo.Key == ConsoleKey.Escape)
            {
                Game.MoveToScene("Menu");
                return false;
            }

            if (_pause)
            {
                if (keyInfo.Key == ConsoleKey.Spacebar)
                {
                    _pause = false;
                    _pauseBlock.Unregister();
                    _pauseBlock = null;
                }
            }
            else
            {
                SDirect direct = SDirect.None;

                switch (keyInfo.Key)
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
                    case ConsoleKey.Spacebar:
                        _pause = true;
                        _pauseBlock = new SPauseBlock();
                        return false;
                    default:
                        return false;
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

                    if (passMove)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            if (list[j] is SFruit fruit)
                            {
                                _human?.AddHealth(fruit.Health.Health);
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

            return false;
        }


        /// <summary>
        /// привязка кнопок к перемещению по сцене, прописываем персонажу скорость,  закрываем-открываем глаза, уменьшаем и добавляем здоровье персонажу и фруктам 
        /// </summary>
        public override void Process()
        {
            if (_pause) return;

            if (Game.Timers.GetTimer("blink") == 0)
            {
                if (_human.IsOpenEyes)
                {
                    _human.CloseEyes();

                    Game.Timers.StartTimer("blink", 5);
                }
                else
                {
                    _human.OpenEyes();

                    Game.Timers.StartTimer("blink", 20);
                }
            }

            if (Game.Timers.GetTimer("decrease_life") == 0)
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

                        if (fruit.Health.Health == 0)
                        {
                            fruit.Unregister();
                        }
                    }
                    if (_human.Health.Health <= 0) //////
                    {
                        Game.MoveToScene("Over");
                        return;
                    }
                }

                Game.Timers.StartTimer("decrease_life", 50);
            }

            int countFruit = 0;
            int countHaveToFruit = 5;

            for (int i = 0; i < SRenderObject.RenderList.Count; i++)
            {
                if (SRenderObject.RenderList[i] is SFruit)
                {
                    countFruit++;
                }
            }

            if (countFruit < countHaveToFruit)
            {
                for (int i = countHaveToFruit; i > countFruit; i--)
                {
                    int isPoison = _rand.Next(0, 3) < 2 ? 1 : -1;
                    int health = _rand.Next(5, 10) * isPoison;
                    int x = 0;
                    int y = 0;

                    while (true)
                    {
                        x = _rand.Next(2, Game.Screen.Cols - 7);
                        y = _rand.Next(2, Game.Screen.Rows - 7);

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
