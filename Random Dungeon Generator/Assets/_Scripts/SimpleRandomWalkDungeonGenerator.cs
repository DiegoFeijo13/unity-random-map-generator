using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SimpleRandomWalkDungeonGenerator : AbstractDungeonGenerator
{
    [SerializeField]
    protected SimpleRandomWalkSO randomWalkParameters;    

    protected override void RunProceduralGeneration()
    {
        HashSet<Vector2Int> floorPositions = RunRandomWalk(randomWalkParameters, startPosition);
        tilemapVisualizer.Clear();
        tilemapVisualizer.PaintFloorTiles(floorPositions);
        WallGenerator.CreateWalls(floorPositions, tilemapVisualizer);
    }

    protected HashSet<Vector2Int> RunRandomWalk(SimpleRandomWalkSO parameters, Vector2Int position)
    {
        var currentPos = position;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        for (int i = 0; i < parameters.iterations; i++)
        {
            var path = ProceduralGenerationAlgorithms.SimpleRandomWalk(currentPos, parameters.walkLength);
            floorPositions.UnionWith(path);
            if (parameters.startRandomlyEachIteration)
                currentPos = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
        }
        if (randomWalkParameters.noHoles)
            FillEmptySpaces(floorPositions);

        return floorPositions;
    }

    private void FillEmptySpaces(HashSet<Vector2Int> floorPositions)
    {
        if (!floorPositions.Any())
            return;

        HashSet<Vector2Int> posToAdd = new HashSet<Vector2Int>();

        foreach (var position in floorPositions)
        {               
            int filledDirections = 0;
            HashSet<Vector2Int> emptyPos = new HashSet<Vector2Int>();
            foreach (var dir in Direction2D.eightDirectionList)
            {
                var neighbourPosition = position + dir;
                if (floorPositions.Contains(neighbourPosition))
                    filledDirections++;
                else
                    emptyPos.Add(neighbourPosition);
                
            }

            foreach (var pos in emptyPos)
            {
                posToAdd.Add(pos);
            }
        }

        if(posToAdd.Any())
        {
            foreach (var pos in posToAdd)
            {
                floorPositions.Add(pos);
            }
        }

        
    }
}
