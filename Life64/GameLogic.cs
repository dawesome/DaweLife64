﻿using System;
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
                SetDeadCells(current, next, in deadCellsToCheck);
            }
        }

        private static void SetLivingCell(GameState current, GameState next, Cell cell)
        {
            // Would be slightly better to add dead neighbors to a checklist here in SumNeighbors.
            int currentLivingNeighbors = current.SumNeighbors(cell);
            if (currentLivingNeighbors >= 3 && currentLivingNeighbors <= 5)
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
                if (current.SumNeighbors(deadCell) == 3)
                {
                    next.Set(deadCell);
                }
            }
        }
    }
}

