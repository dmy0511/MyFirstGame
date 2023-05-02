using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home_Btn : MonoBehaviour
{
    public void SceneLoad(string MainScene)
    {
        SceneManager.LoadScene(MainScene);
    }
}
