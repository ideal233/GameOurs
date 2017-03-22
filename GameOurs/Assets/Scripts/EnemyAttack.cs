using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    // Use this for initialization
    public GameObject player;
    public GameObject enemy;
    public EnemyController enemyController;
    public EnemyMove enemyMove;
    public Rigidbody rigidBody;
    public EnemyAfterAttack eaa;
    public double backPossibility = 0.3;
    public GameObject damageColliderPrototype;

    private float attackPower;
    private float attackTimeCounter;
    private bool isAttack;
    private PlayerController playerController;

    public EnemyWalking enemyWalking;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        attackPower = enemyController.attackPower;

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
        GameObject damageCollider = Instantiate(damageColliderPrototype);
        DamageColliderContoller damageColliderController = damageCollider.GetComponent<DamageColliderContoller>();
        damageColliderController.player = player;
        damageColliderController.enemy = enemy;
        damageColliderController.attackPower = attackPower;
        Vector3 enemyLocalScale = enemy.transform.localScale;
        damageCollider.transform.localPosition = enemy.transform.localPosition + 1.2f * enemyLocalScale.x * Vector3.right;
        damageCollider.transform.localScale = new Vector3(enemyLocalScale.x, 1, 1);

    }
}
