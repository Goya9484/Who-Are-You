using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InInventoryable : MonoBehaviour
{

    [HideInInspector]
    public Vector3 initScale;
    public Vector3 targetSize;
    public Vector3 targetRotate;

    public bool isInable = true;

    // Start is called before the first frame update
    void Start()
    {
        initScale = transform.localScale;
        StartCoroutine(CoolTime());
    }

    IEnumerator CoolTime()
    {// �������� ������ ��ٷ� �ٽ� ����־����°� ������ ���� ��Ÿ��
        while(true)
        {
            yield return null;
            if(isInable == false)
            {
                yield return new WaitForSeconds(2);
                isInable = true;
            }
        }
    }

}
