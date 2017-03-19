using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimStatus
{
    Idle,
    Walk,
    Attack
}

public class PlayerRender : MonoBehaviour
{

    public float animSpeed = 10;//1秒播放10帧
    private float animTimeInterval = 0;
    public AnimStatus status = AnimStatus.Idle;

    public SpriteRenderer walkingRender;  //行走的渲染器

    public Sprite[] walkingSpriteArray;

    public GameObject player;

    private int walkingIndex = 0;
    private int walkingArrayLength = 0;
    private float walkingTimer = 0;

    public Sprite idleSprite;

    // Use this for initialization
    void Start()
    {
        walkingArrayLength = walkingSpriteArray.Length;
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
                    walkingRender.sprite = walkingSpriteArray[walkingIndex];

                }
                break;

            case AnimStatus.Idle:
                walkingRender.sprite = idleSprite;
                break;

        }

    }
}

