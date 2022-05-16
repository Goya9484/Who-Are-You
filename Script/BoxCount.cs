using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BoxCount : MonoBehaviour
{
    public GameObject dialog;
    public static bool box1 = false;
    public static bool box2 = false;
    public static bool box3 = false;
    public static bool box4 = false;
    public static bool box5 = false;
    public static bool box6 = false;

    public static bool[] boxs = new bool[6];

    int num = 1;
    int ceremonyCount;

    // Update is called once per frame
    void Update()
    {


        if(box1&&box2&&box3&&box4&&box5&&box6)
        {
            Debug.Log(num + ("바퀴"));
            num++;
            box1 = false;
            box2 = false;
            box3 = false;
            box4 = false;
            box5 = false;
            box6 = false;
        }

        if(num >= 3)
        {
            dialog.SetActive(true);
            dialog.transform.Find("Txt").GetComponent<TextMeshProUGUI>().text = "의식에 성공한 것 같다!";
            if (OVRInput.GetDown(OVRInput.Button.One))
            {
                SceneManagement.ceremonyCount++;
                Debug.Log(SceneManagement.ceremonyCount);
                dialog.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
}
