using Life64;

namespace Life64Tests
{
	public class GameLogicTests
	{
		public GameLogicTests()
		{ 
		}

		[Fact]
		public void CanCallTick()
        {
			GameState next = new GameState();
			GameLogic.Tick(new GameState(), ref next);
        }

        [Fact]
        public void CellWithNoNeighborsDiesAfterTick()
        {
            GameState gameState = new GameState();
            gameState.Set(0, 0);

            GameState next = new GameState();

            GameLogic.Tick(gameState, ref next);
            Assert.False(next.IsAlive(0, 0));
        }

        [Fact]
        public void AliveCellWithThreeNeighborsLivesAfterTick()
        {
            GameState gameState = new GameState();
            gameState.Set(0, 0);

            // neighbors 
            gameState.Set(1, 0);
            gameState.Set(-1, 0);
            gameState.Set(0, 1);

            GameState next = new GameState();
            GameLogic.Tick(gameState, ref next);

            Assert.True(next.IsAlive(0, 0));
        }

        [Fact]
        public void AliveCellWithFourNeighborsDiesAfterTick()
        {
            GameState gameState = new GameState();
            gameState.Set(0, 0);

            // neighbors 
            gameState.Set(1, 0);
            gameState.Set(-1, 0);
            gameState.Set(0, 1);
            gameState.Set(1, 1);

            GameState next = new GameState();
            GameLogic.Tick(gameState, ref next);

            Assert.False(next.IsAlive(0, 0));
        }

        [Fact]
        public void AliveCellWithSixNeighborsDiesAfterTick()
        {
            GameState gameState = new GameState();
            gameState.Set(0, 0);

            // neighbors
            gameState.Set(1, 0);
            gameState.Set(-1, 0);
            gameState.Set(0, 1);
            gameState.Set(0, -1);
            gameState.Set(-1, -1);
            gameState.Set(1, 1);

            GameState next = new GameState();
            GameLogic.Tick(gameState, ref next);

            Assert.False(next.IsAlive(0, 0));
        }

        [Fact]
        public void DeadCellWithThreeNeighborsLivesAfterTick()
        {
            GameState gameState = new GameState();
            
            // neighbors
            gameState.Set(1, 0);
            gameState.Set(-1, 0);
            gameState.Set(0, 1);
            
            GameState next = new GameState();
            GameLogic.Tick(gameState, ref next);

            Assert.True(next.IsAlive(0, 0));
        }
    }
}

