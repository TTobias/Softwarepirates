using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected float speed;
    protected float killAt;
    private ActiveObjects active;

    public void Start()
    {
        active = FindObjectOfType<ActiveObjects>();
        active.items.Add(gameObject);
    }

    public virtual void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0f, 0f);
        if (transform.position.x < killAt)
        {
            Cleanup();
        }
    }

    protected void Cleanup()
    {
        active.items.Remove(gameObject);
        Destroy(gameObject);
    }

    public void SetKillPos(float pos)
    {
        killAt = pos;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public float GetSpeed(float speed)
    {
        return this.speed;
    }

    public abstract void DoStuff();
}