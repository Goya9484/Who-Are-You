using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBox : MonoBehaviour
{
    public int boxCount;
   
    public void BoxTriggerCount(ref bool boxs)
    {
        boxs = !boxs;

        /*
        if(boxs)
            boxs = false;
        else
            boxs = true;
        */
    }
   void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Box")
        {
            BoxTriggerCount(ref BoxCount.boxs[boxCount - 1]);

            /*
            switch(boxCount)
            {
               case 1:
                    BoxTriggerCount(ref BoxCount.box1);
                    return;
                case 2:
                    BoxTriggerCount(ref BoxCount.box2);
                    return;
                case 3:
                    BoxTriggerCount(ref BoxCount.box3);
                    return;
                case 4:
                    BoxTriggerCount(ref BoxCount.box4);
                    return;
                case 5:
                    BoxTriggerCount(ref BoxCount.box5);
                    return;
                case 6:
                    BoxTriggerCount(ref BoxCount.box6);
                    return;
                default:
                    break;
            }*/
        }
    }

}
