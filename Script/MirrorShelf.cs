using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MirrorShelf : MonoBehaviour
{
    Transform shards;
    Transform shelfDoors;
    public GameObject hint;
    [SerializeField]
    Light spotLight; 
    bool wasFaced = false;
    float detectionAngle = 30f;
    AudioSource soundEffects;

    // Start is called before the first frame update
    void Start()
    {
        shards = transform.GetChild(0); 
        shelfDoors = transform.GetChild(1);
        soundEffects = gameObject.GetComponent<AudioSource>();
    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && !wasFaced)
        {
            IsBeingFaced(other.transform);
            soundEffects.Play();
            hint.transform.Find("Ceremony03 hint01").gameObject.SetActive(true);
            hint.transform.Find("Ceremony03 hint02").gameObject.SetActive(true);
            hint.transform.Find("Ceremony03 hint03").gameObject.SetActive(true);
            hint.transform.Find("Ceremony03 hint04").gameObject.SetActive(true);
            hint.transform.Find("Ceremony03 hint Final").gameObject.SetActive(true);
        }    
    }
    void IsBeingFaced(Transform player)
    {
        if( Vector3.Angle(player.forward, transform.position - player.position) < detectionAngle)
        {
            shards.gameObject.SetActive(true);
            shelfDoors.gameObject.SetActive(true);

            spotLight.range = 0f;
            wasFaced = true;
        }
    }



}
