using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyPlayer : MonoBehaviour
{
    public GameObject gameOverCanvas;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);

        gameOverCanvas.SetActive(true);
    }

}
