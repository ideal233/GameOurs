using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;
    public float attakPower;
    public float bulletFlySpeed;
    public float bulletExsitTime;
    public Vector3 direct;

    private float lifeCounter;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lifeCounter = 0;
        direct = player.transform.localScale.x * Vector3.right;
        bullet.transform.position = player.transform.position + direct;
    }

    // Update is called once per frame
    void Update()
    {
        lifeCounter += Time.deltaTime;
        transform.position += Time.deltaTime * direct * bulletFlySpeed;
        if (lifeCounter >= bulletExsitTime)
        {
            Destroy(bullet);
        }


    }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("haha");
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("yiyi");
            EnemyController colliderController = other.GetComponent<EnemyController>();
            colliderController.GetDamaged(attakPower);
            Destroy(bullet);
        }
    }
}
