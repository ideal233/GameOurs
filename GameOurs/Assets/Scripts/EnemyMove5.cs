using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove5 : MonoBehaviour {


    public float moveSpeed = 3f;
    public GameObject player;

    private Rigidbody rigidBody;
    private Vector3 originDirect;
    private Vector3 direct;
	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        originDirect = player.transform.position - transform.position;
        direct = Vector3.Normalize(originDirect);
        if(direct.x < 0 && originDirect.magnitude > 0.1f)
        {

            rigidBody.transform.localScale = new Vector3(-Mathf.Abs(rigidBody.transform.localScale.x), rigidBody.transform.localScale.y, rigidBody.transform.localScale.z);
        }
        else if (direct.x > 0 && originDirect.magnitude > 0.1f)
        {
            rigidBody.transform.localScale = new Vector3(Mathf.Abs(rigidBody.transform.localScale.x), rigidBody.transform.localScale.y, rigidBody.transform.localScale.z);
        }
        if (originDirect.magnitude >= 1.0f)
            rigidBody.velocity = direct * moveSpeed;
        else
            rigidBody.velocity = new Vector3(0, 0, 0);


	}
}
