using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bitcoin : Item
{
    public override void HitByPirate(GameObject other)
    {
        //transform.parent = other.transform;
        FuelBarController fuel = FindObjectOfType<FuelBarController>();
        fuel.AddFuel();
        Cleanup();
    }
}
