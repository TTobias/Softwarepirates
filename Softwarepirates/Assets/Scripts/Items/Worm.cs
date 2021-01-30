﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : Item
{
    public float killPos;
    private bool hit;

    public new void Start()
    {
        base.Start();
        killAt = killPos;
    }

    public override void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0f, 0f);
        if (transform.position.x < killAt)
        {
            //Debug.Log("Hit dude!");
            HitPlayer();
            Cleanup();
        }
    }

    public void HitPlayer()
    {
        if(!hit)
        {
            HealthBarController health = FindObjectOfType<HealthBarController>();
            health.Damage(25);
        }
        hit = true;
    }

    public override void HitByCannonball()
    {
        Cleanup();
    }

    public override void HitByPirate(GameObject other)
    {
        GrapplePullbackBehavior shooting = FindObjectOfType<GrapplePullbackBehavior>();
        shooting.activePirate = false;
        shooting.canPull = false;
        Destroy(other);
        PirateCounterController controller = FindObjectOfType<PirateCounterController>();
        controller.RemovePirate();
    }
}
