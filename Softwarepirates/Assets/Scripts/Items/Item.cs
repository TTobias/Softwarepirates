using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected float speed;
    protected float killAt;
    private ActiveObjects active;
    public GameObject emitter;
    private bool wasHit;

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

    public void Cleanup()
    {
        Debug.Log("Cleaning up");
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

    public float GetSpeed()
    {
        return this.speed;
    }

    public void HitByCannonball()
    {
        if(!wasHit)
        {
            wasHit = true;
            GameObject em = Instantiate(emitter, transform.position, Quaternion.identity);
            em.GetComponent<CloudEmitter>().Puke(true);
            //em.GetComponent<AudioSource>().Play();
            Cleanup();
        }
    }

    public abstract void HitByPirate(GameObject other);
}