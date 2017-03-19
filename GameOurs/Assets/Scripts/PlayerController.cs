using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
    public float playerTotalHealth = 100f;
    public SpriteRenderer playerWalkingRenderer;
    private float playerNowHealth;

    void Start () {
        playerNowHealth = playerTotalHealth;
    }
	
	// Update is called once per frame
	void Update () {
        playerWalkingRenderer.sortingOrder = -(int)(transform.localPosition.z * 100);
	}

    public void GetDamaged(float lossHealth)
    {
        playerNowHealth -= lossHealth;
        Debug.Log(playerNowHealth);
        if (playerNowHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("you die");
    }

}
