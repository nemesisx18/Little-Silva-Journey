using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinStage1 : MonoBehaviour
{
    public GameObject winCanvas;
    public GameObject uiCanvas;
    public GameObject player;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("You WIN!!!!!!!!");

        winCanvas.SetActive(true);
        player.SetActive(false);
    }
}
