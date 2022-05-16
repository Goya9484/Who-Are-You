using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {//InInventoryable가 들어있는 객체의 InInventoryable가 활성화 된 상태라면
        if (other.GetComponent<InInventoryable>() != null)
        {
            if(other.GetComponent<InInventoryable>().isInable)
            {
                if(other.transform.parent.GetComponent<OVRGrabber>() != null)
                {//만약 OVRGrabber로 붙잡은 상태의 아이템이면 강제로 OVRGrabbable을 놓아줘서 슬롯에 아이템을 넣게함
                    other.transform.parent.GetComponent<OVRGrabber>().ForceRelease(other.GetComponent<OVRGrabbable>());
                }
                
                // 슬롯에 들어온 아이템을 슬롯에 고정시키기 위한 값
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.parent = transform;
                other.transform.localPosition = Vector3.zero;
                other.transform.localRotation = Quaternion.identity;

                //각 객체마다 사이즈가 다르므로 객체마다 targetSize값을 지정해줘서 그 사이즈대로 슬롯에 고정
                other.transform.localScale = other.GetComponent<InInventoryable>().targetSize;
                //other.transform.localRotation = other.GetComponent<InInventoryable>().targetRotate;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {//InInventoryable 비활성화
        if (other.GetComponent<InInventoryable>() != null)
            other.GetComponent<InInventoryable>().isInable = false;
    }
}
