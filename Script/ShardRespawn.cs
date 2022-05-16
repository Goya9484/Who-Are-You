using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShardRespawn : MonoBehaviour
{
    public void Place(GameObject shard)
    {
        bool isPlaced = false;
        while (!isPlaced)
        {
            int childIndex = Random.Range(0, transform.childCount);
            if (transform.GetChild(childIndex).childCount == 0)
            {
                shard.transform.parent = transform.GetChild(childIndex);
                shard.SetActive(false);
                isPlaced = true;
            }
        }
    }
    public void EnableAll()
    {
        foreach(Transform child in transform)
        {
            if(child.childCount != 0)
            {
                child.GetChild(0).gameObject.SetActive(true);
            }
        }
    }
}
