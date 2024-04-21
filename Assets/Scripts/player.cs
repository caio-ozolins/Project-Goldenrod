using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Animator playerAnim;
    private Rigidbody2D rbPlayer;
    public float speed;
    private SpriteRenderer sr;
    public float jumpForce;
    public bool inFloor = true;
    public bool doubleJump;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rbPlayer = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Jump();
    }
    void MovePlayer()
    {
        float horizontalMoviment = Input.GetAxisRaw("Horizontal");
        //Debug.Log(horizontalMoviment);
        transform.position += new Vector3(horizontalMoviment * Time.deltaTime * speed,0,0);
        if (horizontalMoviment > 0)
        {
            playerAnim.SetBool("andar", true);
            sr.flipX = false;
        }
        else if (horizontalMoviment < 0)
        {
            playerAnim.SetBool("andar", true);
            sr.flipX = true;
        }
        else
        {
            playerAnim.SetBool("andar", false);
        }
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (inFloor)
            {
                rbPlayer.velocity = Vector2.zero;
                playerAnim.SetBool("pular", true);
                rbPlayer.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                inFloor = false;
                doubleJump = true;
            }
            else if (!inFloor && doubleJump)
            {
                rbPlayer.velocity = Vector2.zero;
                playerAnim.SetBool("pular", true);
                rbPlayer.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                inFloor = false;
                doubleJump = false;
            }
           
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Ground")
        {
            playerAnim.SetBool("pular", false);
            inFloor = true;
            doubleJump = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "picareta")
        {
            Destroy(collision.gameObject);
        }
    }
}
