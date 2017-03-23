using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageColliderContoller : MonoBehaviour {

    public GameObject player;
    public GameObject enemy;
    public GameObject damageCollider;
    public float attackPower;
    public float exsitTime;


    private float lifeCounter;

    void Start()
    {
        lifeCounter = 0;
    }
    

    void Update()
    {
        lifeCounter += Time.deltaTime;
        if (lifeCounter >= exsitTime)
        {
            Destroy(damageCollider);
        }


    }


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {

            PlayerController playerController = other.GetComponent<PlayerController>();
            playerController.GetDamaged(attackPower);
        }
    }
}
