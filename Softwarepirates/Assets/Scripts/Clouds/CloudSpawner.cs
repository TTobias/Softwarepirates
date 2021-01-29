using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject cloudPrefab;
    public Texture[] cloudTextures;
    public float minWaitTime, maxWaitTime;
    public float minVertical, maxVertical;
    public float cloudSpeed;
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
        newCloud.transform.parent = holder.transform;
        yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
        StartCoroutine(SpawnAndWait());
    }
}