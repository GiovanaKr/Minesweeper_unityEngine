using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinesweeperGrid : MonoBehaviour
{
    [SerializeField]
    private GameObject block;
    [SerializeField]
    private GameObject parent;

    public List<GameObject> gridList;
    public int BombNum;

    public int x;
    public int y;

    void Awake(){
        for (int h = y; h > 0; h--)
        {
            for (int w = 0; w < x; w++)
            {
                GameObject grid =  Instantiate(block, new Vector2(w-(x/2)+.5f, h-(y/2)-.5f), Quaternion.identity, parent.transform);
                gridList.Add(grid);
            }
        }

        for (int i = 0; i < BombNum; i++)
        {
            int index = Random.Range(0, gridList.Count);
            gridList[index].GetComponent<Block>().num = -1;
        }
    }
}
