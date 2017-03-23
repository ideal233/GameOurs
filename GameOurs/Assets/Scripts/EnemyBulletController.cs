using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour {

    public GameObject enemyBullet;
    public float attackPower;
    public float exsitTime = 1.0f;
    public GameObject enemy;
    public float bulletFlySpeed = 1;
    private RedGoblinController redGoblinController;
    private Vector3 direct;

    private float lifeCounter;

    void Start()
    {
        redGoblinController = enemy.GetComponent<RedGoblinController>();
        lifeCounter = 0;
        direct = (enemy.transform.localScale.x)/(Mathf.Abs(enemy.transform.localScale.x)) * Vector3.right;
        enemyBullet.transform.localPosition = enemy.transform.localPosition + direct;
        enemyBullet.transform.localScale = new Vector3(enemy.transform.localScale.x / Mathf.Abs(enemy.transform.localScale.x) * enemyBullet.transform.localScale.x,
                                                         enemyBullet.transform.localScale.y, enemyBullet.transform.localScale.z);
        attackPower = redGoblinController.attackPower;
    }


    void Update()
    {
        lifeCounter += Time.deltaTime;
        GetComponent<Transform>().position += Time.deltaTime * direct * bulletFlySpeed;
        if (lifeCounter >= exsitTime)
        {
            Destroy(enemyBullet);
        }


    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            playerController.GetDamaged(attackPower);
            Destroy(enemyBullet);
        }
    }
}
