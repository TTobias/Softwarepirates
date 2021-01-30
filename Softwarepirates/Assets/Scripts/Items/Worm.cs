using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : Item
{
    public float killPos;
    private bool didStuff;

    void Start()
    {
        base.Start();
        killAt = killPos;
    }

    public override void FixedUpdate()
    {
        transform.Translate(-speed * Time.deltaTime, 0f, 0f);
        if (transform.position.x < killAt)
        {
            Debug.Log("Hit dude!");
            HealthBarController health = FindObjectOfType<HealthBarController>();
            DoStuff();
            Cleanup();
        }
    }

    public override void DoStuff()
    {
        if(!didStuff)
        {
            HealthBarController health = FindObjectOfType<HealthBarController>();
            health.Damage(25);
        }
        didStuff = true;
    }
}
