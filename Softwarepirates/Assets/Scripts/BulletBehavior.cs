using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float speed = 1f;
    public Vector3 destination;
    public bool destroy = false;

    public float distanceFactor = 1f;

    public void FixedUpdate() {
        distanceFactor = 1f / transform.position.z;

        this.transform.position += new Vector3(destination.x - transform.position.x, destination.y - transform.position.y, destination.z - transform.position.z).normalized * speed * distanceFactor;
        this.transform.localScale = new Vector3(distanceFactor, distanceFactor, distanceFactor);

        if (destroy) {
            Destroy(this.gameObject);
        }

        if(Vector3.Distance(transform.position,destination) < speed * distanceFactor) {
            destroy = true;
        }
    }
}
