namespace Life64Tests;

using Life64;

public class LifeTests
{
    [Fact]
    public void CanCreateGamestate()
    {
        Gamestate gs = new Gamestate();
    }

    [Fact]
    public void CanAddCell()
    {
        Gamestate gs = new Gamestate();
        gs.Add(0, 0);
    }
}
