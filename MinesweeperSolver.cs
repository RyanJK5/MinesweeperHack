namespace MinesweeperHack;

public class MinesweeperSolver {
    public static void Main() {
        var board = new MinesweeperBoard(new int[,] {
            { -2, -2, -2, -2, -2, -2, -2, -2, -2 },
            { -2, -2, -2, 1,  1,  1,  1,  -2, -2 },
            { -2, -2, -2, 1,  0,  0,  1,  -2, -2 },
            { 1,  2,  1,  1,  0,  0,  1,  -2, -2 },
            { 0,  0,  0,  0,  0,  0,  2,  -2, -2 },
            { 0,  0,  0,  1,  1,  1,  2,  -2, -2 },
            { 1,  1,  0,  1, -2, -2, -2,  -2, -2 },
            { -2, 1,  0,  1,  1,  2, -2,  -2, -2 },
            { -2, 1,  0,  0,  0,  1, -2,  -2, -2 }
        });
        var solutionBoard = new MinesweeperBoard(new int[,] {
            { -2, -2, -2, -2, -2, -2, -2, -2, -2 },
            { -2, -2, -2, 1,  1,  1,  1,  -2, -2 },
            { -2, -2, -2, 1,  0,  0,  1,  -2, -2 },
            { 1,  2,  1,  1,  0,  0,  1,  -2, -2 },
            { 0,  0,  0,  0,  0,  0,  2,  -2, -2 },
            { 0,  0,  0,  1,  1,  1,  2,  -2, -2 },
            { 1,  1,  0,  1, -2, -2, -2,  -2, -2 },
            { -2, 1,  0,  1,  1,  2, -2,  -2, -2 },
            { -2, 1,  0,  0,  0,  1, -2,  -2, -2 }
        });
        Solve(board, solutionBoard);
    }

    public static void Solve(MinesweeperBoard board, MinesweeperBoard solutionBoard) {
        for (var y = 0; y < board.Height; y++) {
            for (var x = 0; x < board.Width; x++) {
                if (board.TileData[y,x] != MinesweeperBoard.UnknownTile) {
                    PlaceFlagsFrom(board, x, y);
                }
            }
        }
    }

    public static void PlaceFlagsFrom(MinesweeperBoard board, int x, int y) {
        (int, int)[] unknowns = board.AdjacentTilesOfType(x, y, MinesweeperBoard.UnknownTile);
        if (unknowns.Length == board.TileData[x,y]) {
            foreach ((int X, int Y) coord in unknowns) {
                board.TileData[coord.Y, coord.X] = MinesweeperBoard.MineTile;
            }
        }
    }
}