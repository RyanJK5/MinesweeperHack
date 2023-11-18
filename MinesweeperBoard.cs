using System.Runtime.CompilerServices;
using Xunit.Sdk;

namespace MinesweeperHack;

public class MinesweeperBoard {

    public const int EmptyTile = 0;
    public const int MineTile = -1;
    public const int UnknownTile = -2;
    public const int LargestTile = 8;

    public int[,] TileData;

    public int Width { get => TileData.GetLength(1); }

    public int Height { get => TileData.GetLength(0); }


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

        TileData = new int[height, width];
        for (var y = 0; y < height; y++) {
            for (var x = 0; x < width; x++) {
                TileData[y,x] = tileData[width * y + x];
            }
        }
    }

    public (int x, int y)[] AdjacentTilesOfType(int tileX, int tileY, int tileType) {
        var result = new List<(int, int)>();
        
        int startX = tileX - 1;
        int startY = tileY - 1;
        int endX = tileX + 1;
        int endY = tileY + 1;
        MoveInBounds(ref startX, ref startY);
        MoveInBounds(ref endX, ref endY);
        
        for (var y = startY; y <= endY; y++) {
            for (var x = startX; x <= endX; x++) {
                if (x == tileX && y == tileY) {
                    continue;
                }
                if (TileData[y,x] == tileType) {
                    result.Add((x, y));
                }
            }
        }
        return result.ToArray();
    }

    public void MoveInBounds(ref int x, ref int y) {
        if (x >= Width) {
            x = Width - 1;
        }
        else if (x < 0) {
            x = 0;
        }
        if (y >= Height) {
            y = Height - 1;
        }
        else if (y < 0) {
            y = 0;
        }
    }

    public override bool Equals(object? obj) {
        if (obj is not MinesweeperBoard board || board.Width != Width || board.Height != Height) {
            return false;
        }
        for (var y = 0; y < board.Height; y++) {
            for (var x = 0; x < board.Width; x++) {
                if (board.TileData[y,x] != TileData[y,x]) {
                    return false;
                }
            }
        }
        return true;
    }

    public override int GetHashCode() => HashCode.Combine(TileData);
}