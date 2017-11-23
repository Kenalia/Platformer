using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TextMapParser : MonoBehaviour {

    char char_playerStartPosition = '@';
    char char_platformLeftBoundary = '<';
    char char_platformType_Base = '-';
    char char_platformRightBoundary = '>';
    char char_coin = 'C';

    GameObject prefab_playerStartPosition;
    GameObject prefab_platformLeftBoundary;
    GameObject prefab_platformType_Base;
    GameObject prefab_platformRightBoundary;
    GameObject prefab_coin;

    static string mapFileName;

    private void Start()
    {
        Dictionary<char, GameObject> units = new Dictionary<char, GameObject>();

        units.Add(char_playerStartPosition, prefab_playerStartPosition);
        units.Add(char_platformLeftBoundary, prefab_platformLeftBoundary);
        units.Add(char_platformType_Base, prefab_platformType_Base);
        units.Add(char_platformRightBoundary, prefab_platformRightBoundary);

        System.IO.StreamReader file = new System.IO.StreamReader(mapFileName);

        string line;
        Vector2 place = new Vector2(0, 0);

        while((line = file.ReadLine()) != null)
        {

        }
        
    }

}
