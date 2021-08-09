using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public AudioClip ambilPoint;
    public Text pointText;

    //public bool isGrounded;

    Rigidbody2D rb;
    Animator anim;

    bool isJump = true;
    int idMove = 0;

    private AudioSource MediaPoint;
    private int point;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        MediaPoint = gameObject.AddComponent<AudioSource>();
        MediaPoint.clip = ambilPoint;

        point = 0;
        SetPointText();
    }

    void OnCollisionStay2D()
    {
        if (isJump)
        {
            if (idMove == 00) anim.SetTrigger("idle");

            isJump = false;
        }
    }
    void OnCollisionExit2D()
    {
        isJump = true;
    }

    void Update()
    {
        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        //Move
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            Idle();
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            Idle();
        }
        
        Move();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            other.gameObject.SetActive(false);

            point = point + 1;

            MediaPoint.Play();
            SetPointText();
        }
    }

    void SetPointText()
    {
        pointText.text = " " + point.ToString();
    }

    public void MoveRight()
    {
        idMove = 1;
    }
    
    public void MoveLeft()
    {
        idMove = 2;
    }

    private void Move()
    {
        if(idMove == 1)
        {
            if(!isJump) anim.SetTrigger("run");

            transform.Translate(1 * Time.deltaTime * 4f, 0, 0);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (idMove == 2)
        {
            if(!isJump) anim.SetTrigger("run");
            
            transform.Translate(-1 * Time.deltaTime * 4f, 0, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    public void Jump()
    {
        if (!isJump)
        {
            if (GetComponent<Rigidbody2D>().velocity.y < 1)

                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 550f);
        }
    }

    public void Idle()
    {
        if (!isJump)
        {
            anim.ResetTrigger("run");
            anim.SetTrigger("idle");
        }

        idMove = 0;
    }
}
