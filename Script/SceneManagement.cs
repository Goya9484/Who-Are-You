using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagement : MonoBehaviour
{
    public static int ceremonyCount = 0;
    public static int hiddenItemCheck = 0;
    public static int dollCount = 0;

    public GameObject doll;

    private void Update()
    {
        if (dollCount == 2)
        {
            StartCoroutine(Delay(doll));
        }

        if (ceremonyCount == 4)
        {
            if(hiddenItemCheck == 4)
                SceneManager.LoadScene("4-2 Hidden Ending");
            else
                SceneManager.LoadScene("4-1 Nomal Ending");
        }
    }

    public void Move1TitleScene()
    {
        SceneManager.LoadScene("1 Title Scene");
    }

    public void Move2TutorialScene()
    {
        SceneManager.LoadScene("2 Tutorial Map");
    }

    public void GameQuit()
    {
        Application.Quit();
    }

    IEnumerator Delay(GameObject doll)
    {
        yield return new WaitForSecondsRealtime(3.0f);
        doll.GetComponent<DollAI>().enabled = true;
    }
}
