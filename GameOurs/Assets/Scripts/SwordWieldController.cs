using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordWieldController : MonoBehaviour {
    public GameObject player;
    public GameObject swordWield;
    public float attackPower;
    public float exsitTime;
    public Vector3 direct;


    private float lifeCounter;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 playerScale = player.transform.localScale;
        swordWield.transform.localScale = playerScale;
        swordWield.transform.position = player.transform.position + Vector3.right * playerScale.x * 0.5f;
        direct = player.transform.localScale.x * Vector3.right;
        WeaponController weaponController = player.GetComponent<WeaponController>();
        attackPower = weaponController.swordWindDamage;
        lifeCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        lifeCounter += Time.deltaTime;
        if (lifeCounter >= exsitTime)
        {
            Destroy(swordWield);
        }


    }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("haha");
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("yiyi");
            EnemyController colliderController = other.GetComponent<EnemyController>();
            colliderController.GetDamaged(attackPower);
            Destroy(swordWield);
        }
    }
}
