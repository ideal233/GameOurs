using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuController : MonoBehaviour
{

    public GameObject menuPanel;

    public void OnMenuPlay()
    {
        SceneManager.LoadScene("Scenes/001.5-chooseWeapon");
    }
}
