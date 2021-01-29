using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject cloudPrefab;
    public Sprite[] cloudTextures;
    public float minWaitTime, maxWaitTime;
    public float minVertical, maxVertical;
    private GameObject holder;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, .1f);
    }

    void Start()
    {
        holder = new GameObject("CloudHolder");
        holder.transform.parent = transform;
        StartCoroutine(SpawnAndWait());
    }

    public IEnumerator SpawnAndWait()
    {
        float yValue = Random.Range(minVertical, maxVertical);
        Vector3 startingPos = transform.position + new Vector3(0, yValue, 0);
        GameObject newCloud = Instantiate(cloudPrefab, startingPos, Quaternion.identity);
        newCloud.transform.localScale /= transform.position.z;
        CloudController controller = newCloud.GetComponent<CloudController>();
        controller.speed = 2 / transform.position.z;
        controller.SetKillPos(-transform.position.x);
        newCloud.GetComponent<SpriteRenderer>().sprite = cloudTextures[Random.Range(0, cloudTextures.Length)];
        newCloud.transform.parent = holder.transform;
        yield return new WaitForSeconds(Random.Range(minWaitTime/transform.position.z, maxWaitTime/transform.position.z));
        StartCoroutine(SpawnAndWait());
    }
}