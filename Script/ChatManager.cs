using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ChatManager : MonoBehaviour
{//대사 스크립트
    private SceneManagement sceneManager; // 대화 종료 후 Scene 변화를 위해 선언
    public Queue<string> textStorage; // 큐 형태로 대사 임시 저장
    public GameObject txtBox; // 대사를 출력할 오브젝트

    void Start()
    {
        textStorage = new Queue<string>();
    }

    public void StartDialog(DialogNormal dialogNormal)
    {// 오버라이딩으로 보통 엔딩 대사집 불러오기

        foreach (string sentence in dialogNormal.sentences)
        {// 보통 엔딩 대사를 textStorage에 넣기
            textStorage.Enqueue(sentence);
        }

        DisplayNextNormalDig(); // 대사 불러오기
    }

    public void StartDialog(DialogHidden dialogHidden)
    {// 오버라이딩으로 히든 엔딩 대사집 불러오기

        textStorage.Clear();

        foreach (string sentence in dialogHidden.sentences)
        {// 히든 엔딩 대사를 textStorage에 넣기
            textStorage.Enqueue(sentence);
        }
        DisplayNextHiddenDig();
    }

    public void DisplayNextNormalDig()
    {// 보통 엔딩 대사 출력
        if (textStorage.Count == 0)
        {// textStorage가 0이면 보통 엔딩 결말로 전환
            EndNormalDig();
        }
        Debug.Log(textStorage.Count);
        string sentence = textStorage.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypingEffect(sentence));
       
    }

    public void DisplayNextHiddenDig()
    {// 히든 엔딩 대사 출력
        if (textStorage.Count == 0)
        {// textStorage가 0이면 히든 엔딩 결말로 전환
            EndHiddenDig();
        }
        string sentence = textStorage.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypingEffect(sentence));
    }

    IEnumerator TypingEffect(string sentece)
    {// 대사 타이핑 효과
        txtBox.GetComponent<TextMeshProUGUI>().text = "";
        foreach (char txt in sentece.ToCharArray())
        {
            txtBox.GetComponent<TextMeshProUGUI>().text += txt;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void EndNormalDig()
    {// 보통 엔딩 결말
        SceneManager.LoadScene("1 Title Scene");
    }

    public void EndHiddenDig()
    {// 히든 엔딩 결말
        Application.Quit();
    }
}
