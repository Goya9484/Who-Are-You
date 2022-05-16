using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogTrigger : MonoBehaviour
{
    public ChatManager chatManager;
    public DialogNormal dialogNormal; //보통 엔딩 대사집
    public DialogHidden dialogHidden; //히든 엔딩 대사집

    public void DigNormalTrigger()
    {//보통 엔딩 트리거
        FindObjectOfType<ChatManager>().StartDialog(dialogNormal);
    }

    public void DigHiddenTrigger()
    {//히든 엔딩 트리거
        FindObjectOfType<ChatManager>().StartDialog(dialogHidden);
    }

    public void Start()
    {
        if (SceneManager.GetActiveScene().name == "4-1 Nomal Ending")
            DigNormalTrigger();
        else if (SceneManager.GetActiveScene().name == "4-2 Hidden Ending")
            DigHiddenTrigger();
    }

    public void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {//현재 씬 이름을 비교해서 서로 다른 대화 트리거 발동
            if (SceneManager.GetActiveScene().name == "4-1 Nomal Ending")
                chatManager.DisplayNextNormalDig();
            else if (SceneManager.GetActiveScene().name == "4-2 Hidden Ending")
                chatManager.DisplayNextHiddenDig();
        }
    }
}
