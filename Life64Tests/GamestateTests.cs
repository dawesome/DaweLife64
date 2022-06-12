namespace Life64Tests;

using Life64;

public class GamestateTests
{
    GameState gamestate;

    public GamestateTests()
    {
        gamestate = new GameState();
    }

    [Fact]
    public void CellIsAliveAfterSet()
    {
        gamestate.Set(0, 0);
        Assert.True(gamestate.IsAlive(0, 0));
    }

    [Fact]
    public void CanCallClear()
    {
        gamestate.Clear();
    }

    [Fact]
    public void SumNeighborsAddsNearbyCells()
    {
        gamestate.Set(1, 0);
        Assert.Equal(1, gamestate.SumNeighbors(0, 0));

        gamestate.Set(1, 1);
        Assert.Equal(2, gamestate.SumNeighbors(0, 0));
    }

    [Fact]
    public void SumNeighborsDoesNotWrapAtMinMax()
    {
        gamestate.Set(Int64.MaxValue, Int64.MaxValue);
        gamestate.Set(Int64.MaxValue, Int64.MinValue);
        
        Assert.Equal(0, gamestate.SumNeighbors(Int64.MaxValue, Int64.MaxValue));
    }

    [Theory]
    [InlineData(Int64.MaxValue, 0, Int64.MaxValue - 1, 0)]
    [InlineData(Int64.MinValue, 0, Int64.MinValue + 1, 0)]
    [InlineData(0, Int64.MaxValue, 0, Int64.MaxValue - 1)]
    [InlineData(0, Int64.MinValue, 0, Int64.MinValue + 1)]
    public void SumNeighborsWorksAtMaxValues(Int64 x, Int64 y, Int64 neighborX, Int64 neighborY)
    {
        gamestate.Set(x, y);
        gamestate.Set(neighborX, neighborY);

        Assert.Equal(1, gamestate.SumNeighbors(x, y));
    }
}
