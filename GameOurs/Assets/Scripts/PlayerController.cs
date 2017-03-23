using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Use this for initialization

    public Rigidbody rigidBody;
    public SpriteRenderer playerWalkingRenderer;

    public PlayerRender playerRender;
    public PlayerMove playerMove;
    public WeaponController weaponController;

    public UISlider bloodSlider;

    public float playerTotalHealth = 100f;
    private float playerNowHealth;

    void Start()
    {
        playerNowHealth = playerTotalHealth;
    }

    // Update is called once per frame
    void Update()
    {
        playerWalkingRenderer.sortingOrder = -(int)(transform.localPosition.z * 100);       // 设置显示先后顺序

        if (playerRender.status == AnimStatus.Attack)             //根据人物状态开关playerMove脚本
        {
            playerMove.enabled = false;
            rigidBody.velocity = Vector3.zero;

        }
        else
        {
            playerMove.enabled = true;
        }


        if ((playerMove.GetMoveFlag() == false) && (playerMove.GetJumpFlag() == false) && (weaponController.GetAttackflag() == false))
        {
            playerRender.status = AnimStatus.Idle;
        }
        else if ((playerMove.GetMoveFlag() == true) && (playerMove.GetJumpFlag() == false) && (weaponController.GetAttackflag() == false))
        {
            playerRender.status = AnimStatus.Walk;
        }
        else if ((playerMove.GetJumpFlag() == true) && (weaponController.GetAttackflag() == false))
        {
            playerRender.status = AnimStatus.Jump;
        }
        else if ((weaponController.GetAttackflag() == true) && (playerMove.GetJumpFlag() == true))
        {
            playerRender.status = AnimStatus.JumpAttack;
        }
        else if ((weaponController.GetAttackflag() == true) && (playerMove.GetJumpFlag() == false))
        {
            playerRender.status = AnimStatus.Attack;
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
