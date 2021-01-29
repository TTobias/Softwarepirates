using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBehavior : MonoBehaviour
{
    public int shootCooldown = 10;
    public int tmpShootCooldown = 0;
    public int grappleCooldown = 20;
    public int tmpGrappleCooldown = 0;

    public float hitTolerance = 0.5f;

    public Vector3 aimPosition;

    public Camera cam;

    public Transform shootSpawnPos;
    public Transform grappleSpawnPos;

    public GameObject bulletObject;
    public GameObject grappleObject;

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
        if (Input.GetMouseButtonDown(1)) {
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
            spawnBullet(shootSpawnPos.position ,new Vector3(cam.ScreenToWorldPoint(aimPosition).x, cam.ScreenToWorldPoint(aimPosition).y, 6));
        }
        else {
            //FIRE TARGET
            Debug.Log("HIT");
        }

        tmpShootCooldown = shootCooldown;
    }

    public void launchGrapple() {
        GameObject hit = testForHit();

        if (hit == null) {
            //FIRE EMPTY
            spawnGrapple(grappleSpawnPos.position, new Vector3(cam.ScreenToWorldPoint(aimPosition).x, cam.ScreenToWorldPoint(aimPosition).y, 6));
        }
        else {
            //FIRE TARGET
            Debug.Log("HIT");
        }

        tmpGrappleCooldown = grappleCooldown;
    }


    public void spawnBullet(Vector3 start, Vector3 end) {
        GameObject tmp = Instantiate<GameObject>(bulletObject);
        tmp.transform.position = start;

        tmp.GetComponent<BulletBehavior>().destination = end;
    }


    public void spawnGrapple(Vector3 start, Vector3 end) {
        GameObject tmp = Instantiate<GameObject>(grappleObject);
        tmp.transform.position = start;

        tmp.GetComponent<BulletBehavior>().destination = end;
    }


    public GameObject testForHit() {
        float mouseX = cam.ScreenToWorldPoint(aimPosition).x;
        float mouseY = cam.ScreenToWorldPoint(aimPosition).y;

        for (int i = 0; i<objectlist.items.Count; i++) {
            if( Mathf.Abs(objectlist.items[i].transform.position.y - mouseY) < hitTolerance) {
                if((Mathf.Abs(objectlist.items[i].transform.position.x - objectlist.items[i].GetComponent<Item>().speed*3) - mouseX) < hitTolerance) {

                    return objectlist.items[i];
                }
            }
        }

        return null;
    }
}
