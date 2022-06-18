using System.Text;
using Life64;

namespace Life64Tests
{
	public class LifeIOTests
	{
		public LifeIOTests()
		{
		}

		private static Stream GenerateStreamFromString(string str)
        {
			return new MemoryStream(Encoding.UTF8.GetBytes(str ?? ""));
        }

		private static StreamReader GenerateStreamReader(string str)
        {
			return new StreamReader(GenerateStreamFromString(str));
        }

		[Fact]
		public void ReadCreatesGamestate()
		{
			GameState gs = new GameState();
			using (StreamReader streamReader =  LifeIOTests.GenerateStreamReader("#Life 1.06\n0 -1"))
            {
				LifeIO.ReadGamestate(gs, streamReader);
			}
			Assert.True(gs.IsAlive(0, -1));
		}

		[Fact]
		public void WriteGeneratesCorrectGamestate()
        {
			GameState gs = new GameState();
			gs.Set(-1, 1);

			using (MemoryStream memoryStream = new MemoryStream())
            {
				LifeIO.WriteGamestate(gs, new StreamWriter(memoryStream));
				Assert.Equal("#Life 1.06\n-1 1\n", Encoding.UTF8.GetString(memoryStream.ToArray()));
			}

		}
	}
}

