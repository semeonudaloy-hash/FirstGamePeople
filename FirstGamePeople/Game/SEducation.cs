using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGamePeople.Game
{
    public class SEducation : SRenderObject
    {
        private int _num = 0;

        private List<string> _education = new List<string>();

        public SEducation(List<string> text) : base()
        {
            this._education = text;
        }
        public override void Draw(SScreen screen)
        {
            int Wx = screen.Cols / 2;
            int Wy = screen.Rows / 2;

        }




    }
}
