using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanegerScript : MonoBehaviour
{
    int[,] map;
    string debugText = "";
    // Start is called before the first frame update
    void Start()
    {
        map = new int[,] {
            {0, 0, 0, 0, 0 },
            {0, 0, 1, 0, 0 },
            {0, 0, 0, 0, 0 },

            };
        PrintArray();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            int[] playerIndex = {-1,-1 };
            
            playerIndex = GetPlayerIndex();
            
            MoveNumber(1, playerIndex[1], playerIndex[1] + 1, playerIndex[0],1);

            PrintArray();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            int[] playerIndex = { -1, -1 };
            playerIndex = GetPlayerIndex();

            MoveNumber(1, playerIndex[1], playerIndex[1] - 1, playerIndex[0],1);

            PrintArray();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            int[] playerIndex = { -1, -1 };

            playerIndex = GetPlayerIndex();

            MoveNumber(1, playerIndex[0], playerIndex[0] + 1, playerIndex[1],0);

            PrintArray();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            int[] playerIndex = { -1, -1 };
            playerIndex = GetPlayerIndex();

            MoveNumber(1, playerIndex[0], playerIndex[0] - 1, playerIndex[1],0);

            PrintArray();
        }
    }
    void PrintArray()
    {
        string debugText = "";
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
               debugText += map[y,x].ToString() + ",";
            }
            debugText += "\n";
        }
        Debug.Log(debugText);
    }

    int[] GetPlayerIndex()
    {
        int[] ans = { -1, -1 };
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (map[y,x] == 1)
                {
                    ans[0] = y;
                    ans[1] = x;
                    return ans;
                }
            }
        }
        return ans;
    }
    bool MoveNumber(int number,int moveFrom,int moveto,int tolFrom,int i)
    {
        if (moveto < 0 || (moveto >= map.GetLength(i)))
        {
            return false;
        }

        if (map[moveto,tolFrom] == 2)
        {
            int velocity = moveto - moveFrom;

            bool success = MoveNumber(2, moveto, moveto + velocity,tolFrom,i);

            if (!success)
            {
                return false;
            }
        }
        if (i == 1)
        {
            map[moveto, tolFrom] = number;
            map[moveFrom, tolFrom] = 0;
        }
        if (i == 0)
        {
            map[moveto, tolFrom] = number;
            map[moveFrom,moveto] = 0;
        }
        return true;
    }
}
