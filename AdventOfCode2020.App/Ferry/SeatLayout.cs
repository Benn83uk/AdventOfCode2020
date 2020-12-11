using System;
using System.Linq;

namespace AdventOfCode2020.App.Ferry
{
    public class SeatLayout
    {
        protected bool Equals(SeatLayout other)
        {
            return ToString().Equals(other.ToString());
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SeatLayout) obj);
        }

        public override int GetHashCode()
        {
            return (_seats != null ? _seats.GetHashCode() : 0);
        }

        public const char Occupied = '#';
        public const char Floor = '.';
        public const char Free = 'L';
        
        private readonly char[][] _seats;

        public SeatLayout(params string[] seatRows)
        {
            var height = seatRows.Length;
            _seats = new char[height][];
            for (var i = 0; i < _seats.Length; i++)
            {
                _seats[i] = seatRows[i].ToCharArray();
            }
        }

        private SeatLayout(char[][] seats)
        {
            _seats = seats;
        }

        public int NumOccupiedSeats()
        {
            var occupiedCount = 0;
            for (var y = 0; y < _seats.Length; y++)
            {
                for (var x = 0; x < _seats[y].Length; x++)
                {
                    if (_seats[y][x] == Occupied) occupiedCount++;
                }
            }

            return occupiedCount;
        }

        public SeatLayout ApplyRules()
        {
            var height = _seats.Length;
            var width = _seats[0].Length;
            var newSeats = new char[height][];
            for (var y = 0; y < height; y++)
            {
                newSeats[y] = new char[width];
                for (var x = 0; x < width; x++)
                {
                    newSeats[y][x] = _seats[y][x];
                    
                    if (_seats[y][x] == Free)
                    {
                        if (NumOccupiedSeatsNextToSeatAt(x,y) == 0)
                        {
                            newSeats[y][x] = Occupied;
                        }
                    } else if (_seats[y][x] == Occupied)
                    {
                        if (NumOccupiedSeatsNextToSeatAt(x,y) >= 4)
                        {
                            newSeats[y][x] = Free;
                        }
                    }
                }
            }

            return new SeatLayout(newSeats);
        }

        private int NumOccupiedSeatsNextToSeatAt(in int x, in int y)
        {
            var occupiedCount = 0;
            for (var xDiff = -1; xDiff <= 1; xDiff++)
            {
                for (var yDiff = -1; yDiff <= 1; yDiff++)
                {
                    if (xDiff == 0 && yDiff == 0) continue;
                    if (IsSeatOccupiedAt(x + xDiff, y + yDiff)) occupiedCount++;
                }
            }
            return occupiedCount;
        }

        private bool IsSeatOccupiedAt(in int x, in int y)
        {
            if (y >= _seats.Length || y < 0) return false;
            if (x >= _seats[y].Length || x < 0) return false;
            return _seats[y][x] == Occupied;
        }
        
        private bool IsSeatFreeAt(in int x, in int y)
        {
            if (y >= _seats.Length || y < 0) return false;
            if (x >= _seats[y].Length || x < 0) return false;
            return _seats[y][x] == Free;
        }

        public override string ToString()
        {
            return _seats.Select(r => new string(r)).Aggregate((a, b) => $"{a}{Environment.NewLine}{b}");
        }

        public SeatLayout ApplyRulesUntilStable()
        {
            var iterationCount = 1;
            var previousLayout = this;
            var newLayout = ApplyRules();
            while (!previousLayout.Equals(newLayout))
            {
                Console.WriteLine($"{Environment.NewLine}Iteration {iterationCount}");
                Console.WriteLine(newLayout);
                iterationCount++;
                previousLayout = newLayout;
                newLayout = newLayout.ApplyRules();
            }
            return newLayout;
        }

        public SeatLayout ApplyNewRules()
        {
            var height = _seats.Length;
            var width = _seats[0].Length;
            var newSeats = new char[height][];
            for (var y = 0; y < height; y++)
            {
                newSeats[y] = new char[width];
                for (var x = 0; x < width; x++)
                {
                    newSeats[y][x] = _seats[y][x];
                    
                    if (_seats[y][x] == Free)
                    {
                        if (NumOccupiedSeatsVisibleFromSeatAt(x,y) == 0)
                        {
                            newSeats[y][x] = Occupied;
                        }
                    } else if (_seats[y][x] == Occupied)
                    {
                        if (NumOccupiedSeatsVisibleFromSeatAt(x,y) >= 5)
                        {
                            newSeats[y][x] = Free;
                        }
                    }
                }
            }

            return new SeatLayout(newSeats);
        }
        
        private int NumOccupiedSeatsVisibleFromSeatAt(in int x, in int y)
        {
            var occupiedCount = 0;

            //Right
            for (var xDiff = 1; x + xDiff < _seats[y].Length; xDiff++)
            {
                if (IsSeatFreeAt(x + xDiff, y)) break;
                if (!IsSeatOccupiedAt(x + xDiff, y)) continue;
                occupiedCount++;
                break;
            }
            
            //Left
            for (var xDiff = 1; x - xDiff >= 0; xDiff++)
            {
                if (IsSeatFreeAt(x - xDiff, y)) break;
                if (!IsSeatOccupiedAt(x - xDiff, y)) continue;
                occupiedCount++;
                break;
            }
            
            //Down
            for (var yDiff = 1; y + yDiff < _seats.Length; yDiff++)
            {
                if (IsSeatFreeAt(x, y + yDiff)) break;
                if (!IsSeatOccupiedAt(x, y + yDiff)) continue;
                occupiedCount++;
                break;
            }
            
            //Up
            for (var yDiff = 1; y - yDiff >= 0; yDiff++)
            {
                if (IsSeatFreeAt(x, y - yDiff)) break;
                if (!IsSeatOccupiedAt(x, y - yDiff)) continue;
                occupiedCount++;
                break;
            }
            
            //TopLeft
            for (var diff = 1; y - diff >= 0 && x-diff >= 0; diff++)
            {
                if (IsSeatFreeAt(x-diff, y - diff)) break;
                if (!IsSeatOccupiedAt(x-diff, y - diff)) continue;
                occupiedCount++;
                break;
            }
            
            
            //TopRight
            for (var diff = 1; y - diff >= 0 && x + diff < _seats[y].Length; diff++)
            {
                if (IsSeatFreeAt(x+diff, y - diff)) break;
                if (!IsSeatOccupiedAt(x+diff, y - diff)) continue;
                occupiedCount++;
                break;
            }
            
            //BottomRight
            for (var diff = 1; y + diff < _seats.Length && x + diff < _seats[y].Length; diff++)
            {
                if (IsSeatFreeAt(x + diff, y + diff)) break;
                if (!IsSeatOccupiedAt(x+diff, y+diff)) continue;
                occupiedCount++;
                break;
            }
            
            //BottomLeft
            for (var diff = 1; y + diff < _seats.Length && x - diff >= 0; diff++)
            {
                if (IsSeatFreeAt(x - diff, y + diff)) break;
                if (!IsSeatOccupiedAt(x-diff, y+diff)) continue;
                occupiedCount++;
                break;
            }

            return occupiedCount;
        }

        public SeatLayout ApplyNewRulesUntilStable()
        {
            var iterationCount = 1;
            var previousLayout = this;
            var newLayout = ApplyNewRules();
            while (!previousLayout.Equals(newLayout))
            {
                Console.WriteLine($"{Environment.NewLine}Iteration {iterationCount}");
                Console.WriteLine(newLayout);
                iterationCount++;
                previousLayout = newLayout;
                newLayout = newLayout.ApplyNewRules();
            }
            return newLayout;
        }
    }
}