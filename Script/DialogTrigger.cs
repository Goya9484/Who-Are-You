using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogTrigger : MonoBehaviour
{
    public ChatManager chatManager;
    public DialogNormal dialogNormal; //���� ���� �����
    public DialogHidden dialogHidden; //���� ���� �����

    public void DigNormalTrigger()
    {//���� ���� Ʈ����
        FindObjectOfType<ChatManager>().StartDialog(dialogNormal);
    }

    public void DigHiddenTrigger()
    {//���� ���� Ʈ����
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
        {//���� �� �̸��� ���ؼ� ���� �ٸ� ��ȭ Ʈ���� �ߵ�
            if (SceneManager.GetActiveScene().name == "4-1 Nomal Ending")
                chatManager.DisplayNextNormalDig();
            else if (SceneManager.GetActiveScene().name == "4-2 Hidden Ending")
                chatManager.DisplayNextHiddenDig();
        }
    }
}
