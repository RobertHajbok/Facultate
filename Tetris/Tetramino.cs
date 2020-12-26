using System;
using System.Windows;
using System.Windows.Media;

namespace Tetris
{
    public class Tetramino
    {
        private Point _currentPosition;
        private readonly Point[] _currentShape;
        private Brush _currentColor;
        private bool _rotate;

        public Tetramino()
        {
            _currentPosition = new Point(0, 0);
            _currentColor = Brushes.Transparent;
            _currentShape = SetRandomShape();
        }

        public Brush GetCurrentColor()
        {
            return _currentColor;
        }

        public Point GetCurrentPosition()
        {
            return _currentPosition;
        }

        public Point[] GetCurrentShape()
        {
            return _currentShape;
        }

        public void MoveLeft()
        {
            _currentPosition.X -= 1;
        }

        public void MoveRight()
        {
            _currentPosition.X += 1;
        }

        public void MoveDown()
        {
            _currentPosition.Y += 1;
        }

        public void MoveUp()
        {
            _currentPosition.Y -= 1;
        }

        public void Rotate()
        {
            if (!_rotate) return;
            for (var i = 0; i < _currentShape.Length; i++)
            {
                var x = _currentShape[i].X;
                _currentShape[i].X = _currentShape[i].Y * -1;
                _currentShape[i].Y = x;
            }
        }

        private Point[] SetRandomShape()
        {
            var rand = new Random();
            switch (rand.Next()%7)
            {
                case 0: //I
                    _rotate = true;
                    _currentColor = Brushes.Cyan;
                    return new[] {new Point(0, 0), new Point(-1, 0), new Point(1, 0), new Point(2, 0)};
                case 1: //J
                    _rotate = true;
                    _currentColor = Brushes.Blue;
                    return new[] { new Point(1, 1), new Point(-1, 0), new Point(0, 0), new Point(1, 0) };
                case 2: //L
                    _rotate = true;
                    _currentColor = Brushes.Orange;
                    return new[] { new Point(0, 0), new Point(-1, 0), new Point(1, 0), new Point(1, -1) };
                case 3: //O
                    _rotate = false;
                    _currentColor = Brushes.Yellow;
                    return new[] { new Point(0, 0), new Point(0, 1), new Point(1, 0), new Point(1, 1) };
                case 4: //S
                    _rotate = true;
                    _currentColor = Brushes.Green;
                    return new[] { new Point(0, 0), new Point(-1, 0), new Point(0, -1), new Point(1, 0) };
                case 5: //T
                    _rotate = true;
                    _currentColor = Brushes.Purple;
                    return new[] { new Point(0, 0), new Point(-1, 0), new Point(0, -1), new Point(1, -1) };
                case 6: //Z
                    _rotate = true;
                    _currentColor = Brushes.Red;
                    return new[] { new Point(0, 0), new Point(-1, 0), new Point(0, 1), new Point(1, 1) };
                default:
                    return null;
            }
        }
    }
}