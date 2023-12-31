namespace MinesweeperHack.Tests;

using Xunit;

public class MinesweeperBoardTest {

    [Theory]
    [InlineData(new int[] {
        -2, -2, -2,
        -2, 1, -2,
        -2, -2, -2
        }, 
        3, 3, 
        1, 1,
        8
    )]
    [InlineData(new int[] {
        -2, -2, -2, -2, -2, -2, -2, -2,
        -2, -2, -2, -2, -2, -2, -2, -2,
        -2, -2, -2, -2, -2, -2, -2, -2,
        -2, -2, -2, -2, -2, -2, -2, -2
        }, 
        8, 4, 
        3, 2,
        8
    )]
    [InlineData(new int[] {
        -2,-2, -2,
        2, 1, -2,
        -1, 1, -2,
        }, 
        3, 3,
        0, 1,
        2
    )]
    [InlineData(new int[] {
        0
        },
        1, 1,
        0, 0,
        0
    )]
    public void AdjacentUnknownTilesTest(int[] tileData, int boardWidth, int boardHeight, int testX, int testY, int expected) {
        var board = new MinesweeperBoard(tileData, boardWidth, boardHeight);
        Assert.True(board.AdjacentTilesOfType(testX, testY, -2).Length == expected);
    }   

    [Theory]
    [InlineData(new int[] {
        -2, -2, -1,
        -1, 3, -2,
        -2, -2, -1
        }, 
        3, 3, 
        1, 1,
        3
    )]
    [InlineData(new int[] {
        -2, -2, -2, -2, -2, -2, -2, -2,
        -2, -2, -2, -2, -2, -2, -2, -2,
        -2, -2, -2, -2, -2, -2, -2, -2,
        -2, -2, -2, -2, -2, -2, -2, -2
        }, 
        8, 4, 
        3, 2,
        0
    )]
    [InlineData(new int[] {
        -1,-1, -2,
        2, 3, -2,
        -1, 1, -2,
        }, 
        3, 3,
        0, 1,
        3
    )]
    [InlineData(new int[] {
        0
        },
        1, 1,
        0, 0,
        0
    )]
    public void AdjacentMinesTest(int[] tileData, int boardWidth, int boardHeight, int testX, int testY, int expected) {
        var board = new MinesweeperBoard(tileData, boardWidth, boardHeight);
        Assert.True(board.AdjacentTilesOfType(testX, testY, -1).Length == expected);
    }
}