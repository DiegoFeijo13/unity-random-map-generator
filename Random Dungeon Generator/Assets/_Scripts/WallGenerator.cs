using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WallGenerator
{
    public static void CreateWalls(HashSet<Vector2Int> floorPositions, TilemapVisualizer tilemapVisualizer)
    {
        var wallPositions = FindWallsInDirections(floorPositions, Direction2D.eightDirectionList);

        CreateWalls(tilemapVisualizer, wallPositions);

    }

    private static void CreateWalls(TilemapVisualizer tilemapVisualizer, HashSet<Vector2Int> wallPositions)
    {
        foreach (var pos in wallPositions)
        {
            string nBinaryType = "";
            foreach (var dir in Direction2D.cardinalDirectionList)
            {
                var nPos = pos + dir;
                nBinaryType += wallPositions.Contains(nPos) ? "1" : "0";
            }
            
            tilemapVisualizer.PaintSingleWall(pos, nBinaryType);
        }
    }

    private static HashSet<Vector2Int> FindWallsInDirections(HashSet<Vector2Int> floorPositions, List<Vector2Int> directionList)
    {
        HashSet<Vector2Int> wallPositions = new HashSet<Vector2Int>();
        foreach (var position in floorPositions)
        {
            foreach (var direction in directionList)
            {
                var nPos = position + direction;
                if (!floorPositions.Contains(nPos))
                    wallPositions.Add(nPos);
            }
        }

        return wallPositions;
    }
}
