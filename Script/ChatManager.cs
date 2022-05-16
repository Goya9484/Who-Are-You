using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ChatManager : MonoBehaviour
{//��� ��ũ��Ʈ
    private SceneManagement sceneManager; // ��ȭ ���� �� Scene ��ȭ�� ���� ����
    public Queue<string> textStorage; // ť ���·� ��� �ӽ� ����
    public GameObject txtBox; // ��縦 ����� ������Ʈ

    void Start()
    {
        textStorage = new Queue<string>();
    }

    public void StartDialog(DialogNormal dialogNormal)
    {// �������̵����� ���� ���� ����� �ҷ�����

        foreach (string sentence in dialogNormal.sentences)
        {// ���� ���� ��縦 textStorage�� �ֱ�
            textStorage.Enqueue(sentence);
        }

        DisplayNextNormalDig(); // ��� �ҷ�����
    }

    public void StartDialog(DialogHidden dialogHidden)
    {// �������̵����� ���� ���� ����� �ҷ�����

        textStorage.Clear();

        foreach (string sentence in dialogHidden.sentences)
        {// ���� ���� ��縦 textStorage�� �ֱ�
            textStorage.Enqueue(sentence);
        }
        DisplayNextHiddenDig();
    }

    public void DisplayNextNormalDig()
    {// ���� ���� ��� ���
        if (textStorage.Count == 0)
        {// textStorage�� 0�̸� ���� ���� �ḻ�� ��ȯ
            EndNormalDig();
        }
        Debug.Log(textStorage.Count);
        string sentence = textStorage.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypingEffect(sentence));
       
    }

    public void DisplayNextHiddenDig()
    {// ���� ���� ��� ���
        if (textStorage.Count == 0)
        {// textStorage�� 0�̸� ���� ���� �ḻ�� ��ȯ
            EndHiddenDig();
        }
        string sentence = textStorage.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypingEffect(sentence));
    }

    IEnumerator TypingEffect(string sentece)
    {// ��� Ÿ���� ȿ��
        txtBox.GetComponent<TextMeshProUGUI>().text = "";
        foreach (char txt in sentece.ToCharArray())
        {
            txtBox.GetComponent<TextMeshProUGUI>().text += txt;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void EndNormalDig()
    {// ���� ���� �ḻ
        SceneManager.LoadScene("1 Title Scene");
    }

    public void EndHiddenDig()
    {// ���� ���� �ḻ
        Application.Quit();
    }
}
