﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : Item
{
    public override void HitByCannonball()
    {
        Cleanup();
    }

    public override void HitByPirate()
    {

    }
}
