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
            { 0,  0, 0,  0, 1,  -1, 1,  1, -1 },
            { 1,  2, 1,  1, 1,  1,  1,  1,  1 },
            { -1, 2, -1, 1, 0,  0,  1,  1,  1 },
            { 1,  2, 1,  1, 0,  0,  1,  -1, 1 },
            { 0,  0, 0,  0, 0,  0,  2,  2,  2 },
            { 0,  0, 0,  1, 1,  1,  2,  -1, 2 },
            { 1,  1, 0,  1, -1, 1,  2,  -1, 2 },
            { -1, 1, 0,  1, 1,  2,  2,  2,  1 },
            { 1,  1, 0,  0, 0,  1,  -1, 1,  0 }
        });
        
        PrintBoard(board);
        Solve(board, solutionBoard);
        PrintBoard(board);
    }

    public static void Solve(MinesweeperBoard board, MinesweeperBoard solutionBoard) {
        while (!board.Equals(solutionBoard)) {
            for (var y = 0; y < board.Height; y++) {
                for (var x = 0; x < board.Width; x++) {
                    if (board.TileData[y,x] != MinesweeperBoard.UnknownTile && board.TileData[y,x] != MinesweeperBoard.MineTile) {
                        PlaceFlagsFrom(board, x, y);
                    }
                }
            }

            for (var y = 0; y < board.Height; y++) {
                for (var x = 0; x < board.Width; x++) {
                    if (board.TileData[y,x] != MinesweeperBoard.UnknownTile && board.TileData[y,x] != MinesweeperBoard.MineTile) {
                        RevealSafeTiles(board, solutionBoard, x, y);
                    }
                }
            }
        }
    }

    public static void PlaceFlagsFrom(MinesweeperBoard board, int x, int y) {
        (int, int)[] unknowns = board.AdjacentTilesOfType(x, y, MinesweeperBoard.UnknownTile);
        (int, int)[] mines = board.AdjacentTilesOfType(x, y, MinesweeperBoard.MineTile);
        if (unknowns.Length + mines.Length == board.TileData[y,x]) {
            foreach ((int X, int Y) coord in unknowns) {
                board.TileData[coord.Y, coord.X] = MinesweeperBoard.MineTile;
            }
        }
    }

    public static void RevealSafeTiles(MinesweeperBoard board, MinesweeperBoard solutionBoard, int x, int y) {
        (int, int)[] unknowns = board.AdjacentTilesOfType(x, y, MinesweeperBoard.UnknownTile);
        (int, int)[] mines = board.AdjacentTilesOfType(x, y, MinesweeperBoard.MineTile);

        if (mines.Length == board.TileData[y,x]) {
            foreach ((int X, int Y) coord in unknowns) {
                board.TileData[coord.Y, coord.X] = solutionBoard.TileData[coord.Y, coord.X];
            }
        }
    }

    public static void PrintBoard(MinesweeperBoard board) {
        for (var y = 0; y < board.Height; y++) {
            for (var x = 0; x < board.Width; x++) {
                Console.Write((board.TileData[y, x] >= 0 ? " " : "") + board.TileData[y, x] + (x < board.Width - 1 ? ", " : ""));
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}