using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplePullbackBehavior : MonoBehaviour
{
    public float pullAmount;
    public GameObject currentPirate;
    public bool activePirate = false;
    public bool canPull = false;

    private ShootingBehavior shooting;
    private Vector3 targetPos;

    public void Start()
    {
        shooting = FindObjectOfType<ShootingBehavior>();
        targetPos = shooting.grappleSpawnPos.transform.position;
    }

    public void Update()
    {
        if (activePirate && canPull && Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Pulling!");
        }
    }
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        canPull = true;
    }
}
