using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedGoblinController : EnemyController
{

    // Use this for initialization
    public GameObject player;
    public GameObject enemy;
    public float attackPower = 10;
    public float attakInterval = 3f;
    public float Health = 100f;

    public float xRange = 0.7f;
    public float yRange = 0.2f;
    public float zRange = 0.1f;

    private float attackCounter = 0;
    private bool isAttack;
    private PlayerController playerController;
    public RedGoblinAttack enemyAttack;
    public EnemyMove enemyMove;

    public EnemyWalking enemyWalking;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {


        attackCounter += Time.deltaTime;
        if (attackCounter > attakInterval && isPlayerInField())
        {
            attackCounter = 0;
            Debug.Log("Begin Attak");
            enemyWalking.status = AnimStatus.Attack;
            enemyWalking.setAttackIndex(0);
            enemyAttack.enabled = true;
            enemyMove.enabled = false;

        }
    }

    private bool isPlayerInField()
    {
        Vector3 enemyPosition = enemy.transform.position;
        Vector3 playerPosition = player.transform.position;
        float zDif = enemyPosition.z - playerPosition.z;
        float xDif = (enemyPosition + enemy.transform.localScale.x * Vector3.right * 1.2f).x - playerPosition.x;
        float yDif = enemyPosition.y - playerPosition.y;
        if (Mathf.Abs(xDif) <= xRange && Mathf.Abs(yDif) <= yRange && Mathf.Abs(zDif) <= zRange)
        {
            Debug.Log("Distance is =" + new Vector3(xDif, yDif, zDif));
            return true;
        }

        else
            return false;
    }

    public void GetDamaged(float damage)
    {
        Health -= damage;
        Debug.Log(Health);
        if (Health <= 0)
        {
            Die();
        }
        else
        {
            enemyMove.enabled = false;
            enemy.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            enemyWalking.status = AnimStatus.BeAttacked;
        }


    }

    public void Die()
    {
        enemyMove.enabled = false;
        enemy.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        enemyWalking.status = AnimStatus.Die;
    }
}

