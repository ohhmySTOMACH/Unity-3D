using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    void Start()
    {
        gameOverCanvas.enabled = false; 
    }

    // Update is called once per frame
    public void HandleDeath() 
    {
        gameOverCanvas.enabled = true; 
        Time.timeScale = 0; // Stoptime--Pause the game
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
