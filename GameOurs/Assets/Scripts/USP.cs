using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USP : MonoBehaviour
{

    public float attakPower = 5;
    public float bulletFlySpeed = 5f;
    public float bulletExsitTime = 1f;
    public GameObject bullet;
    public GameObject player;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            GameObject newBullet = Instantiate(bullet);
            BulletController newBulletController = newBullet.GetComponent<BulletController>();
            newBulletController.attakPower = attakPower;
            newBulletController.bulletFlySpeed = bulletFlySpeed;
            newBulletController.bulletExsitTime = bulletExsitTime;
            newBullet.transform.position = player.transform.position + Vector3.right * player.transform.localScale.x;
            newBulletController.direct = Vector3.right * player.transform.localScale.x;

        }
    }

}