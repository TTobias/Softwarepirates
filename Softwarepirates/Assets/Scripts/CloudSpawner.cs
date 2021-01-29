using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public float cooldown = 1000f;
    public float tmp = 0f;

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

    }
}
