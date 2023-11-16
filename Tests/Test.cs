namespace MinesweeperHack.Tests;

using Xunit;

public class TestClass {

    [Theory]
    [InlineData(new int[] {
        -2, -2, -2,
        -2, 1, -2,
        -2, -2, -2
        }, 
        3, 3, 
        1, 1
    )]
    public void AdjacentUnknownTilesTest(int[] tileData, int boardWidth, int boardHeight, int testX, int testY) {
        var board = new MinesweeperBoard(tileData, boardWidth, boardHeight);
        Assert.True(board.AdjacentUnknownTiles(testX, testY).Length == 8);
    }   
}