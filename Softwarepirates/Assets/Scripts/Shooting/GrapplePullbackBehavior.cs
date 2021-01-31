using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrapplePullbackBehavior : MonoBehaviour
{
    public float pullAmount;
    public GameObject currentPirate;
    public bool activePirate = false;
    public bool canPull = false;
    private bool pulling;
    private float pullTime;
    public Vector3 landingPosition;
    public bool hit;

    private ShootingBehavior shooting;
    private Vector3 targetPos;
    private ArrEmitter arrEmitter;

    public void Start()
    {
        arrEmitter = FindObjectOfType<ArrEmitter>();
        shooting = FindObjectOfType<ShootingBehavior>();
        targetPos = shooting.grappleSpawnPos.transform.position;
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            arrEmitter.Puke();

            if (activePirate && canPull && Input.GetKeyDown(KeyCode.R))
            {
                pulling = true;
                pullTime = 0;
            }
        }

        if (pulling)
        {
            pullTime += Time.deltaTime;
            if(pullTime < pullAmount)
            {
                currentPirate.transform.Translate((targetPos - landingPosition) * Time.deltaTime);

                float distanceFactor = 1f / currentPirate.transform.position.z;
                if (hit)
                    currentPirate.transform.localScale = Vector3.one * distanceFactor / 2f;
                else
                    currentPirate.transform.localScale = Vector3.one * distanceFactor;

                float distance = Vector3.Distance(currentPirate.transform.position, targetPos);

                if (distance < 1.5f)
                {
                    pulling = false;
                    Item child = currentPirate.GetComponentInChildren<Item>();
                    if(child != null)
                    {
                        child.Cleanup();
                    }
                    shooting.ShowPirate();
                    Destroy(currentPirate);
                    currentPirate = null;
                    activePirate = false;
                    canPull = false;
                }
            }
        }
    }
}
