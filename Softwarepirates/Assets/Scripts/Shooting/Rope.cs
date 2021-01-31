using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public Transform puker;

    // Update is called once per frame
    void Update()
    {
        if(puker)
        {
            float angleRad = Mathf.Atan2(puker.position.y - transform.position.y, puker.position.x - transform.position.x);
            float angleDeg = (180 / Mathf.PI) * angleRad;
            transform.rotation = Quaternion.Euler(0, 0, angleDeg +180);
        }
    }
}
