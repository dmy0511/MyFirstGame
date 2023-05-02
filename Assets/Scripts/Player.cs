using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0.0f;
    [SerializeField]
    private float jumpPower = 400;
    
    [SerializeField]
    private Text scoreText;

    [SerializeField]
    Transform pos;
    [SerializeField]
    float checkRadius;
    [SerializeField]
    LayerMask islayer;

    public int jumpCount;
    
    int jumpCnt;

    private float score = 0f;
    
    private AudioSource audio;

    bool isGround;
    
    Rigidbody2D rigid;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        InvokeRepeating("ScoreUp", 1, 1);
        jumpCnt = jumpCount;
    }

    private void Update()
    {
        isGround = Physics2D.OverlapCircle(pos.position, checkRadius, islayer);

        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    
        if(isGround == true && Input.GetButtonDown("Jump") && jumpCnt > 0)
        {
            rigid.AddForce(Vector2.up * jumpPower);
        }
        if (isGround == false && Input.GetButtonDown("Jump") && jumpCnt > 0)
        {
            rigid.AddForce(Vector2.up * jumpPower);
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            jumpCnt--;
        }
        if(isGround)
        {
            jumpCnt = jumpCount;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        jumpPower = 400;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("앗 차가워!");
        GetComponent<SpriteRenderer>().color = Color.blue;

        jumpPower = 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        score -= 30;
        scoreText.text = $"점수 : {score}";
        audio.Play();
    }

    private void ScoreUp()
    {
        score += 10;
        scoreText.text = $"점수 : {score}";
    }
}
