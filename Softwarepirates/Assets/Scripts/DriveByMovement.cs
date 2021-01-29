﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveByMovement : MonoBehaviour
{
    public float depth = 0f;
    public float speed = 1f;

    public void Start() {
        this.transform.position.Set(this.transform.position.x,this.transform.position.y, -depth);
    }

    public void FixedUpdate() {
        this.transform.position.Set(transform.position.x -speed, transform.position.y, transform.position.z);
    }
}