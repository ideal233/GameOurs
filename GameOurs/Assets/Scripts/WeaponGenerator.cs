using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponName
{
    knife,
    sword,
    gun,
    A,
    B,
    C,
    D,
    andsoon
}
public class Weapon
{
    public WeaponName weaponName;
    public int attackPower;
    public int attackDistance;
    public int attackRadius;
    public bool isFar;
    public float startTime;
    public float attackInterval;

    public Weapon(WeaponName wn,int ap, int ad, int ar, bool isFar)
    {
        weaponName = wn;
        attackPower = ap;
        attackDistance = ad;
        attackRadius = ar;
        this.isFar = isFar;
    }
    public Weapon(float startTime, float attackInterval)
    {
        this.startTime = startTime;
        this.attackInterval = attackInterval;
    }


    public static Weapon RandomGenerator(string weaponName)
    {
        //还未完成。。。
        WeaponName wn = (WeaponName)System.Enum.Parse(typeof(WeaponName), weaponName.Substring(7));
        return new Weapon(wn, 1, 1, 1, false);
    }
}

public class WeaponGenerator : MonoBehaviour {
    public static int numOfWeapons = 3;
    public GameObject Prefab;
    public Vector3[] buttonPositions;
    private WeaponName[] weapons = new WeaponName[numOfWeapons];
    private GameObject[] buttons = new GameObject[numOfWeapons];
    private GameObject button;
	// Use this for initialization
	void Start () {
        WeaponName w = new WeaponName();
        string[] values = System.Enum.GetNames(w.GetType()); //获取Enum中的所有值
        System.Random r = new System.Random();
		for(int i = 0;i < numOfWeapons;i++)
        {
            weapons[i] =(WeaponName)(r.Next(0, values.Length-1));
            buttons[i] = Instantiate(Prefab);
            buttons[i].transform.parent = GetComponent<Transform>();
            buttons[i].transform.localPosition = buttonPositions[i];
            buttons[i].GetComponent<UISprite>().spriteName = "choose-" + System.Enum.GetName(typeof(WeaponName),weapons[i]);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
