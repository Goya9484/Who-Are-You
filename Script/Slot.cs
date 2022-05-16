using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {//InInventoryable�� ����ִ� ��ü�� InInventoryable�� Ȱ��ȭ �� ���¶��
        if (other.GetComponent<InInventoryable>() != null)
        {
            if(other.GetComponent<InInventoryable>().isInable)
            {
                if(other.transform.parent.GetComponent<OVRGrabber>() != null)
                {//���� OVRGrabber�� ������ ������ �������̸� ������ OVRGrabbable�� �����༭ ���Կ� �������� �ְ���
                    other.transform.parent.GetComponent<OVRGrabber>().ForceRelease(other.GetComponent<OVRGrabbable>());
                }
                
                // ���Կ� ���� �������� ���Կ� ������Ű�� ���� ��
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.parent = transform;
                other.transform.localPosition = Vector3.zero;
                other.transform.localRotation = Quaternion.identity;

                //�� ��ü���� ����� �ٸ��Ƿ� ��ü���� targetSize���� �������༭ �� �������� ���Կ� ����
                other.transform.localScale = other.GetComponent<InInventoryable>().targetSize;
                //other.transform.localRotation = other.GetComponent<InInventoryable>().targetRotate;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {//InInventoryable ��Ȱ��ȭ
        if (other.GetComponent<InInventoryable>() != null)
            other.GetComponent<InInventoryable>().isInable = false;
    }
}
