using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float scaleMultiplier = 1f;
    public float speed = 1f;
    public Vector3 destination;
    public bool destroy = false;

    public GameObject referenceObject;

    public bool isCannon = true;

    public float distanceFactor = 1f;
    public float killDistance;
    private GrapplePullbackBehavior grapplePull;

    private void Awake()
    {
        transform.localScale *= scaleMultiplier;
    }
    public void Start()
    {
        grapplePull = FindObjectOfType<GrapplePullbackBehavior>();
    }

    public void Update() {
        distanceFactor = 1f / transform.position.z;

        if (referenceObject == null)
        {
            transform.Translate((destination - transform.position) * speed * Time.deltaTime);
            transform.localScale = Vector3.one * distanceFactor * scaleMultiplier;
        }
        else
        {
            transform.Translate((referenceObject.transform.position - transform.position) * speed * Time.deltaTime);
            transform.localScale = Vector3.one * distanceFactor * scaleMultiplier / 2f;
        }

        /*
        if (referenceObject == null)
        {
            this.transform.position += new Vector3(destination.x - transform.position.x, destination.y - transform.position.y, destination.z - transform.position.z).normalized * speed * distanceFactor;
        }
        else {
            this.transform.position += new Vector3(referenceObject.transform.position.x - transform.position.x, 
                referenceObject.transform.position.y - transform.position.y, referenceObject.transform.position.z - transform.position.z).normalized * speed * distanceFactor;
        }
        */
        //this.transform.localScale = new Vector3(distanceFactor, distanceFactor, distanceFactor);

        if (referenceObject == null)
        {
            if (Vector3.Distance(transform.position, destination) < killDistance)
            {
                TellItem();
                grapplePull.canPull = true;
                grapplePull.hit = false;
                this.enabled = false;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, referenceObject.transform.position) < killDistance)
            {
                TellItem();
                grapplePull.canPull = true;
                grapplePull.hit = true;
                this.enabled = false;
            }
        }
    }
    private void TellItem()
    {
        if (referenceObject != null)
        {
            if (isCannon)
            {
                referenceObject.GetComponent<Item>().HitByCannonball();
                Destroy(gameObject);
            }
            else
            {
                referenceObject.GetComponent<Item>().HitByPirate(gameObject);
            }
        }
        else
        {
            if (isCannon)
                Destroy(gameObject);
        }
    }
}
