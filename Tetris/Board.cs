using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Tetris
{
    public class Board
    {
        private readonly int _rows;
        private readonly int _cols;
        private readonly int _speed;
        private int _score;
        private int _linesFilled;
        private Tetramino _currentTetramino;
        private readonly Label[,] _blockControls;

        static private readonly Brush NoBrush = Brushes.Transparent;
        static private readonly Brush GrayBrush = Brushes.Gray;

        public Board(Grid tetrisGrid, int speed)
        {
            _rows = tetrisGrid.RowDefinitions.Count;
            _cols = tetrisGrid.ColumnDefinitions.Count;
            _score = 0;
            _linesFilled = 0;
            _speed = speed;

            _blockControls = new Label[_cols, _rows];
            for (var i = 0; i < _cols; i++)
            {
                for (var j = 0; j < _rows; j++)
                {
                    _blockControls[i, j] = new Label
                    {
                        Background = NoBrush,
                        BorderBrush = GrayBrush,
                        BorderThickness = new Thickness(1, 1, 1, 1)
                    };
                    Grid.SetRow(_blockControls[i, j], j);
                    Grid.SetColumn(_blockControls[i, j], i);
                    tetrisGrid.Children.Add(_blockControls[i, j]);
                }
            }

            _currentTetramino = new Tetramino();
            CurrentTetraminoDraw();
        }

        public int GetScore()
        {
            return _score;
        }

        public int GetLines()
        {
            return _linesFilled;
        }

        private void CurrentTetraminoDraw()
        {
            var position = _currentTetramino.GetCurrentPosition();
            var shape = _currentTetramino.GetCurrentShape();
            var color = _currentTetramino.GetCurrentColor();

            foreach (var point in shape)
            {
                _blockControls[(int) (point.X + position.X) + ((_cols/2) - 1), (int) (point.Y + position.Y) + 2]
                    .Background = color;
            }
        }

        private void CurrentTetraminoErase()
        {
            var position = _currentTetramino.GetCurrentPosition();
            var shape = _currentTetramino.GetCurrentShape();

            foreach (var point in shape)
            {
                _blockControls[(int)(point.X + position.X) + ((_cols / 2) - 1), (int)(point.Y + position.Y) + 2]
                    .Background = NoBrush;
            }
        }

        private void CheckRows()
        {
            for (var i = _rows - 1; i > 0; i--)
            {
                var full = true;
                for (var j = 0; j < _cols; j++)
                {
                    if (Equals(_blockControls[j, i].Background, NoBrush))
                    {
                        full = false;
                    }
                }

                if (i < 3)
                {
                    for (var j = 0; j < _cols; j++)
                    {
                        if (Equals(_blockControls[j, i].Background, NoBrush)) continue;
                        full = true;
                        break;
                    }
                }

                if (!full) continue;
                RemoveRows(i);
                i++;
                switch (_speed)
                {
                    case 1:
                        _score += 10;
                        break;
                    case 2:
                        _score += 20;
                        break;
                    case 3:
                        _score += 30;
                        break;
                    case 4:
                        _score += 40;
                        break;
                    case 5:
                        _score += 50;
                        break;
                    case 6:
                        _score += 60;
                        break;
                    case 7:
                        _score += 70;
                        break;
                    case 8:
                        _score += 80;
                        break;
                    case 9:
                        _score += 90;
                        break;
                    case 10:
                        _score += 100;
                        break;
                }
                _linesFilled += 1;
            }
        }

        private void RemoveRows(int rows)
        {
            for (var i = rows; i > 2; i--)
            {
                for (var j = 0; j < _cols; j++)
                {
                    _blockControls[j, i].Background = _blockControls[j, i - 1].Background;
                }
            }
        }

        public void CurrentTetraminoMoveLeft()
        {
            var position = _currentTetramino.GetCurrentPosition();
            var shape = _currentTetramino.GetCurrentShape();
            var move = true;
            CurrentTetraminoErase();
            foreach (var point in shape)
            {
                if (((int) (point.X + position.X) + ((_cols/2) - 1) - 1) < 0)
                {
                    move = false;
                }
                else if (
                    !Equals(_blockControls[
                        ((int) (point.X + position.X) + ((_cols/2) - 1) - 1), (int) (point.Y + position.Y) + 2]
                        .Background, NoBrush))
                {
                    move = false;
                }
            }
            
            if (move)
            {
                _currentTetramino.MoveLeft();
                CurrentTetraminoDraw();
            }
            else
            {
                CurrentTetraminoDraw();
            }
        }

        public void CurrentTetraminoMoveRight()
        {
            var position = _currentTetramino.GetCurrentPosition();
            var shape = _currentTetramino.GetCurrentShape();
            var move = true;
            CurrentTetraminoErase();
            foreach (var point in shape)
            {
                if (((int)(point.X + position.X) + ((_cols / 2) - 1) + 1) >= _cols)
                {
                    move = false;
                }
                else if (
                    !Equals(_blockControls[
                        ((int) (point.X + position.X) + ((_cols/2) - 1) + 1), (int) (point.Y + position.Y) + 2]
                        .Background, NoBrush))
                {
                    move = false;
                }
            }

            if (move)
            {
                _currentTetramino.MoveRight();
                CurrentTetraminoDraw();
            }
            else
            {
                CurrentTetraminoDraw();
            }
        }

        public void CurrentTetraminoMoveDown()
        {
            var position = _currentTetramino.GetCurrentPosition();
            var shape = _currentTetramino.GetCurrentShape();
            var move = true;
            CurrentTetraminoErase();
            foreach (var point in shape)
            {
                if (((int)(point.Y + position.Y) + 2 + 1) >= _rows)
                {
                    move = false;
                }
                else if (
                    !Equals(_blockControls[
                        ((int) (point.X + position.X) + ((_cols/2) - 1)), (int) (point.Y + position.Y) + 2 + 1]
                        .Background, NoBrush))
                {
                    move = false;
                }
            }

            if (move)
            {
                _currentTetramino.MoveDown();
                CurrentTetraminoDraw();
            }
            else
            {
                CurrentTetraminoDraw();
                CheckRows();
                _currentTetramino = new Tetramino();
            }
        }

        public void CurrentTetraminoRotate()
        {
            var position = _currentTetramino.GetCurrentPosition();
            var s = new Point[4];
            var shape = _currentTetramino.GetCurrentShape();
            var move = true;
            shape.CopyTo(s, 0);
            CurrentTetraminoErase();
            for (var i = 0; i < s.Length; i++)
            {
                var x = s[i].X;
                s[i].X = s[i].Y * -1;
                s[i].Y = x;
                if (((int) (s[i].Y + position.Y) + 2) >= _rows)
                {
                    move = false;
                }
                else if (((int) (s[i].X + position.X) + ((_cols / 2) - 1)) < 0)
                {
                    move = false;
                }
                else if (((int) (s[i].X + position.X) + ((_cols / 2) - 1)) >= _rows)
                {
                    move = false;
                }
                else if (
                    !Equals(
                        _blockControls[((int) (s[i].X + position.X) + ((_cols/2) - 1)), (int) (s[i].Y + position.Y) + 2]
                            .Background, NoBrush))
                {
                    move = false;
                }
            }

            if (move)
            {
                _currentTetramino.Rotate();
                CurrentTetraminoDraw();
            }
            else
            {
                CurrentTetraminoDraw();
            }
        }
    }
}