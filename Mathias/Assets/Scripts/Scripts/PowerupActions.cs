using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupActions : MonoBehaviour
{
    [SerializeField]
    private Player1Mov playerController;

    public void HighSpeedStartAction()
    {
        playerController.Speed *= 2;
    }

    public void HighSpeedEndAction()
    {
        playerController.Speed = playerController.DefaultSpeed;
    }
}
