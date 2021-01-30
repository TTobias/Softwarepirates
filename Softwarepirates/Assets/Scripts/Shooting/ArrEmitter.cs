using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrEmitter : MonoBehaviour
{
    public GameObject arrPrefab;
    public Sprite[] arrTextures;
    public float minForce, maxForce;
    public float minTorque, maxTorque;
    public float minLifetime, maxLifetime;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, .1f);
    }

    public void Puke()
    {
        StartCoroutine(SpawnOne());
    }

    public IEnumerator SpawnOne()
    {
        GameObject newArr = Instantiate(arrPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = newArr.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(Random.Range(minForce, maxForce), Random.Range(minForce, maxForce)));
        rb.AddTorque(Random.Range(minTorque, maxTorque));
        newArr.GetComponent<SpriteRenderer>().sprite = arrTextures[Random.Range(0, arrTextures.Length)];
        yield return new WaitForSeconds(Random.Range(minLifetime, maxLifetime));
        Destroy(newArr);
    }
}