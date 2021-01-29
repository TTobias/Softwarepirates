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

    public Vector3 aimPosition;

    public Camera cam;

    public Transform shootSpawnPos;
    public Transform grappleSpawnPos;

    public GameObject bulletObject;

    public ActiveObjects objectlist;

    public void Start() {
        objectlist = GetComponent<ActiveObjects>();
        cam = GetComponent<Camera>();
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
            spawnBullet(shootSpawnPos.position ,new Vector3(cam.ScreenToWorldPoint(aimPosition).x, cam.ScreenToWorldPoint(aimPosition).y, 30));
        }
        else {
            //FIRE TARGET
        }
    }

    public void launchGrapple() {
        GameObject hit = testForHit();

        if (hit == null) {
            //FIRE EMPTY
            spawnGrapple();
        }
        else {
            //FIRE TARGET
        }
    }


    public void spawnBullet(Vector3 start, Vector3 end) {
        GameObject tmp = Instantiate<GameObject>(bulletObject);
        tmp.transform.position = start;

        tmp.GetComponent<BulletBehavior>().destination = end;
    }


    public void spawnGrapple() {

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
