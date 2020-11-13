using System;
using System.Drawing;

namespace checks
{
    class stringDraw
    {
        private Point _position;
        private int _maxWidth = Int32.MaxValue;
        private int _angle = 0;
        public string Label { get; set; }
        public string Text { get; set; }
        public string field { get; set; }
        public int fontSize { get; set; }
        public int Angle {
            get 
            {
                return _angle;
            }
            set 
            {
                if (value < -360 || value > 360)
                    throw new ArgumentException();
                else
                    _angle = value;
            }
        }
        public int MaxWidth {
            get
            {
                return _maxWidth;
            }
            set
            {
                _maxWidth = value;
                if (Bound.Width > _maxWidth)
                    Bound= new Rectangle(Bound.X,Bound.Y,_maxWidth,Bound.Height);
            }
        }
        public Point Position {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
                Bound = new Rectangle(_position, Bound.Size);
            }
        }

        public Rectangle Bound { get; set; }
        public stringDraw()
        {
            Bound = new Rectangle(Position, new Size());
        }
    }
    enum MeasureState
    {
        None = 0,
        FirstPoint = 1,
        SecondPoint = 2,
        End = 3,
    }
}
