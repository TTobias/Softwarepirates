using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : Item
{
    public float killPos;

    void Start()
    {
        base.Start();
        killAt = killPos;
    }

    public override void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0f, 0f);
        if (transform.position.x < killAt)
        {
            Debug.Log("Hit dude!");
            Cleanup();
        }
    }

    public override void DoStuff()
    {
        
    }
}
