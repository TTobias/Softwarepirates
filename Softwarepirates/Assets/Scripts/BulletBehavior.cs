using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float traveltime = 10f;
    public float speed = 1f;
    public Vector3 destination;


    public void FixedUpdate() {
        this.transform.position += new Vector3(destination.x - transform.position.x, destination.y - transform.position.y, destination.z - transform.position.z).normalized * speed;
        traveltime -= 1f;
        this.transform.localScale = new Vector3(1f / transform.position.z, 1f / transform.position.z, 1f / transform.position.z);

        if(traveltime < 0f) {
            Destroy(this.gameObject);
        }
    }
}
