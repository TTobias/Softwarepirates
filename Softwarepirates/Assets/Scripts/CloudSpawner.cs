using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public float cooldown = 1000f;
    public float tmp = 0f;
    public GameObject cloud;

    private void FixedUpdate() {
        if(tmp <= 0f) {
            tmp = cooldown;
            spawnCloud();
        }
        else {
            tmp -= 1f;
        }
    }

    public void spawnCloud() {
        GameObject g = Instantiate<GameObject>(cloud);
        float depth = Random.Range(0f, 100f);
        float height = Random.Range(0f, 100f);
        cloud.transform.position = new Vector3(50, height, -depth);
        cloud.GetComponent<DriveByMovement>().depth = depth;
        cloud.GetComponent<DriveByMovement>().speed = Random.Range(0.001f, 0.1f);
    }
}
