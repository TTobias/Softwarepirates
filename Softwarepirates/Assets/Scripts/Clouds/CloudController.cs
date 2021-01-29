using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    public float speed;
    private float killAt;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0f, 0f);
        if(transform.position.x > killAt)
        {
            Destroy(gameObject);
        }
    }

    public void SetKillPos(float pos)
    {
        killAt = pos;
    }
}
