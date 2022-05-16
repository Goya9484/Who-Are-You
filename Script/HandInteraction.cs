using UnityEngine;

public class HandInteraction : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {//상호작용 가능한 문을 구분하기 위해 트리거로 대상 오브젝트의 태그 확인
        if (other.tag == "DoorHandle")
        {//맞으면 외곽선을 그려주어 시각적으로 구분
            other.GetComponent<Outline>().enabled = true;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "DoorHandle")
        {
            if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {//상호작용 가능 오브젝트일 경우 애니메이션과 오디오 재생
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
