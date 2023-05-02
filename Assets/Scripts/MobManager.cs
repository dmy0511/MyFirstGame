using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MobManager : MonoBehaviour
{
    public GameObject obj;
    public Transform pos;
    public float waitSecond;

    void Start()
    {
        StartCoroutine(CreateBookRoutione());
    }

    IEnumerator CreateBookRoutione()
    {
        while(true)
        {
            CreateBook();
            yield return new WaitForSeconds(waitSecond);
        }
    }

    private void CreateBook()
    {
        var cloneObj = Instantiate(obj, pos.position, Quaternion.identity);

        cloneObj.name = obj.name;
    }
}
