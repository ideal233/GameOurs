using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
    public float playerTotalHealth = 100f;
    public SpriteRenderer playerWalkingRenderer;
    private float playerNowHealth;
    public UISlider bloodSlider;

    public PlayerRender playerReander;
    public PlayerMove playerMove;
    public WeaponController weaponController;

    void Start () {
        playerNowHealth = playerTotalHealth;
    }
	
	// Update is called once per frame
	void Update () {
        playerWalkingRenderer.sortingOrder = -(int)(transform.localPosition.z * 100);
        if((playerMove.GetMoveFlag() == false)&&(playerMove.GetJumpFlag() == false)&&(weaponController.GetAttackflag() == false))
        {
            playerReander.status = AnimStatus.Idle;
        }
        else if((playerMove.GetMoveFlag() == true) && (playerMove.GetJumpFlag() == false) && (weaponController.GetAttackflag() == false))
        {
            playerReander.status = AnimStatus.Walk;
        }
        else if((playerMove.GetJumpFlag() == true) && (weaponController.GetAttackflag() == false))
        {
            playerReander.status = AnimStatus.Jump;
        }
        else if((weaponController.GetAttackflag() == true)&& (playerMove.GetJumpFlag() == true))
        {
            playerReander.status = AnimStatus.JumpAttack;
        }
        else if((weaponController.GetAttackflag() == false) && (playerMove.GetJumpFlag() == true))
        {
            playerReander.status = AnimStatus.Attack;
        }
	}

    public void GetHealed(float addHealth)
    {
          
        playerNowHealth += addHealth;
        if (playerNowHealth > playerTotalHealth)
            playerNowHealth = playerTotalHealth;
        bloodSlider.value = playerNowHealth / playerTotalHealth;

    }


    public void GetDamaged(float lossHealth)
    {
        playerNowHealth -= lossHealth;
        Debug.Log(playerNowHealth);
        if (playerNowHealth <= 0)
        {
            Die();
        }
        bloodSlider.value = playerNowHealth / playerTotalHealth;
        GameObject prototype = Resources.Load("DamageDigit") as GameObject;
        GameObject newDamageDigit = Instantiate(prototype);

        newDamageDigit.transform.position = transform.position + Vector3.up;
        DamageDigitController damageDigitController = newDamageDigit.GetComponent<DamageDigitController>();
        damageDigitController.Value = -lossHealth;
    }

    private void Die()
    {
        Debug.Log("you die");
    }

}
