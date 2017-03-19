using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonNotifier : MonoBehaviour {
    
    public void onClick()
    {
        string name = GetComponent<UISprite>().spriteName;
        DataSave.weapon = Weapon.RandomGenerator(name);
        SceneManager.LoadScene("Scenes/002-ch01");
    }

}
