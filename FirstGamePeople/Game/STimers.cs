using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGamePeople.Game
{
    public class STimers
    {
        private Dictionary<string,int> _timers = new Dictionary<string,int>();
        
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
        
        public void Tick()
        {
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
    }
}
