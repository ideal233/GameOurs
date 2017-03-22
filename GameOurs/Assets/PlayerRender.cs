using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimStatus
{
    Idle,
    Walk,
    Attack,
    Die,
    BeAttacked,
    Jump,
    JumpAttack
}

public class PlayerRender : MonoBehaviour
{

    public float animSpeed = 10;//1秒播放10帧
    private float animTimeInterval = 0;
    public AnimStatus status = AnimStatus.Idle;

    public SpriteRenderer render;  //渲染器

    public Sprite[] walkingSpriteArray;

    public GameObject player;

    private int walkingIndex = 0;
    private int walkingArrayLength = 0;
    private float walkingTimer = 0;

    public Sprite[] idleSpriteArray;

    private int idleIndex = 0;
    private int idleArrayLength = 0;
    private float idleTimer = 0;


    // Use this for initialization
    void Start()
    {
        walkingArrayLength = walkingSpriteArray.Length;
        idleArrayLength = idleSpriteArray.Length;
        animTimeInterval = 1 / animSpeed;//得到每一帧的时间间隔

    }

    // Update is called once per frame
    void Update()
    {

        switch (status)
        {
            case AnimStatus.Walk:
                walkingTimer += Time.deltaTime;
                if (walkingTimer > animTimeInterval)
                {
                    walkingTimer -= animTimeInterval;
                    walkingIndex++;
                    walkingIndex %= walkingArrayLength;
                    render.sprite = walkingSpriteArray[walkingIndex];

                }
                break;

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

        }

    }
}

