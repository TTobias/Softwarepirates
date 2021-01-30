using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab;
    public float minWaitTime, maxWaitTime;
    public float minVertical, maxVertical;
    public float minItemSpeed, maxItemSpeed;
    private GameObject holder;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, .1f);
    }

    void Start()
    {
        holder = new GameObject("ItemHolder");
        holder.transform.parent = transform;
        StartCoroutine(SpawnAndWait());
    }

    public IEnumerator SpawnAndWait()
    {
        yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
        float yValue = Random.Range(minVertical, maxVertical);
        Vector3 startingPos = transform.position + new Vector3(0, yValue, 0);
        GameObject newItem = Instantiate(itemPrefab, startingPos, Quaternion.identity);
        newItem.transform.localScale /= transform.position.z;
        Item controller = newItem.GetComponent<Item>();
        controller.SetSpeed(Random.Range(minItemSpeed, maxItemSpeed) / transform.position.z);
        controller.SetKillPos(-transform.position.x);
        newItem.transform.parent = holder.transform;
        StartCoroutine(SpawnAndWait());
    }
}