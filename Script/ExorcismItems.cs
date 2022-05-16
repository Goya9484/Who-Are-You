using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExorcismItems : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "ExorcismZone")
        {
            if (OVRInput.GetDown(OVRInput.Button.One))
            {
                switch (gameObject.name)
                {
                    case "HolyBible":
                        ExorcismZone.trueCount.Enqueue(1);//아이템이 사용된 순서를 확인 하기 위해 Queue 사용
                        break;
                    case "HolyWater":
                        ExorcismZone.trueCount.Enqueue(2);
                        break;
                    case "HolyCross":
                        ExorcismZone.trueCount.Enqueue(3);
                        break;
                }

                transform.parent.GetComponent<OVRGrabber>().ForceRelease(GetComponent<OVRGrabbable>());
                gameObject.SetActive(false);
            }
        }
    }
}
