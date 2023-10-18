using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] StarterAssetsInputs starterAssetsInputs;
    [SerializeField] WeaponSwitcher  weaponSwitcher;

    private void Start() 
    {
        gameOverCanvas.enabled = false;
        weaponSwitcher = GetComponentInChildren<WeaponSwitcher>();    
    }

    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;
        weaponSwitcher.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        starterAssetsInputs.cursorInputForLook = false;

    }
}
