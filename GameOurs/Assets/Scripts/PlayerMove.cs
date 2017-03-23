using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed = 3;
    public float jumpSpeed = 15;

    private Rigidbody rigidbody;
    private float jumpTimer = 0;
    private float originY;
    private bool isMoving = false;
    private bool isJumping = false;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        originY = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        Vector3 hv = rigidbody.velocity;
        rigidbody.velocity = new Vector3(h * speed, hv.y, hv.z);
        if (h != 0)
            GetComponent<Transform>().localScale = new Vector3(2 * (h / Mathf.Abs(h)), 2, 2);
        float vertical = Input.GetAxis("Vertical");
        Vector3 vv = rigidbody.velocity;
        rigidbody.velocity = new Vector3(vv.x, vv.y, vertical * speed);

        if ((h != 0) || (vertical != 0))
            isMoving = true;
        else
            isMoving = false;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimer += Time.deltaTime;

        }
        if (jumpTimer - 0 >= 0.0001f)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, jump(jumpSpeed, ref jumpTimer) + originY, transform.localPosition.z);

        }

    }

    float jump(float jumpSpeed, ref float timer)
    {
        float temp;
        if (timer <= 0.99999f && timer >= 0.000001f)
        {
            temp = -jumpSpeed * timer * timer + jumpSpeed * timer;
            timer += Time.deltaTime;
            return temp;
        }

        else if (timer >= 0.99999f)
        {
            isJumping = false;
            timer = 0;
            return 0;
        }
        else
            return 0;


    }
    public bool GetMoveFlag()
    {
        return isMoving;
    }
    public bool GetJumpFlag()
    {
        return isJumping;
    }
}
