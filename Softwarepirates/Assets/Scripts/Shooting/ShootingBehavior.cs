using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingBehavior : MonoBehaviour
{
    public int shootCooldown = 50;
    public int tmpShootCooldown = 0;
    public int grappleCooldown = 100;
    public int tmpGrappleCooldown = 0;

    public float hitTolerance = 0.5f;

    public Vector3 aimPosition;

    public Camera cam;

    public Transform shootSpawnPos;
    public Transform grappleSpawnPos;

    public GameObject bulletObject;
    public GameObject grappleObject;

    public ActiveObjects objectlist;

    public Image leftMouseImg;
    public Image rightMouseImg;
    public Image reloadImg;

    private GrapplePullbackBehavior grapplePull;
    public GameObject cannonHinge, ballistaHinge;
    private float lastRot;
    private CloudEmitter cloudEmitter;
    public GameObject pirate;

    public void Start()
    {
        cloudEmitter = FindObjectOfType<CloudEmitter>();
        grapplePull = FindObjectOfType<GrapplePullbackBehavior>();
        objectlist = GetComponent<ActiveObjects>();
        cam = GetComponent<Camera>();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            if(tmpShootCooldown <= 0)
                shootBullet();
        }
        if (Input.GetMouseButtonDown(1)) {
            if (tmpGrappleCooldown <= 0 && ! grapplePull.activePirate)
                launchGrapple();
        }
    }

    public void FixedUpdate()
    {
        if (tmpShootCooldown > 0f) {
            tmpShootCooldown--;
            leftMouseImg.fillAmount = 1 -(float)tmpShootCooldown / (float)shootCooldown;
        }
        
        if (tmpGrappleCooldown > 0f) {
            tmpGrappleCooldown--;
            //rightMouseImg.fillAmount = (float)tmpGrappleCooldown / (float)grappleCooldown;
        }
        

        aimPosition = Input.mousePosition;
        Vector3 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lookAt = mouseScreenPosition;
        float angleRad = Mathf.Atan2(lookAt.y - cannonHinge.transform.position.y, lookAt.x - cannonHinge.transform.position.x);
        float angleDeg = (180 / Mathf.PI) * angleRad;
        cannonHinge.transform.rotation = Quaternion.Euler(0, 0, angleDeg);

        angleRad = Mathf.Atan2(lookAt.y - ballistaHinge.transform.position.y, lookAt.x - ballistaHinge.transform.position.x);
        angleDeg = (180 / Mathf.PI) * angleRad;
        ballistaHinge.transform.rotation = Quaternion.Euler(0, 0, angleDeg - 90f);
    }

    public void ShowPirate()
    {
        pirate.GetComponent<SpriteRenderer>().enabled = true;
        reloadImg.GetComponent<Image>().enabled = false;
    }

    public void HidePirate()
    {
        pirate.GetComponent<SpriteRenderer>().enabled = false;
        reloadImg.GetComponent<Image>().enabled = true;
    }

    public void shootBullet()
    {
        cloudEmitter.Puke(false);
        shootSpawnPos.gameObject.GetComponent<AudioSource>().Play();
        GameObject hit = testForHit();

        if(hit == null) {
            //FIRE EMPTY
            spawnBullet(shootSpawnPos.position ,new Vector3(cam.ScreenToWorldPoint(aimPosition).x, cam.ScreenToWorldPoint(aimPosition).y, 6), hit);
        }
        else {
            //FIRE TARGET
            //Debug.Log("HIT");
            spawnBullet(shootSpawnPos.position, new Vector3(cam.ScreenToWorldPoint(aimPosition).x, cam.ScreenToWorldPoint(aimPosition).y, hit.transform.position.z), hit);
        }

        tmpShootCooldown = shootCooldown;
        leftMouseImg.fillAmount = 1;
    }

    public void launchGrapple()
    {
        HidePirate();
        grapplePull.activePirate = true;
        grappleSpawnPos.gameObject.GetComponent<AudioSource>().Play();

        GameObject hit = testForHit();

        if (hit == null) {
            //FIRE EMPTY
            spawnGrapple(grappleSpawnPos.position, new Vector3(cam.ScreenToWorldPoint(aimPosition).x, cam.ScreenToWorldPoint(aimPosition).y, 6), hit);
        }
        else {
            //FIRE TARGET
            Debug.Log("HIT");
            spawnGrapple(grappleSpawnPos.position, new Vector3(cam.ScreenToWorldPoint(aimPosition).x, cam.ScreenToWorldPoint(aimPosition).y, hit.transform.position.z), hit);
        }

        tmpGrappleCooldown = grappleCooldown;
        rightMouseImg.fillAmount = 1;
    }


    public void spawnBullet(Vector3 start, Vector3 end, GameObject reference) {
        GameObject tmp = Instantiate(bulletObject, start, Quaternion.identity);
        //tmp.transform.position = start;

        tmp.GetComponent<BulletBehavior>().destination = end;
        tmp.GetComponent<BulletBehavior>().referenceObject = reference;
        tmp.GetComponent<BulletBehavior>().isCannon = true;
    }


    public void spawnGrapple(Vector3 start, Vector3 end, GameObject reference) {
        GameObject tmp = Instantiate(grappleObject, start, Quaternion.identity);
        //tmp.transform.position = start;

        tmp.GetComponent<BulletBehavior>().destination = end;
        tmp.GetComponent<BulletBehavior>().referenceObject = reference;
        tmp.GetComponent<BulletBehavior>().isCannon = false;

        grapplePull.currentPirate = tmp;
        grapplePull.landingPosition = end;
    }


    public GameObject testForHit() {
        float mouseX = cam.ScreenToWorldPoint(aimPosition).x;
        float mouseY = cam.ScreenToWorldPoint(aimPosition).y;

        for (int i = 0; i<objectlist.items.Count; i++) {
            if( Mathf.Abs(objectlist.items[i].transform.position.y - mouseY) < hitTolerance) {
                if((Mathf.Abs(mouseX - (objectlist.items[i].transform.position.x -  
                    (objectlist.items[i].transform.position.z * 8f /*random value, don't question it*/ * objectlist.items[i].GetComponent<Item>().GetSpeed() * Time.deltaTime))) < hitTolerance)) {

                    return objectlist.items[i];
                }
            }
        }

        return null;
    }
}
