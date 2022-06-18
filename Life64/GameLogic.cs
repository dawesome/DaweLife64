using System;
namespace Life64
{
    using Cell = System.Tuple<System.Int64, System.Int64>;
    using CellList = HashSet<System.Tuple<System.Int64, System.Int64>>;

    public static class GameLogic
	{
		public static void Tick(GameState current, ref GameState next)
        {
            CellList deadCellsToCheck = new CellList();

            foreach (Cell cell in current.Game)
            {
                SetLivingCell(current, next, cell);
                AddDeadNeighborsToSet(current, cell, ref deadCellsToCheck);
            }
            SetDeadCells(current, next, in deadCellsToCheck);

        }

        public static void MultiTick(GameState current, ref GameState next, int numTicks)
        {
            for (int i = 0; i < numTicks; ++i)
            {
                next.Clear();
                Tick(current, ref next);
                current = new GameState(next);
            }
        }

        private static void SetLivingCell(GameState current, GameState next, Cell cell)
        {
            // Would be slightly better to add dead neighbors to a checklist here in SumNeighbors.
            int currentLivingNeighbors = current.SumNeighbors(cell);

            // If an "alive" cell had less than 2 or more than 3 alive neighbors (in any of the 8 surrounding cells), it becomes dead.
            //  So if it has 2 or 3 neighbors, it stays alive
            if (currentLivingNeighbors == 2 || currentLivingNeighbors == 3)
            {
                next.Set(cell);
            }
        }

        private static void AddDeadNeighborsToSet(GameState current, Cell cell, ref CellList deadCells)
        {
            current.GetDeadNeighbors(cell, ref deadCells);
        }

        private static void SetDeadCells(GameState current, GameState next, in CellList deadCells)
        {
            foreach (Cell deadCell in deadCells)
            {
                // If a "dead" cell had *exactly * 3 alive neighbors, it becomes alive.
                if (current.SumNeighbors(deadCell) == 3)
                {
                    next.Set(deadCell);
                }
            }
        }
    }
}

