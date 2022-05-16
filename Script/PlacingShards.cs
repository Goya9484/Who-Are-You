using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using System.Reflection;
using TMPro;

public class PlacingShards : MonoBehaviour
{
    [SerializeField]
    Material mirrorShelfDoorMat;
    public int counter = 0;
    [SerializeField]
    Light spotLight;
    bool isSpawning = false;
    ShardRespawn shardRespawn;
    Renderer mirror;

    void Start()
    {
        /*        GameObject test = new GameObject();
                test.AddComponent(System.Type.GetType("ShardRespawn"));*/
        shardRespawn = FindObjectOfType<ShardRespawn>();
        shardRespawn.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (counter == 4)
        {
            spotLight.color = Color.red;
            spotLight.range = 15f;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "GlassShard" && !other.GetComponent<Rigidbody>().isKinematic)
        {
            Renderer mirror = FindMirrorToPlace(other.transform);
            if (mirror != null)
            {
                AddMaterialTo(mirror);
                mirror.GetComponent<Outline>().enabled = false;
                shardRespawn.Place(other.gameObject);
                counter++;
            }
        }
    }

    Renderer FindMirrorToPlace(Transform _shard)
    {
        float lowestDist = 100f;
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform tempPos = transform.GetChild(i);
            float distance = Vector3.Distance(_shard.position, tempPos.position);
            if (distance < lowestDist)
            {
                Debug.Log("test");
                mirror = tempPos.GetComponent<Renderer>();
                lowestDist = distance;
            }
        }
        Material[] mats = mirror.sharedMaterials;
        for (int i = 0; i < mats.Length; i++)
        {
            Debug.Log(mats[i].name);
            if (mats[i] == mirrorShelfDoorMat)
            {
                return null;
            }
        }
        return mirror;
    }

    void AddMaterialTo(Renderer mirror)
    {
        List<Material> materials = mirror.materials.ToList();
        materials.Add(mirrorShelfDoorMat);
        mirror.materials = materials.ToArray();
    }

    public void RemoveMaterials()
    {
        foreach (Transform child in transform)
        {
            List<Material> mats = child.GetComponent<Renderer>().sharedMaterials.ToList();
            for (int i = 0; i < mats.Count; i++)
            {
                if (mats[i] == mirrorShelfDoorMat)
                {
                    Debug.Log(mats[i]);
                    mats.RemoveAt(i);
                    continue;
                }
            }
            child.GetComponent<Renderer>().materials = mats.ToArray();
        }
    }
}
