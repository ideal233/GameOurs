using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAfterAttack : MonoBehaviour {

    public float backTime = 0.5f;
    public EnemyMove em;

    private float timer = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if(timer <= backTime)
        {
            GetComponent<Rigidbody>().velocity = (new Vector3((transform.localScale.x) / Mathf.Abs(transform.localScale.x), 0, 0)) * em.moveSpeed;
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            em.enabled = true;
            enabled = false;
        }
	}
}
