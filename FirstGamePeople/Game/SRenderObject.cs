using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGamePeople.Game
{
    public class SRenderObject
    {
        private static List<SRenderObject> _renderList = new List<SRenderObject>();

        public static List<SRenderObject> RenderList
        {
            get
            {
                return _renderList;
            }
        }

        public virtual void Draw(SScreen screen)
        {

        }

        public SRenderObject()
        {
            _renderList.Add(this);
        }

        public void Unregister()
        {
            _renderList.Remove(this);
        }
    }
}
