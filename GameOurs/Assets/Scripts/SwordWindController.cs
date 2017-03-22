using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordWindController : MonoBehaviour {
    public GameObject player;
    public GameObject swordWind;
    public float attakPower;
    public float bulletFlySpeed;
    public float bulletExsitTime;
    public float exsitTime;
    public Vector3 direct;


    private float lifeCounter;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 playerScale = player.transform.localScale;
        swordWind.transform.localScale = playerScale;
        swordWind.transform.position = player.transform.position + playerScale.x * Vector3.right;
        direct = player.transform.localScale.x * Vector3.right;
        lifeCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        lifeCounter += Time.deltaTime;
        transform.position += Time.deltaTime * direct * bulletFlySpeed;
        if (lifeCounter >= exsitTime)
        {
            Destroy(swordWind);
        }


    }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("haha");
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("yiyi");
            EnemyController colliderController = other.GetComponent<EnemyController>();
            colliderController.GetDamaged(attakPower);
            Destroy(swordWind);
        }
    }
}
