using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBehavior : MonoBehaviour
{
    public int shootCooldown = 10;
    public int tmpShootCooldown = 0;
    public int grappleCooldown = 20;
    public int tmpGrappleCooldown = 0;

    public float hitTolerance = 2f;

    public Vector2 aimPosition;

    public Vector3 shootSpawnPos;
    public Vector3 grappleSpawnPos;

    public ActiveObjects objectlist;

    public void Start() {
        objectlist = GetComponent<ActiveObjects>();
    }

    public void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if(tmpShootCooldown <= 0)
                shootBullet();
        }
        if (Input.GetMouseButtonDown(0)) {
            if (tmpGrappleCooldown <= 0)
                launchGrapple();
        }
    }

    public void FixedUpdate() {
        if (tmpShootCooldown > 0f) {
            tmpShootCooldown--;
        }
        if (tmpGrappleCooldown > 0f) {
            tmpGrappleCooldown--;
        }

        aimPosition = Input.mousePosition;

    }



    public void shootBullet() {
        GameObject hit = testForHit();

        if(hit == null) {
            //FIRE EMPTY
        }
        else {
            //FIRE TARGET
        }
    }

    public void launchGrapple() {
        GameObject hit = testForHit();

        if (hit == null) {
            //FIRE EMPTY
        }
        else {
            //FIRE TARGET
        }
    }




    public GameObject testForHit() {
        for(int i = 0; i<objectlist.items.Count; i++) {
            if(false /* Item will be hit (forecast simulation)*/) {
                return objectlist.items[i];
            }
        }

        return null;
    }
}
