using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;

public class HouseGeneration : MonoBehaviour
{
    private Room[,] house = new Room[20, 20];
    public GameObject[] roomTemplates = new GameObject[17];
    public GameObject doorObj, enemy, enemyCountHandler;
    private Room[] roomList = new Room[17];
    private int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        enemyCountHandler = GameObject.Find("EnemyCountHandler");
        roomList = new Room[] {new Room(roomTemplates[0], new string[] { "North", "East", "South", "West"}),
                                new Room(roomTemplates[1], new string[] {"East", "South", "West"}),
                                new Room(roomTemplates[2], new string[] {"North", "South", "West"}),
                                new Room(roomTemplates[3], new string[] {"South", "West"}),
                                new Room(roomTemplates[4], new string[] {"North", "East", "West"}),
                                new Room(roomTemplates[5], new string[] {"East", "West"}),
                                new Room(roomTemplates[6], new string[] {"North", "West"}),
                                new Room(roomTemplates[7], new string[] {"West"}),
                                new Room(roomTemplates[8], new string[] {"North", "East", "South"}),
                                new Room(roomTemplates[9], new string[] {"East", "South"}),
                                new Room(roomTemplates[10], new string[] {"North", "South"}),
                                new Room(roomTemplates[11], new string[] {"South"}),
                                new Room(roomTemplates[12], new string[] {"North", "East"}),
                                new Room(roomTemplates[13], new string[] {"East"}),
                                new Room(roomTemplates[14], new string[] {"North"}),
                                new Room(roomTemplates[15], new string[] {"East", "West"}),
                                new Room(roomTemplates[16], new string[] {"North", "South"})
         };

        house[9, 9] = roomList[4];

        StartCoroutine(roomBuffer());

    }

    private void doorMatching(int x, int y)
    {
        List<string> requiredDoors = new List<string>();
        List<string> forbiddenDoors = new List<string>();

        if (house[x, y] != null)
        {
            return;
        }

        if (house[x, y + 1] != null)
        {
            if (System.Array.IndexOf(house[x, y + 1].doorways, "South") != -1)
            {
                requiredDoors.Add("North");
            }
            else
            {
                forbiddenDoors.Add("North");
            }
        }
        if (house[x + 1, y] != null)
        {
            if (System.Array.IndexOf(house[x + 1, y].doorways, "West") != -1)
            {
                requiredDoors.Add("East");
            }
            else
            {
                forbiddenDoors.Add("East");
            }
        }
        if (house[x, y - 1] != null)
        {
            if (System.Array.IndexOf(house[x, y - 1].doorways, "North") != -1)
            {
                requiredDoors.Add("South");
            }
            else
            {
                forbiddenDoors.Add("South");
            }
        }
        if (house[x - 1, y] != null)
        {
            if (System.Array.IndexOf(house[x - 1, y].doorways, "East") != -1)
            {
                requiredDoors.Add("West");
            }
            else
            {
                forbiddenDoors.Add("West");
            }
        }

        StartCoroutine(roomSelection(requiredDoors, forbiddenDoors, x, y));
    }

    private void FinalPass(int x, int y)
    {
        List<string> requiredDoors = new List<string>();
        List<string> forbiddenDoors = new List<string>();

        if (house[x, y] != null)
        {
            return;
        }

        if (house[x, y + 1] != null)
        {
            if (System.Array.IndexOf(house[x, y + 1].doorways, "South") != -1)
            {
                requiredDoors.Add("North");
            }
            else
            {
                forbiddenDoors.Add("North");
            }
        }
        else
        {
            forbiddenDoors.Add("North");
        }

        if (house[x + 1, y] != null)
        {
            if (System.Array.IndexOf(house[x + 1, y].doorways, "West") != -1)
            {
                requiredDoors.Add("East");
            }
            else
            {
                forbiddenDoors.Add("East");
            }
        }
        else
        {
            forbiddenDoors.Add("East");
        }

        if (house[x, y - 1] != null)
        {
            if (System.Array.IndexOf(house[x, y - 1].doorways, "North") != -1)
            {
                requiredDoors.Add("South");
            }
            else
            {
                forbiddenDoors.Add("South");
            }
        }
        else
        {
            forbiddenDoors.Add("South");
        }

        if (house[x - 1, y] != null)
        {
            if (System.Array.IndexOf(house[x - 1, y].doorways, "East") != -1)
            {
                requiredDoors.Add("West");
            }
            else
            {
                forbiddenDoors.Add("West");
            }
        }
        else
        {
            forbiddenDoors.Add("West");
        }

        StartCoroutine(roomSelection(requiredDoors, forbiddenDoors, x, y));
    }

    private IEnumerator roomSelection(List<string> RD, List<string> FD, int x, int y)
    {
        bool suitable = false;
        Room randomRoom = roomList[0];
        while (!suitable)
        {
            randomRoom = roomList[Random.Range(0, 16)];
            suitable = true;
            foreach (string door in RD)
            {
                if (System.Array.IndexOf(randomRoom.doorways, door) == -1)
                {
                    suitable = false;
                }
            }

            foreach (string door in FD)
            {
                if (System.Array.IndexOf(randomRoom.doorways, door) != -1)
                {
                    suitable = false;
                }
            }
            yield return null;
        }
        Debug.Log("Room at [" + x + ", " + y + "]!");
        house[x, y] = randomRoom;
    }

    private void placeRooms()
    {
        for (int y = 0; y < 20; y++)
        {
            for (int x = 0; x < 20; x++)
            {
                if (house[x, y] != null)
                {
                    Instantiate(house[x, y].room, new Vector3(x * 20 - 180, 0, y * 20 - 180), house[x, y].room.transform.rotation);
                }
            }
        }
    }

    private IEnumerator roomBuffer()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 20; x++)
                {
                    if (house[x, y] != null)
                    {


                        foreach (string doorway in house[x, y].doorways)
                        {
                            if (doorway == "North")
                            {
                                doorMatching(x, y + 1);
                            }
                            if (doorway == "East")
                            {
                                doorMatching(x + 1, y);
                            }
                            if (doorway == "South")
                            {
                                doorMatching(x, y - 1);
                            }
                            if (doorway == "West")
                            {
                                doorMatching(x - 1, y);
                            }
                        }


                    }
                }
            }
            yield return new WaitForSeconds(0.1f);
        }

        for (int y = 0; y < 20; y++)
        {
            for (int x = 0; x < 20; x++)
            {
                if (house[x, y] != null)
                {


                    foreach (string doorway in house[x, y].doorways)
                    {
                        if (doorway == "North")
                        {
                            FinalPass(x, y + 1);
                        }
                        if (doorway == "East")
                        {
                            FinalPass(x + 1, y);
                        }
                        if (doorway == "South")
                        {
                            FinalPass(x, y - 1);
                        }
                        if (doorway == "West")
                        {
                            FinalPass(x - 1, y);
                        }
                    }


                }
            }
        }

        yield return new WaitForSeconds(2f);
        placeRooms();
    }
}
