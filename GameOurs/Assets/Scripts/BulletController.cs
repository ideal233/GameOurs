using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public GameObject bullet;
    public float attakPower;
    public float bulletFlySpeed;
    public float bulletExsitTime;
    public Vector3 direct;

    private float lifeCounter;
    void Start () {
        lifeCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
        lifeCounter += Time.deltaTime;
        transform.position += Time.deltaTime * direct * bulletFlySpeed;
        if (lifeCounter >= bulletExsitTime)
        {
            Destroy(bullet);
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
            Destroy(bullet);
}
    }
}
