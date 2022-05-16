using UnityEngine;

public class HandInteraction : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {//��ȣ�ۿ� ������ ���� �����ϱ� ���� Ʈ���ŷ� ��� ������Ʈ�� �±� Ȯ��
        if (other.tag == "DoorHandle")
        {//������ �ܰ����� �׷��־� �ð������� ����
            other.GetComponent<Outline>().enabled = true;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "DoorHandle")
        {
            if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {//��ȣ�ۿ� ���� ������Ʈ�� ��� �ִϸ��̼ǰ� ����� ���
                Transform parent = other.transform.parent;
                parent.GetComponent<BoxCollider>().enabled = false;
                parent.GetComponent<Animation>().Play();
                parent.GetComponent<AudioSource>().Play();
                other.gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "DoorHandle")
        {
            other.GetComponent<Outline>().enabled = false; ;
        }
    }



}
