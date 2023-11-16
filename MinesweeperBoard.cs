using System.Runtime.CompilerServices;

namespace MinesweeperHack;

public class MinesweeperBoard {

    public const int EmptyTile = 0;
    public const int MineTile = -1;
    public const int UnknownTile = -2;
    public const int LargestTile = 8;

    public int[,] TileData;

    public MinesweeperBoard(int width, int height) {
        TileData = new int[width, height];
        for (var y = 0; y < height; y++) {
            for (var x = 0; x < width; x++) {
                TileData[y, x] = UnknownTile;
            }
        }
    }

    public MinesweeperBoard(int[,] tileData) {
        foreach (int tile in tileData) {
            if (tile < UnknownTile || tile > 8) {
                throw new ArgumentException("tileData must only contain values between -2 and 8");
            }
        }
        TileData = tileData;
    }

    public MinesweeperBoard(int[] tileData, int width, int height) {
        foreach (int tile in tileData) {
            if (tile < UnknownTile || tile > 8) {
                throw new ArgumentException("tileData must only contain values between -2 and 8");
            }
        }

        TileData = new int[width, height];
        for (var y = 0; y < height; y++) {
            for (var x = 0; x < width; x++) {
                TileData[y,x] = tileData[width * y + x];
            }
        }
    }

    public (int x, int y)[] AdjacentUnknownTiles(int tileX, int tileY) {
        var result = new List<(int, int)>();
        for (var y = tileY - 1; y <= tileY + 1; y++) {
            for (var x = tileX - 1; x <= tileX + 1; x++) {
                if (TileData[y,x] == UnknownTile) {
                    result.Add((x, y));
                }
            }
        }
        return result.ToArray();
    }
}