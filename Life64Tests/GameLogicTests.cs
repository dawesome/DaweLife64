using Life64;

namespace Life64Tests
{
	public class GameLogicTests
	{
        private const string PATTERN_FOLDER = "../../../../Life64/patterns/";

        GameState current;
        GameState next;

        public GameLogicTests()
		{
            current = new GameState();
            next = new GameState();
		}

		[Fact]
		public void CanCallTick()
        {
			GameLogic.Tick(new GameState(), ref next);
        }

        [Fact]
        public void CellWithNoNeighborsDiesAfterTick()
        {
            current.Set(0, 0);
            GameLogic.Tick(current, ref next);
            Assert.False(next.IsAlive(0, 0));
        }

        [Fact]
        public void AliveCellWithThreeNeighborsLivesAfterTick()
        {
            current.Set(0, 0);

            // neighbors 
            current.Set(1, 0);
            current.Set(-1, 0);
            current.Set(0, 1);

            GameLogic.Tick(current, ref next);

            Assert.True(next.IsAlive(0, 0));
        }

        [Fact]
        public void AliveCellWithFourNeighborsDiesAfterTick()
        {
            current.Set(0, 0);

            // neighbors 
            current.Set(1, 0);
            current.Set(-1, 0);
            current.Set(0, 1);
            current.Set(1, 1);

            GameLogic.Tick(current, ref next);

            Assert.False(next.IsAlive(0, 0));
        }

        [Fact]
        public void AliveCellWithSixNeighborsDiesAfterTick()
        {
            current.Set(0, 0);

            // neighbors
            current.Set(1, 0);
            current.Set(-1, 0);
            current.Set(0, 1);
            current.Set(0, -1);
            current.Set(-1, -1);
            current.Set(1, 1);

            GameLogic.Tick(current, ref next);

            Assert.False(next.IsAlive(0, 0));
        }

        [Fact]
        public void DeadCellWithThreeNeighborsLivesAfterTick()
        {
            // neighbors
            current.Set(1, 0);
            current.Set(-1, 0);
            current.Set(0, 1);
            
            GameLogic.Tick(current, ref next);

            Assert.True(next.IsAlive(0, 0));
        }

        [Fact]
        public void CanRunMultiTick()
        {
            // neighbors
            current.Set(1, 0);
            current.Set(-1, 0);
            current.Set(0, 1);
            GameLogic.MultiTick(current, ref next, 10);
        }

        [Fact]
        public void TestGliderTickProducesCorrectPopulation()
        {
            GameState glider;
            LifeIO.ReadFromFile(PATTERN_FOLDER + "test_glider.lif", out glider);
            Assert.Equal(5, glider.Population);

            for (var i = 0; i < 10; ++i)
            {
                GameLogic.Tick(glider, ref next);
                Assert.Equal(5, next.Population);
            }
        }

        [Fact]
        public void TestGliderMultiTickProducesCorrectPopulation()
        {
            GameState glider;
            LifeIO.ReadFromFile(PATTERN_FOLDER + "test_glider.lif", out glider);
            Assert.Equal(5, glider.Population);

            GameLogic.MultiTick(glider, ref next, 10);
            Assert.Equal(5, next.Population);
        }

        [Fact]
        public void TestRabbitsMultiTickProducesCorrectPopulation()
        {
            GameState rabbits;
            LifeIO.ReadFromFile(PATTERN_FOLDER + "rabbits.lif", out rabbits);
            Assert.Equal(14, rabbits.Population);

            GameLogic.MultiTick(rabbits, ref next, 10);
            Assert.Equal(22, next.Population);
        }

        [Fact]
        public void TestAcornMultiTickProducesCorrectPopulation()
        {
            GameState acorn;
            LifeIO.ReadFromFile(PATTERN_FOLDER + "acorn.lif", out acorn);
            Assert.Equal(7, acorn.Population);

            GameLogic.MultiTick(acorn, ref next, 10);
            Assert.Equal(30, next.Population);  
        }
    }
}

