using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Mgr : MonoBehaviour
{
    public float speed;

    void Start()
    {
        Invoke("DestroyObj", 5);
    }

    void Update()
    {
        transform.Translate(transform.right * -1 * speed * Time.deltaTime); //왼쪽에서 날아오게   
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        DestroyObj();
    }

    private void DestroyObj()
    {
        Debug.Log("아, 짜증나!");
        Destroy(gameObject);
    }
}
