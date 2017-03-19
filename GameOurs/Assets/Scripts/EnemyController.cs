/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    // Use this for initialization
    public GameObject player;
    public float attackDistance = 2f;
    public float attackRadius = 1f;
    public float attackPower = 10;
    public float attakInterval = 3f;


    private float attackCounter = 0;
    private bool isAttack;
    private PlayerController playerController;
    public EnemyAttack enemyAttack;
    public EnemyMove enemyMove;

    public EnemyWalking enemyWalking;

    void Start () {
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
        Vector3 attackCenter = transform.position + Vector3.right * transform.localScale.x * attackDistance;
        return (Vector3.Distance(player.transform.position, attackCenter) <= attackRadius);
    }
}*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    // Use this for initialization
    public GameObject player;
    public GameObject enemy;
    public float attackDistance = 2f;
    public float attackRadius = 1f;
    public float attackPower = 10;
    public float attakInterval = 3f;
    public float Health = 100f;


    private float attackCounter = 0;
    private bool isAttack;
    private PlayerController playerController;
    public EnemyAttack enemyAttack;
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
        Vector3 attackCenter = enemy.transform.position + Vector3.right * enemy.transform.localScale.x * attackDistance;
        return (Vector3.Distance(player.transform.position, attackCenter) <= attackRadius);
    }

    public void GetDamaged(float damage)
    {
        Health -= damage;
        Debug.Log(Health);
        if (Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {

    }
}

