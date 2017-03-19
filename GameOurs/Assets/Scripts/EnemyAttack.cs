using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    // Use this for initialization
    public GameObject player;
    public GameObject enemy;
    public EnemyController enemyController;
    public EnemyMove enemyMove;
    public Rigidbody rigidBody;
    public EnemyAfterAttack eaa;
    public double backPossibility = 0.3;


    private float attackDistance;
    private float attackRadius;
    private float attackPower;
    private float attackTimeCounter;
    private bool isAttack;
    private PlayerController playerController;

    public EnemyWalking enemyWalking;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        attackDistance = enemyController.attackDistance;
        attackRadius = enemyController.attackRadius;
        attackPower = enemyController.attackPower;

    }

    void OnEnable()
    {
        rigidBody.velocity = new Vector3(0, 0, 0);
        isAttack = true;
        attackTimeCounter = 0;
    }

    // Update is called once per frame
    void Update () {
        attackTimeCounter += Time.deltaTime;
        if (attackTimeCounter >= 0.5 && isAttack)
        {
            isAttack = false;
            Attack(player);
        }
        else if (attackTimeCounter >= 1.0f)
        {
            if(Tool.choose(backPossibility))
            {
                eaa.enabled = true;
                enemyWalking.status = AnimStatus.Walk;
                enabled = false;
            }
            else
            {
                enemyMove.enabled = true;
                enemyWalking.status = AnimStatus.Walk;
                enabled = false;
            }

        }
	}

    void Attack(GameObject player)
    {

        Vector3 attackCenter = enemy.transform.position + Vector3.right * enemy.transform.localScale.x * attackDistance;
        isAttack = false;
        if (Vector3.Distance(player.transform.position, attackCenter) <= attackRadius)
        {
            playerController.GetDamaged(attackPower);
        }
    }
}
