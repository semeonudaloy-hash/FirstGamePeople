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

        public bool StartTimer(string name, int val)
        {
            //проверяет содержит ли ключ 
            if (_timers.ContainsKey(name))
            {
                int currentValue = _timers[name];

                if(currentValue > 0)
                {
                    return false;
                }
                else
                {
                    _timers[name] = val;
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
            if (_pause) return;
            
            var keys = _timers.Keys.ToArray();

            for (int i = 0; i < keys.Length; i++)
            {
                string name = keys[i];

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
