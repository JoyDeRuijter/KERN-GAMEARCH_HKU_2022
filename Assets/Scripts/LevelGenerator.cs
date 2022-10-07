using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelGenerator
{

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
                            Tile T = new Tile(new Vector3Int(i,0,j),TileType.WALL);
                            level.Add(new Vector3Int(i,0,j),T);
                            T.Initialize();
                        }
                        else if(values[j] == "1")
                        {
                            Tile T = new Tile(new Vector3Int(i,0,j),TileType.PATH);
                            level.Add(new Vector3Int(i,0,j),T);
                            T.Initialize();
                        }

                    }
                }

            }
        }
        catch(Exception e)
        {
            Debug.Log("The file could not be read: ");
            Debug.Log(e.Message);
        }

        return level;

    }

}
