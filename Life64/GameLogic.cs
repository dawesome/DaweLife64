using System;
namespace Life64
{
	public static class GameLogic
	{
		public static void Tick(GameState current, ref GameState next)
        {
            foreach (Tuple<Int64, Int64> cell in current.Game)
            {
                if (current.SumNeighbors(cell) >= 3 && current.SumNeighbors(cell) <= 5)
                {
                    next.Set(cell);
                }
            }
        }
	}
}

