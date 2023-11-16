namespace MinesweeperHack.Tests;

using Xunit;

public class TestClass {
    
    [Theory]
    [InlineData(5, 20)]
    [InlineData(10, 20)]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    public void MinesweeperBoardConstructor(int width, int height) {
        var board = new MinesweeperBoard(width, height);
        Assert.True(board.TileData.Length == width * height && board.TileData.All(i => i == -2));
    }
}