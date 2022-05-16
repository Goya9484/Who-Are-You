using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollActive : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Doll")
        {
            switch (gameObject.name)
            {
                case "NeedleBox":
                    SceneManagement.dollCount++;
                    gameObject.SetActive(false);
                    break;
                case "Rice":
                    SceneManagement.dollCount++;
                    gameObject.SetActive(false);
                    break;
            }
        }
    }

  

}
