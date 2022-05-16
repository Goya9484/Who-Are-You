using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonManagermanet : MonoBehaviour
{
    public GameObject button1;
    public GameObject button2;
    public GameObject dialog;
    private ShardRespawn shardRespawn;
    public PlacingShards placingShards;
    private int merryCount = 0;
    bool isSuccess = false;

    void Start()
    {
        shardRespawn = FindObjectOfType<ShardRespawn>();
        placingShards = FindObjectOfType<PlacingShards>();
    }

    public void Update()
    {
        if (placingShards.counter == 4)
        {
            dialog.SetActive(true);
            button1.SetActive(true);
            button2.SetActive(true);
            dialog.transform.Find("Txt").GetComponent<TextMeshProUGUI>().text = "올바른 주문을 골라보자";
            dialog.transform.Find("Explan").GetComponent<TextMeshProUGUI>().text = "X 버튼 : 왼쪽 선택지" +
                                                                                    System.Environment.NewLine + "Y 버튼 : 오른쪽 선택지";
            if (OVRInput.GetDown(OVRInput.Button.Three))
                merryCount = 1;
            if (OVRInput.GetDown(OVRInput.Button.Four))
                merryCount = 2;
        }

        if (merryCount == 1)
        {
            CeremonySuccess();
            SuccessButton();
        }

        else if (merryCount == 2)
        {
            CeremonyFail();
            FailButton();
        }
    }

    public void CeremonySuccess()
    {
        button1.SetActive(false);
        button2.SetActive(false);
        dialog.transform.Find("Txt").GetComponent<TextMeshProUGUI>().text = "의식에 성공한 것 같다!";
        dialog.transform.Find("Explan").GetComponent<TextMeshProUGUI>().text = "A버튼을 누르세요";
        isSuccess = true;
    }

    public void SuccessButton()
    {
        if (OVRInput.GetDown(OVRInput.Button.One) && isSuccess)
        {
            SceneManagement.ceremonyCount++;
            Debug.Log("블러디 메리" + SceneManagement.ceremonyCount);
            placingShards.counter = 0;
            merryCount = 0;
            dialog.SetActive(false);
            placingShards.gameObject.SetActive(false);
        }
    }

    public void CeremonyFail()
    {
        isSuccess = false;
        button1.SetActive(false);
        button2.SetActive(false);
        shardRespawn.EnableAll();
        placingShards.RemoveMaterials();
        dialog.transform.Find("Txt").GetComponent<TextMeshProUGUI>().text = "의식에 실패했다!";
        dialog.transform.Find("Explan").GetComponent<TextMeshProUGUI>().text = "A버튼을 누르세요";
    }

    public void FailButton()
    {
        if (OVRInput.GetDown(OVRInput.Button.One) && isSuccess == false)
        {
            placingShards.counter = 0;
            merryCount = 0;
            dialog.SetActive(false);
        }
    }
}
