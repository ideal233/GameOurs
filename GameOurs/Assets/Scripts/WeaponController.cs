using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    //public GameObject[] flyItem;
    public int haha;
    public GameObject swordWield;
    public float swordWieldDamage;

    public GameObject swordWind;
    public float swordWindDamage;
    public GameObject player;

    private GameObject currentFlyItem;
    private bool isAttacking;
    public float attackTimeCounter;
    public float comboTime = 1;        //连击数

    private float timeAfterAttack;
    public int wieldTime;

    public void SetAttackFlag(bool f)
    {
        isAttacking = f;
    }
    public bool GetAttackflag()
    {
        return isAttacking;
    }

    void Start()
    {
        wieldTime = 0;
        //currentFlyItem = flyItem[0];
    }

    // Update is called once per frame
    void Update()
    {
        attackTimeCounter -= Time.deltaTime;
        timeAfterAttack += Time.deltaTime;
        {
            if (timeAfterAttack >= comboTime)
                wieldTime = 0;
        }

        /*
        if (attackTimeCounter <= 0)
            isAttacking = false;
        else
            isAttacking = true;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (flyItem[0] != null)
                currentFlyItem = flyItem[0];
            else
                Debug.Log("No Weapen");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (flyItem[1] != null)
                currentFlyItem = flyItem[1];
            else
                Debug.Log("No Weapen");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (flyItem[2] != null)
                currentFlyItem = flyItem[2];
            else
                Debug.Log("No Weapen");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (flyItem[3] != null)
                currentFlyItem = flyItem[3];
            else
                Debug.Log("No Weapen");
        }
        */


        if (Input.GetKeyDown(KeyCode.J))
        {
            if (!isAttacking)
            {

                isAttacking = true;         //记得在player render里加上将其变为false的代码
                //Invoke("CreateFlyItem", DataSave.swordWind.startTime);
                wieldTime++;

                timeAfterAttack = 0;

                if (wieldTime % 3 != 0)
                {
                    Invoke("CreateSwordWield", DataSave.swordWield.startTime);
                    attackTimeCounter = DataSave.swordWield.attackInterval;
                }
                else
                {
                    Invoke("CreateSwordWind", DataSave.swordWind.startTime);
                    attackTimeCounter = DataSave.swordWind.attackInterval;
                }

            }
            else
            {

            }
        }
    }

    void CreateFlyItem()
    {
        Instantiate(currentFlyItem);
    }

    void CreateSwordWield()
    {
        Instantiate(swordWield);
    }

    void CreateSwordWind()
    {
        Instantiate(swordWind);
    }
}
