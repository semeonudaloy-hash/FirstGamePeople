using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGamePeople.Game
{
    public class SMenu : SRenderObject
    {
        private List<string> _items = new List<string>();
        private int _selectedIndex = 0;
        private string _cadr = "/|\\-";
        private int _currentCadr = 0;

        public SMenu(List<string> items, int selectedIndex) : base()
        {
            _items = items;
            _selectedIndex = selectedIndex;
        }

        public int SelectedIndex { get => _selectedIndex; }

        public override void Draw(SScreen screen)
        {
            int width = 50;
            int height = _items.Count*3;

            Position.Location.X = screen.Cols/2-width/2;
            Position.Location.Y = screen.Rows / 2 - height / 2 + 3;
            
            screen.DrawString(Position.Location.X-2, Position.Location.Y-9, "00000    0     0     0    0    00000  000  0   0 0   0");
            screen.DrawString(Position.Location.X-2, Position.Location.Y-8, "  0     0 0    00   00   0 0   0     0   0 0   0 0  00");
            screen.DrawString(Position.Location.X-2, Position.Location.Y-7, "  0    0   0   0 0 0 0  0   0  0     0   0 00000 0 0 0");
            screen.DrawString(Position.Location.X-2, Position.Location.Y-6, "  0   0000000  0  0  0 0000000 0     0   0     0 00  0");
            screen.DrawString(Position.Location.X-2, Position.Location.Y-5, "  0   0     0  0     0 0     0 0      000      0 0   0");

            for (int i = 0; i < _items.Count; i++)
            {
                if(i == _selectedIndex)
                {
                    screen.DrawString(Position.Location.X, Position.Location.Y + 3*i + 0, " /==============================================\\ ");
                    screen.DrawString(Position.Location.X, Position.Location.Y + 3*i + 1, $"{_cadr[_currentCadr]}                                                {_cadr[_currentCadr]}  ");
                    screen.DrawString(Position.Location.X, Position.Location.Y + 3*i + 2, " \\==============================================/ ");
                }

                screen.DrawString(Position.Location.X + width / 2 - _items[i].Length/2, Position.Location.Y + 3 * i + 1, _items[i]);
            }
        }

        public void NextItem()
        {
            if (_selectedIndex < _items.Count - 1)
            {
                _selectedIndex++;
            }
        }

        public void PreviousItem()
        {
            if (_selectedIndex > 0)
            {
                _selectedIndex--;
            }

        }

        public void NextCadr()
        {
            _currentCadr++;

            if(_currentCadr >= _cadr.Length)
            {
                _currentCadr = 0;
            }
        }
    }
}
