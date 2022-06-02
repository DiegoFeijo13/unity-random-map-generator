using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapVisualizer : MonoBehaviour
{
    [SerializeField]
    private Tilemap floorTilemap, wallTilemap;
    [SerializeField]
    private TileBase
        floorTile,
        wallTile;
        //wallVertical,
        //wallHorizontal,
        //wallLeftUpCorner,
        //wallLeftDownCorner,
        //wallRightUpCorner,
        //wallRightDownCorner,
        //wallUpDownLeft,
        //wallUpDownRight,
        //wallUpDownLeftRight;


    [SerializeField]
    private TileBase itemTile;

    public void PaintFloorTiles(IEnumerable<Vector2Int> floorPositions)
    {
        PaintTiles(floorPositions, floorTilemap, floorTile);
    }

    internal void PaintSingleWall(Vector2Int position, string binaryType)
    {
        WallType wallType = WallTypesHelper.GetWallType(binaryType);
        TileBase tile = GetWallTileByType(wallType);

        if (tile != null)
            PaintSingleTile(wallTilemap, tile, position);
    }

    private TileBase GetWallTileByType(WallType wallType)
    {
        return wallTile;
        //switch (wallType)
        //{
        //    case WallType.Vertical:
        //        return wallVertical;
        //    case WallType.Horizontal:
        //        return wallHorizontal;
        //    case WallType.LeftUpCorner:
        //        return wallLeftUpCorner;
        //    case WallType.LeftDownCorner:
        //        return wallLeftDownCorner;
        //    case WallType.RightUpCorner:
        //        return wallRightUpCorner;
        //    case WallType.RightDownCorner:
        //        return wallRightDownCorner;
        //    default:
        //        break;
        //}

        return null;
    }

    public void PaintItemTile(Vector2Int position)
    {
        PaintSingleTile(wallTilemap, itemTile, position);
    }

    private void PaintTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile)
    {
        foreach (var position in positions)
        {
            PaintSingleTile(tilemap, tile, position);
        }
    }

    private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position)
    {
        var tilePosition = tilemap.WorldToCell((Vector3Int)position);
        tilemap.SetTile(tilePosition, tile);
    }

    public void Clear()
    {
        floorTilemap.ClearAllTiles();
        wallTilemap.ClearAllTiles();
    }
}
