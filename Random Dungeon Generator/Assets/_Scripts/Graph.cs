using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph
{
    private static List<Vector2Int> neighbors4directions = new List<Vector2Int>
    {
        new Vector2Int(0,1), //UP
        new Vector2Int(1,0), //RIGHT
        new Vector2Int(0,-1), //DOWN
        new Vector2Int(-1,0), //LEFT
    };

    private static List<Vector2Int> neighbors8directions = new List<Vector2Int>
    {
        new Vector2Int(0,1), //UP
        new Vector2Int(1,0), //RIGHT
        new Vector2Int(0,-1), //DOWN
        new Vector2Int(-1,0), //LEFT

        new Vector2Int(1,1), //UP+RIGHT
        new Vector2Int(1,-1), //DOWN+RIGHT
        new Vector2Int(-1,1), //UP+LEFT
        new Vector2Int(-1,-1), //DOWN+LEFT
        
    };

    List<Vector2Int> graph;

    public Graph(IEnumerable<Vector2Int> vertices)
    {
        graph = new List<Vector2Int>(vertices);
    }

    public List<Vector2Int> GetNeighbors4Directions(Vector2Int startPos)
    {
        return GetNeighbors(startPos, neighbors4directions);
    }

    public List<Vector2Int> GetNeighbors8Directions(Vector2Int startPos)
    {
        return GetNeighbors(startPos, neighbors8directions);
    }

    private List<Vector2Int> GetNeighbors(Vector2Int startPos, List<Vector2Int> neighborsOffsetList)
    {
        List<Vector2Int> neighbors = new List<Vector2Int>();
        foreach (var neighbourDirection in neighborsOffsetList)
        {
            Vector2Int potentialNeighbour = startPos + neighbourDirection;
            if (graph.Contains(potentialNeighbour))
                neighbors.Add(potentialNeighbour);
        }

        return neighbors;
    }
}
