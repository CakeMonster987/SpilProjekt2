using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseRemover : MonoBehaviour
{
    public PauseScreen pause;
    public void pauseRemover()
    {
        pause.pauseScreen.SetActive(false);
        pause.pauseScreenOn = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pause.player.enabled = true;
    }
}
