using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveByMovement : MonoBehaviour
{
    public float depth = 0f;
    public float speed = 1f;

    public void Start() {
        this.transform.position.z = -depth;
    }

    public void FixedUpdate() {
        
    }
}
