using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRUIRay : MonoBehaviour
{
    public static VRUIRay instance;
    public Transform rightHand; // VR 오른쪽 컨트롤러
    public Transform dot; // 마우스 포인터를 대체할 이미지
    public AudioSource selectSound;

    private void Awake()
    {
        instance = this;
        selectSound = this.GetComponent<AudioSource>();
    }

    void Update()
    {
        Ray ray = new Ray(rightHand.position, rightHand.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("UI"))
            {
                dot.gameObject.SetActive(true);
                dot.position = hit.point;
            }
            else
                dot.gameObject.SetActive(false);

            if (dot.gameObject.activeSelf)
            {
                if (OVRInput.GetDown(OVRInput.Button.Any))
                {
                    Button btn = hit.transform.GetComponent<Button>();
                    
                    if (btn != null)
                    {
                        selectSound.Play();
                        StartCoroutine(Delay(btn));
                    }
                }
            }
        }
        else
            dot.gameObject.SetActive(false);
    }

    IEnumerator Delay(Button btn)
    {
        yield return new WaitForSecondsRealtime(3.5f);
        btn.onClick.Invoke();
    }
}
