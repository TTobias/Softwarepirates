using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bitcoin : Item
{
    public override void HitByCannonball()
    {
        Cleanup();
    }

    public override void HitByPirate(GameObject other)
    {
        FuelBarController fuel = FindObjectOfType<FuelBarController>();
        fuel.AddFuel();
        Cleanup();
    }
}
