using System;
using System.IO;

namespace Life64
{
	// File IO for Life 1.06.
	// https://conwaylife.com/wiki/Life_1.06
	public static class LifeIO
	{
		public static void WriteToFile(string path, GameState gs)
        {
			if (!File.Exists(path))
			{
				File.CreateText(path);
			}

			using (StreamWriter sw = new StreamWriter(path))
            {
				sw.WriteLine("#Life 1.06");

				// TODO: Something better here? Sucks a little to have to know the type
				foreach (Tuple<Int64, Int64> cell in gs.Game)
                {
					sw.WriteLine(String.Format("{0} {1}", cell.Item1, cell.Item2));
                }
            }
        }

		public static void ReadFromFile(string path, out GameState gs)
        {
			gs = new GameState();

			try
            {
				using (StreamReader sr = new StreamReader(path))
                {
					string? header = sr.ReadLine();

					while (!sr.EndOfStream)
                    {
						string? line = sr.ReadLine();
						if (line != null)
						{
							string[] cell = line.Split();
							gs.Set(Int64.Parse(cell[0]), Int64.Parse(cell[1]));
						}
                    }
                }
            } catch (IOException e)
            {
				Console.WriteLine(e.Message);
            }
		}
	}
}

