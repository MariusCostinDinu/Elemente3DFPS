using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int ammoAmount = 10;

    public int GetCurrentAmmo()
    {
        return ammoAmount;
    }

    public void ReduceCurentAmmo()
    {
        ammoAmount--;
    }

    public void IncreaseAmmo(int ammo)
    {
        ammoAmount += ammo;
    }
}
