using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGamePeople.Game
{
    /// <summary>
    /// интервалы между кадрами, сбросы таймеров
    /// </summary>
    public class STimers
    {
        private Dictionary<string,int> _timers = new Dictionary<string,int>();
        
        private bool _pause = false;

        public bool Pause { get => _pause; set => _pause = value; }

        public bool StartTimer(string name, int val) //то есть в параметрах нашего метода мы указываем название и скорость
                                                     // с которой будет происходить действие
        {
            //проверяет содержит ли ключ 
            if (_timers.ContainsKey(name))
            {
                int currentValue = _timers[name]; // почему значение name мы пытаемся запихнуть в currentValue??, и если я 
                                                  //правильно понял то тут мы просто переносим наше число в другую перменную
                if (currentValue > 0)
                {
                    return false;
                }
                else
                {
                    _timers[name] = val;//???
                    return true;
                }
            }
            else
            {
                _timers.Add(name,val);
                return true;
            }
        }
        
        //возможность сброса
        public bool ResetTimer(string name)
        {
            if(_timers.ContainsKey(name))
            {
                _timers[name] = 0;
                return true;
            }
            else
            {
                return false;
            }
        }
        
        // получение текущего значения таймера, нужно указать произвольное название
        public int GetTimer(string name)
        {
            if (_timers.ContainsKey(name))
            {
                int value = _timers[name];
                
                return value;
            }
            else
            {
                return 0;
            }
        }

        
        /// <summary>
        ///  процедура пересчета таймеров
        /// </summary>
        public void Tick()
        {
            if (_pause) return; // завершается метод до следующего прогона цикла в гейме по этому методу?????
            
            var keys = _timers.Keys.ToArray(); //касательно keys не очень ясно и  ToArray

            for (int i = 0; i < keys.Length; i++)
            {
                string name = keys[i]; // что это вообще тут происходит

                int value = _timers[name];

                if(value > 0)
                {
                    value--;
                    _timers[name] = value;
                }
                else
                {
                    _timers[name] = 0;
                }

            }

        }
        /// <summary>
        /// чистит именно один объект _timers
        /// </summary>
        public void ResetAllTimers()
        { 
            _timers.Clear();
        }
    }
}
