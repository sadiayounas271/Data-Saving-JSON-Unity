using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData 
{
    public string Name { get; set; }
    public string level { get; set; }
    public string health { get; set; }

    public GameData()
    {
        Name = "null";
        level = "0";
        health = "0";
    }
}
