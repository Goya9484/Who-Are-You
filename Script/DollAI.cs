using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using TMPro;

public class DollAI : MonoBehaviour
{
    NavMeshAgent nav;
   public Transform target;
    int speed;
    bool isOnNav = true;
    public GameObject dialog;
    public GameObject doll;
    public AudioSource Bgm;
   

    private void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        doll=GameObject.Find("Player");
        Bgm = gameObject.GetComponent<AudioSource>();
        Bgm.Play();
    }

    private void Update()
    {
        this.transform.LookAt(target);

        if (isOnNav)
            navmesh();
        else
            nav.enabled = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            SceneManager.LoadScene("1 Title Scene");
        }
    }

    public void navmesh()
    {
        if (nav.destination != target.transform.position)
        {
            nav.SetDestination(target.transform.position);
        }
        else
        {
            nav.SetDestination(transform.position);
        }

        if (target != null)
        {
            Vector3 relativePos = target.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(relativePos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * speed);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "SaltWater")
        {
            Debug.Log("소금물 부딪힘");
            isOnNav = false;
            dialog.SetActive(true);
            dialog.transform.Find("Txt").GetComponent<TextMeshProUGUI>().text = "의식에 성공한 것 같다!";
            dialog.transform.Find("Explan").GetComponent<TextMeshProUGUI>().text = "A버튼을 누르세요";
            other.GetComponent<Rigidbody>().isKinematic = true;
            if (OVRInput.GetDown(OVRInput.Button.One))
                StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSecondsRealtime(3);
        SceneManagement.ceremonyCount++;
        Debug.Log(SceneManagement.ceremonyCount);
        dialog.SetActive(false);
        gameObject.SetActive(false);
    }
}










