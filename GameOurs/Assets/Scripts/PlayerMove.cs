using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float speed = 3;
    public float jumpSpeed = 15;

    //private Transform transform;
    //private int groundLayerMask;*/
    private Rigidbody rigidbody;
    private float jumpTimer = 0;
    private float originY;
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        originY = transform.localPosition.y;
        //transform = GetComponent<Transform>();
        //groundLayerMask = LayerMask.GetMask("Env");

    }
	
	// Update is called once per frame
	void Update () {
        //Vector3 originPosition = transform.localPosition;
        //Vector3 nextPosition = transform.localPosition;
        float h = Input.GetAxis("Horizontal");
        //nextPosition += new Vector3(h * speed, 0, 0) * Time.deltaTime;
       // float verticalSpeed = Input.GetAxis("Vertical");
        //nextPosition += new Vector3(0, 0, verticalSpeed * speed) * Time.deltaTime;
        Vector3 hv = rigidbody.velocity;
        rigidbody.velocity = new Vector3(h * speed, hv.y, hv.z);

        float vertical = Input.GetAxis("Vertical");
        Vector3 vv = rigidbody.velocity;
        rigidbody.velocity = new Vector3(vv.x, vv.y,vertical * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, jumpSpeed, GetComponent<Rigidbody>().velocity.z);
            jumpTimer += Time.deltaTime;
        

        }
        if (jumpTimer - 0 >= 0.0001f)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, jump(jumpSpeed,ref jumpTimer) + originY, transform.localPosition.z);
            
        }
        //RaycastHit hitInfo1;
       // bool isCollierRight = Physics.Raycast(nextPosition + Vector3.left * 0.1f, Vector3.right, out hitInfo1, 0.2f);
        //RaycastHit hitInfo2;
       // bool isCollierRight = Physics.Raycast(nextPosition + Vector3.left * 0.1f, Vector3.right, out hitInfo1, 0.2f);
       // RaycastHit hitInfo3;
       // bool isCollierRight = Physics.Raycast(nextPosition + Vector3.left * 0.1f, Vector3.right, out hitInfo1, 0.2f);
       // RaycastHit hitInfo4;
       // bool isCollierRight = Physics.Raycast(nextPosition + Vector3.left * 0.1f, Vector3.right, out hitInfo1, 0.2f);
       // if (isCollier)
       // {
       //     transform.position = originPosition;
       // }
       // else
       // {
       //     transform.position = nextPosition;
       // }
	}

    float jump(float jumpSpeed,ref float timer)
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
            timer = 0;
            return 0;
        }
        else
            return 0;
            
            
    }
}
