using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StressBar : MonoBehaviour
{
    [SerializeField]
    private Slider stressbar;
    [SerializeField]
    private Text stresstxt;
    [SerializeField]
    private GameObject gameover;
    [SerializeField]
    private Button replay;

    private float maxStress = 100;
    private float curStress = 0;

    void Start()
    {
        Time.timeScale = 1.0f;

        if (replay != null)
            replay.onClick.AddListener(ReplayClick);

        stressbar.value = (float)curStress / (float)maxStress;

        gameover.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (curStress >= 100)
        {
            gameover.SetActive(true);
            stresstxt.text = $"스트레스 지수 : {curStress}";
            Time.timeScale = 0.0f;
        }

        HandleStress();
    }
    
    private void HandleStress()
    {
        //stressbar.value = Mathf.Lerp(stressbar.value, (float)curStress / (float)maxStress, Time.deltaTime); //??
        stressbar.value = (float)curStress / (float)maxStress;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Book")
        {
            curStress += 10;
            curStress = Mathf.Min(curStress, 100);
            stresstxt.text = $"스트레스 지수 : {curStress}";
        }
        else if (other.gameObject.name == "Test")
        {
            curStress += 15;
            curStress = Mathf.Min(curStress, 100);
            stresstxt.text = $"스트레스 지수 : {curStress}";
        }
    }

    void ReplayClick()
    {
        SceneManager.LoadScene("GameScene");
    }
}
