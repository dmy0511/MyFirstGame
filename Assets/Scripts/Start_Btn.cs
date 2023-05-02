using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Btn : MonoBehaviour
{
    public void SceneLoad(string GameScene)
    {
        SceneManager.LoadScene(GameScene);
    }
}
