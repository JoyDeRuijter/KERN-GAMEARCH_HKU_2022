using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelGenerator
{
    public Vector2Int levelSize;
    public LevelGenerator() {}

    public Dictionary<Vector3Int,Tile> Generate(string _map)
    {

        Dictionary<Vector3Int,Tile> level = new Dictionary<Vector3Int, Tile>();
        try
        {
            using(StreamReader sr = new StreamReader(_map))
            {
                
                string line;
                List<string> lines = new List<string>();

                while((line = sr.ReadLine()) != null)
                {
                    lines.Add(line);
                }

                List<string> firstLineValues = new List<string>();

                for(int i = 1; i < lines.Count; i++)
                {
                    List<string> values = new List<string>();
                    values.AddRange(lines[i].Split("\t"));

                    for(int j = 2; j < values.Count; j++)
                    {
                        if(values[j] == "0")
                        {
                            Tile T = new Tile(new Vector3Int(i-1,-1,j-2),TileType.WALL);
                            level.Add(new Vector3Int(i-1,0,j-2),T);
                            T.Initialize();
                        }
                        else if(values[j] == "1")
                        {
                            Tile T = new Tile(new Vector3Int(i-1,-1,j-2),TileType.PATH);
                            level.Add(new Vector3Int(i-1,0,j-2),T);
                            T.Initialize();
                        }
                    }
                }
                levelSize = GetLevelSize(lines);
            }
        }
        catch(Exception e)
        {
            Debug.Log("The file could not be read: ");
            Debug.Log(e.Message);
        }

        return level;

    }

    private Vector2Int GetLevelSize(List<string> _lines)
    {
        string[] values = _lines[1].Split("\t");
        return new Vector2Int(Int32.Parse(values[0]), Int32.Parse(values[1]));
    }
}
