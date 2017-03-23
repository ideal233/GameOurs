using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedGoblinAttack : MonoBehaviour
{

    // Use this for initialization
    public GameObject player;
    public GameObject enemy;
    public RedGoblinController enemyController;
    public EnemyMove enemyMove;
    public Rigidbody rigidBody;
    public EnemyAfterAttack eaa;
    public double backPossibility = 0.3;
    public GameObject enemyBulletPrototype;

    private float attackTimeCounter;
    private bool isAttack;
    private PlayerController playerController;

    public EnemyWalking enemyWalking;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();

    }

    void OnEnable()
    {
        rigidBody.velocity = new Vector3(0, 0, 0);
        isAttack = true;
        attackTimeCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        attackTimeCounter += Time.deltaTime;
        if (attackTimeCounter >= 0.65 && isAttack)
        {
            isAttack = false;
            Attack(player);
        }
        else if (attackTimeCounter >= 1.0f)
        {
            if (Tool.choose(backPossibility))
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
        GameObject enemyBullet = Instantiate(enemyBulletPrototype);
        EnemyBulletController enemyBulletController = enemyBullet.GetComponent<EnemyBulletController>();
        Vector3 enemyLocalScale = enemy.transform.localScale;
        //enemyBullet.transform.position = enemy.transform.localPosition + 1.2f * enemyLocalScale.x * Vector3.right;
        //enemyBullet.transform.localScale = new Vector3(enemyLocalScale.x, 1, 1);
        enemyBulletController.enemy = enemy;

    }
}


