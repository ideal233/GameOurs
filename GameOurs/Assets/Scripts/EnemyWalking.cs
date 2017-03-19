using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyWalking : MonoBehaviour {

    public GameObject player;
    public EnemyMove enemyMove;
    public GameObject enemy;

    public float animSpeed = 10;//1秒播放10帧
    private float animTimeInterval = 0;
    public AnimStatus status = AnimStatus.Idle;

    public SpriteRenderer render;  //空闲时的渲染器

    public Sprite[] idleSpriteArray;
    private int idleIndex = 0;
    private int idleArrayLength = 0;
    private float idleTimer = 0;

    //public SpriteRenderer walkRender;  //行走的渲染器

    public Sprite[] walkSpriteArray;
    private int walkIndex = 0;
    private int walkArrayLength = 0;
    private float walkTimer = 0;

    //public SpriteRenderer attackRender;  //攻击的渲染器

    public Sprite[] attackSpriteArray;
    private int attackIndex = 0;
    private int attackArrayLength = 0;
    private float attackTimer = 0;
    public void setAttackIndex(int i)
    {
        attackIndex = i;
    }
    public float distance(GameObject player)
    {
        Vector3 diff = player.transform.localPosition - enemy.transform.localPosition;
        return diff.magnitude;

    }

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        idleArrayLength = idleSpriteArray.Length;
        walkArrayLength = walkSpriteArray.Length;
        attackArrayLength = attackSpriteArray.Length;
        animTimeInterval = 1 / animSpeed;
	}
	
	// Update is called once per frame
	void Update () {

        render.sortingOrder = -(int)(enemy.transform.position.z * 100);
        render.sortingOrder = -(int)(enemy.transform.position.z * 100);
        render.sortingOrder = -(int)(enemy.transform.position.z * 100);

        if ((distance(player) <= 8.0f) && (status == AnimStatus.Idle))
        {
            enemyMove.enabled = true;
            status = AnimStatus.Walk;
        }

        switch (status)
        {
            case AnimStatus.Idle:
                idleTimer += Time.deltaTime;
                if (idleTimer > animTimeInterval)
                {
                    idleTimer -= animTimeInterval;
                    idleIndex++;
                    idleIndex %= idleArrayLength;
                    render.sprite = idleSpriteArray[idleIndex];

                }
                break;
            case AnimStatus.Walk:
                walkTimer += Time.deltaTime;
                if(walkTimer > animTimeInterval)
                {
                    walkTimer -= animTimeInterval;
                    walkIndex++;
                    walkIndex %= walkArrayLength;
                    render.sprite = walkSpriteArray[walkIndex];
                }
                break;
            case AnimStatus.Attack:
                attackTimer += Time.deltaTime;
                if (attackTimer > animTimeInterval)
                {
                    attackTimer -= animTimeInterval;
                    attackIndex++;
                    attackIndex %= attackArrayLength;
                    render.sprite = attackSpriteArray[attackIndex];
                }
                break;
        }
    }
}
