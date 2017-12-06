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
    char char_turret_enemy = 'T';

    [SerializeField]
    GameObject prefab_playerStartPosition;
    [SerializeField]
    GameObject prefab_platformLeftBoundary;
    [SerializeField]
    GameObject prefab_platformType_Base;
    [SerializeField]
    GameObject prefab_platformRightBoundary;
    [SerializeField]
    GameObject prefab_coin;
    [SerializeField]
    GameObject prefab_turret_enemy;

    int playerStartCounts = 0;
    Vector2 playerStartPosition;

    Transform platformParent;
    [SerializeField]
    GameObject parent;

    [SerializeField]
    string mapFile;
    static string mapFileName;

    private void Start()
    {
        mapFileName = mapFile;

        //Dictionary to store character <-> value equivalencies
        Dictionary<char, GameObject> units = new Dictionary<char, GameObject>
        {
            { char_playerStartPosition, prefab_playerStartPosition },
            { char_platformLeftBoundary, prefab_platformLeftBoundary },
            { char_platformType_Base, prefab_platformType_Base },
            { char_platformRightBoundary, prefab_platformRightBoundary },
            { char_turret_enemy, prefab_turret_enemy }
        };

        //Open the file
        System.IO.StreamReader file = new System.IO.StreamReader(mapFileName);

        string line;
        Vector2 place = new Vector2(0, 0);

        while((line = file.ReadLine()) != null)
        {
            for(int i = 0; i < line.Length; i++)
            {
                place.x = i;

                if(line[i].Equals(char_playerStartPosition))
                {
                    if(playerStartCounts != 0)
                    {
                        //Do nothing, can only have one start position
                    }
                    else
                    {
                        playerStartPosition = place;
                    }
                }
                else if(line[i].Equals(char_platformLeftBoundary))
                {
                    //Create the platform list
                    parent = new GameObject("Platform " + place.ToString());
                    platformParent = parent.transform;

                    //Create the first block
                    GameObject block = Instantiate(prefab_platformLeftBoundary, place, new Quaternion(0f, 0f, 0f, 0f), platformParent) as GameObject;
                    block.name = platformParent.name + " Left Boundary";

                    //Begin the platform
					parent.AddComponent<Platform> ();
                    parent.GetComponent<Platform>().StartPlatform();
					parent.GetComponent<Platform>().blocks.AddFirst(block.GetComponent<PlatformBoundary>());
                }
                else if(line[i].Equals(char_platformRightBoundary))
                {
                    if(platformParent != null)
                    {
                        //Add it to the end
                        GameObject block = Instantiate(prefab_platformRightBoundary, place, new Quaternion(0f, 0f, 0f, 0f), platformParent) as GameObject;
                        block.name = platformParent.name + " Right Boundary";
                        platformParent.gameObject.GetComponent<Platform>().blocks.AddLast(block.GetComponent<PlatformBoundary>());

                        //End the current platform group
                        platformParent.GetComponent<Platform>().PlatformFinished();
                        platformParent = null;
                        parent = null;
                    }
                }
                else if (units.ContainsKey(line[i]))
                {
                    GameObject unit = units[line[i]];

                    if (platformParent != null)
                    {
                        //Add the block
                        GameObject block = Instantiate(units[line[i]], place, new Quaternion(0f, 0f, 0f, 0f), platformParent) as GameObject;
                        block.name = platformParent.name + " block #" + (place.x - platformParent.position.x);
                        platformParent.gameObject.GetComponent<Platform>().blocks.AddLast(block.GetComponent<PlatformBoundary>());
                    }
                    else if(platformParent == null)
                    {
                        GameObject madeObj = Instantiate(unit, place, new Quaternion(0f, 0f, 0f, 0f)) as GameObject;
                        madeObj.name = unit.name + " Start: " + place.ToString();
                    }
                }
            }

            place.y--;
        }


        //Spawn the player
        Instantiate(prefab_playerStartPosition, playerStartPosition, prefab_playerStartPosition.transform.rotation);

        file.Close();
    }

}
