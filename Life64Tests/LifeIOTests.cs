using System.Text;
using Life64;

namespace Life64Tests
{
	public class LifeIOTests
	{
		public LifeIOTests()
		{
		}

		[Fact]
		public void ReadCreatesGamestate()
		{
			GameState gs = new GameState();
			using (StreamReader streamReader = LifeIOTests.GenerateStreamReader("0 -1"))
            {
				LifeIO.ReadGamestate(gs, streamReader);
			}
			Assert.True(gs.IsAlive(0, -1));
		}

		[Fact]
		public void ReadStripsPunctuation()
        {
			GameState gs = new GameState();
			using (StreamReader streamReader = LifeIOTests.GenerateStreamReader("(0, 1)\n(1, 2)\n(2, 0)\n(2, 1)\n(2, 2)\n(-2000000000000, -2000000000000)\n(-2000000000001, -2000000000001)\n"))
            {
				LifeIO.ReadGamestate(gs, streamReader);
            }
			Assert.Equal(7, gs.Population);
        }

		[Fact]
		public void WriteGeneratesCorrectGamestate()
        {
			GameState gs = new GameState();
			gs.Set(-1, 1);

			using (MemoryStream memoryStream = new MemoryStream())
            {
				LifeIO.WriteGamestate(gs, new StreamWriter(memoryStream));
				Assert.Equal("-1 1\n", Encoding.UTF8.GetString(memoryStream.ToArray()));
			}
		}

		[Fact]
		public void TestGliderProducesCorrectPopulation()
		{
            GameState glider;
			LifeIO.ReadFromFile("../../../../Life64/patterns/test_glider.lif", out glider);
			Assert.Equal(5, glider.Population);
		}

		private static Stream GenerateStreamFromString(string str)
		{
			return new MemoryStream(Encoding.UTF8.GetBytes(str ?? ""));
		}

		private static StreamReader GenerateStreamReader(string str)
		{
			return new StreamReader(GenerateStreamFromString(str));
		}
	}
}

