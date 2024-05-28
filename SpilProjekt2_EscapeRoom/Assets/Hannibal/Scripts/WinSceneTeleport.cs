using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSceneTeleport : MonoBehaviour
{
    Raycast ray;
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        ray.PlayerMov.enabled = false;

    }
}
