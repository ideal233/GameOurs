using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    public GameObject[] flyItem;
    public GameObject player;
    private GameObject currentFlyItem;
    private bool isAttacking;

    public void SetAttackFlag(bool f)
    {
        this.isAttacking = f;
    }
    public bool GetAttackflag()
    {
        return isAttacking;
    }

    void Start()
    {
        currentFlyItem = flyItem[0];
    }

    // Update is called once per frame
    void Update()
    {
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


        if (Input.GetKeyDown(KeyCode.J))
        {
            isAttacking = true; //记得在player render里加上将其变为false的代码
            Instantiate(currentFlyItem);

        }
    }
}
