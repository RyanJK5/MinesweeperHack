namespace MinesweeperHack;

public class MinesweeperBoard {

    public const int EmptyTile = 0;
    public const int MineTile = -1;
    public const int UnknownTile = -2;

    public int[] TileData;

    public MinesweeperBoard(int width, int height) {
        TileData = new int[width * height];
        for (var i = 0; i <TileData.Length; i++) {
            TileData[i] = UnknownTile;
        }
    }
}