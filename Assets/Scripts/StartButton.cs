using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void StartGame() {
        Debug.Log("StartedGame");
        SceneManager.LoadScene(1);
    }
}
