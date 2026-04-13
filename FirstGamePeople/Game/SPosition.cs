using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGamePeople.Game
{
    public class SPosition
    {
        private SPoint _location = new SPoint();

        private SSize _size = new SSize();

        public SPoint Location { get => _location; set => _location = value; }
        public SSize Size { get => _size; set => _size = value; }

        /// <summary>
        /// пересекающиеся поинты
        /// </summary>
        private bool IntersectPoint(SPoint point)
        {
            if(point.X >= _location.X && 
                point.X < _location.X + _size.Width &&
                point.Y >= _location.Y &&
                point.Y < _location.Y + _size.Height)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// пересекающиеся прямо
        /// </summary>
        public bool IntersectRect(SPosition position)
        {
            List<SPoint> points = position.GetAllVertex();
            for (int i = 0; i < points.Count; i++)
            {
                SPoint point = points[i];
                bool tmp = IntersectPoint(point);
                if(tmp)
                {
                    return true;
                }
                
            }

            points = position.GetAllVertex();
            for (int i = 0; i < points.Count; i++)
            {
                SPoint point = points[i];
                bool tmp = IntersectPoint(point);
                if (tmp)
                {
                    return true;
                }

            }

            return false;
        }

        private List<SPoint> GetAllVertex()
        {
            return new List<SPoint>() 
            {
                new SPoint(_location.X,_location.Y),
                new SPoint(_location.X + _size.Width - 1,_location.Y),
                new SPoint(_location.X + _size.Width - 1,_location.Y + _size.Height - 1),
                new SPoint(_location.X, _location.Y + _size.Height - 1),
            };
        }

        /// <summary>
        /// получаем движение по прямой
        /// </summary>
        public SPosition GetMoveRect(SDirect direct,int move)
        {
            SPosition res = null;

            switch(direct)
            {
                case SDirect.Left:
                    res = new SPosition()
                    {
                        Location = new SPoint(_location.X - move, _location.Y),
                        Size = new SSize(_size.Width + move, _size.Height),
                    };
                    break;
                case SDirect.Right:
                    res = new SPosition()
                    {
                        Location = new SPoint(_location.X, _location.Y),
                        Size = new SSize(_size.Width + move, _size.Height),
                    };
                    break;
                case SDirect.Top:
                    res = new SPosition()
                    {
                        Location = new SPoint(_location.X, _location.Y - move),
                        Size = new SSize(_size.Width, _size.Height + move),
                    };
                    break;
                case SDirect.Bottom:
                    res = new SPosition()
                    {
                        Location = new SPoint(_location.X, _location.Y),
                        Size = new SSize(_size.Width, _size.Height + move),
                    };
                    break;
            }

            return res;
        }

    }
}
