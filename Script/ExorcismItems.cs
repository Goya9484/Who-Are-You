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
                        ExorcismZone.trueCount.Enqueue(1);//�������� ���� ������ Ȯ�� �ϱ� ���� Queue ���
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
