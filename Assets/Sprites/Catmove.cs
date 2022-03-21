using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catmove : MonoBehaviour
{
    public float moveSpeed = 1;
    public float jumpForce = 50;
    public Transform player;
    public Vector3 offset;
    public bool isground = true;
    public Vector2 speed = new Vector2(1, 1);

    private Vector2 movement = new Vector2(1, 1);
    Rigidbody2D rb;

    // Use this for initialization
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    public void Update()
    {
        float inputX = Input.GetAxis("Horizontal");

        if (inputX != 0)
        {
            rb.AddForce(new Vector2(inputX * moveSpeed, 0f), ForceMode2D.Impulse);
            var moveDir = (transform.right * moveSpeed) * inputX;
            transform.Translate(moveDir * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                rb.velocity = Vector2.zero;
                
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) && isground)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isground = false;

        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        isground = false;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isground = true;
    }



}