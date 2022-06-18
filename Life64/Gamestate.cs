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

		public GameState(GameState copy)
		{
			game = new HashSet<Cell>(copy.game);
		}

		public Int64 Population
        {
			get { return game.Count; }
        }

		public GameState()
		{
			game = new HashSet<Cell>();
		}

		public void Set(Cell cell)
        {
			game.Add(cell);
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

		private Int64 IncWithoutOverflow(Int64 val)
        {
			return (val == Int64.MaxValue) ? val : val + 1;
		}

		private Int64 DecWithoutUnderflow(Int64 val)
        {
			return (val == Int64.MinValue) ? val : val - 1;
        }

		public int SumNeighbors(Tuple<Int64, Int64> cell)
        {
			return SumNeighbors(cell.Item1, cell.Item2);
        }

		public int SumNeighbors(Int64 x, Int64 y)
        {
			int totalAliveNeighbors = 0;

			Int64 maxRow = IncWithoutOverflow(x);
			Int64 maxCol = IncWithoutOverflow(y);

			Int64 minRow = DecWithoutUnderflow(x);
			Int64 minCol = DecWithoutUnderflow(y);

			for (Int64 row = minRow; row >= minRow && row <= maxRow; ++row) // minRow check takes advantage of underflow to exit the loop
            {
				for (Int64 col = minCol; col >= minCol && col <= maxCol; ++col) // ibid.
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

		public void GetDeadNeighbors(Cell cell, ref HashSet<Cell> deadCells)
        {
			GetDeadNeighbors(cell.Item1, cell.Item2, ref deadCells);
        }

		public void GetDeadNeighbors(Int64 x, Int64 y, ref HashSet<Cell> deadCells)
        {
			Int64 maxRow = IncWithoutOverflow(x);
			Int64 maxCol = IncWithoutOverflow(y);

			Int64 minRow = DecWithoutUnderflow(x);
			Int64 minCol = DecWithoutUnderflow(y);

			for (Int64 row = minRow; row >= minRow && row <= maxRow; ++row) // minRow check takes advantage of underflow to exit the loop
			{
				for (Int64 col = minCol; col >= minCol && col <= maxCol; ++col) // ibid.
				{
					if (row == x && col == y)
					{
						continue;
					}
					else if (!IsAlive(row, col))
                    {
						deadCells.Add(Tuple.Create<Int64, Int64>(row, col));
                    }
				}
			}
		}
    }
}

