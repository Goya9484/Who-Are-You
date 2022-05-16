using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnPlace : MonoBehaviour
{
    public GameObject place;
    public GameObject parent;
    
    private void Update()
    {//가방 위치 초기화
        if(OVRInput.Get(OVRInput.Button.One))
        {
            gameObject.transform.parent = place.transform;
            gameObject.transform.position = place.transform.position;
            gameObject.transform.rotation = place.transform.rotation;
        }
    }
}
