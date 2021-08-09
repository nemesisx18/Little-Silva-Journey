using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class barollController : MonoBehaviour
{
    public float walkSpeed = 1.0f;
    public float wallLeft = 0.0f;
    public float wallRight = 4.0f;

    public GameObject gameOverCanvas;

    float walkingDirection = 1.0f;
    Vector2 walkAmount;
    float originalX;
    
    // Start is called before the first frame update
    void Start()
    {
        this.originalX = this.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
        if (walkingDirection > 0.0f && transform.position.x >= originalX + wallRight)
        {
            walkingDirection = -1.0f;
        }
        else if (walkingDirection < 0.0f && transform.position.x <= originalX - wallLeft)
        {
            walkingDirection = 1.0f;
        }
        transform.Translate(walkAmount);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);

            gameOverCanvas.SetActive(true);
        }
    }
}
