using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPController : MonoBehaviour {

    public GameObject player;
    public GameObject HP;
    public float HealingPower = 5;
    public float exsitTime = 0.2f;

    private float lifeCounter;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lifeCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        lifeCounter += Time.deltaTime;
        if (lifeCounter >= exsitTime)
        {
            Healing();
            Destroy(HP);
        }
    }

    void Healing()
    {
        PlayerController playerController = player.GetComponent<PlayerController>();
        playerController.GetHealed(HealingPower);
        
    }

}
