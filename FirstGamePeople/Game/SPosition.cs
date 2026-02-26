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
                new SPoint(_location.X + _size.Width,_location.Y),
                new SPoint(_location.X + _size.Width,_location.Y + _size.Height),
                new SPoint(_location.X, _location.Y + _size.Height),
            };
        }

    }
}
