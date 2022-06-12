using System;

using Cell = System.Tuple<System.Int64, System.Int64>;

namespace Life64
{
    public class GameState
	{
		private HashSet<Cell> game;

		public HashSet<Cell> Game
        {
			get { return game; }
            set { game = value; }
        }

		public GameState()
		{
			game = new HashSet<Cell>();
		}

		public void Set(Int64 x, Int64 y)
        {
			game.Add(Tuple.Create(x, y));
        }

		public void Clear()
        {
			game.Clear();
        }

		public bool IsAlive(Int64 x, Int64 y)
        {
			Cell? outVal;
			return game.TryGetValue(Tuple.Create(x,y), out outVal);
        }

		public int SumNeighbors(Int64 x, Int64 y)
        {
			int totalAliveNeighbors = 0;

			Int64 maxRow = (x == Int64.MaxValue) ? x : x + 1;
			Int64 minRow = (x == Int64.MinValue) ? x : x - 1;

			Int64 maxCol = (y == Int64.MaxValue) ? y : y + 1;
			Int64 minCol = (y == Int64.MinValue) ? y : y - 1;

			for (Int64 row = minRow; row >= minRow && row <= maxRow; ++row) // minRow check takes advantage of underflow to exit the loop
            {
				for (Int64 col = minCol; col >= minCol && col <= maxCol; ++col)
                {
					if (row == x && col == y)
                    {
						continue;
                    } else {
						totalAliveNeighbors += IsAlive(row, col) ? 1 : 0;
					}
				}
            }
			return totalAliveNeighbors;
        }
	}
}

