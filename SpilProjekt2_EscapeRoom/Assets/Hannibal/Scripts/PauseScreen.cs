using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using StarterAssets;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    public GameObject pauseScreen;
    public bool pauseScreenOn;
    public FirstPersonController player;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pauseScreenOn == false)
        {
            pauseScreen.SetActive(true);
            pauseScreenOn = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            player.enabled = false;

        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseScreenOn == true)
        {
            pauseScreen.SetActive(false);
            pauseScreenOn = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            player.enabled = true;

        }
    }
}
