using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGamePeople.Game
{
    public class SOver : SRenderObject
    {

        private List<string> _items = new List<string>();
        private int _selectedIndex = 0;
        public SOver(List<string> items, int selectedIndex) : base()
        {
            _items = items;
            _selectedIndex = selectedIndex;
        }
    }
}
