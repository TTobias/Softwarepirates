using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudEmitter : MonoBehaviour
{
    public GameObject cloudPrefab;
    public Sprite[] cloudTextures;
    public float minForce, maxForce;
    public float minTorque, maxTorque;
    public float minLifetime, maxLifetime;
    public int cloudAmount;
    private GameObject holder;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, .1f);
    }

    public void Start()
    {
        holder = new GameObject("CloudHolder");
        holder.transform.parent = transform;
    }

    public void Puke(bool kill)
    {
        for(int i = 0; i < cloudAmount; i++)
        {
            StartCoroutine(SpawnOne());
        }
        if (kill)
        {
            StartCoroutine(WaitAndKill());
            GetComponent<AudioSource>().Play();
        }
    }

    public IEnumerator SpawnOne()
    {
        GameObject newCloud = Instantiate(cloudPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = newCloud.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(Random.Range(minForce, maxForce), Random.Range(minForce, maxForce)));
        rb.AddTorque(Random.Range(minTorque, maxTorque));
        newCloud.GetComponent<SpriteRenderer>().sprite = cloudTextures[Random.Range(0, cloudTextures.Length)];
        //newCloud.transform.parent = holder.transform;
        yield return new WaitForSeconds(Random.Range(minLifetime, maxLifetime));
        Destroy(newCloud);
    }

    public IEnumerator WaitAndKill()
    {
        yield return new WaitForSeconds(maxLifetime*2f);
        Destroy(gameObject);
    }
}