using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExorcismZone : MonoBehaviour
{
    public static int exorcismCount;
    public static Queue<int> trueCount;
    private List<int> countCheck = new List<int>();
    public GameObject dialog;
    public int isCountCheck;

    void Start()
    {
        trueCount = new Queue<int>();
        exorcismCount = 0;
        isCountCheck = 3;
    }

    void Update()
    {
        if (trueCount.Count >= 3)
        {
            while (trueCount.Count > 0)
            {
                countCheck.Add(trueCount.Dequeue());
            }

            if (countCheck[0] == 1 && countCheck[1] == 2 && countCheck[2] == 3)
                isCountCheck = 1;
            else
                isCountCheck = 2;
        }

        if (isCountCheck == 1)
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
        else if(isCountCheck == 2)
        {
            dialog.transform.Find("Txt").GetComponent<TextMeshProUGUI>().text = "의식에 실패한 것 같다...";
            Debug.Log("엑소시즘 실패");
            if (OVRInput.GetDown(OVRInput.Button.One))
                dialog.SetActive(false);
        }
    }
}
