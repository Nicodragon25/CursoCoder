using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastEnemy : MonoBehaviour
{
    public GameObject head;
    GameObject player;

    public float rayDistance;
    Vector3 lookPos;
    Quaternion originalRotation;

    Ray ray;
    public float timePass;
    public float rotateBackCoolDown;
    public bool noHit;
    void Awake()
    {
        player = GameObject.Find("Player").gameObject;
        originalRotation = transform.rotation;
        noHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        lookPos = player.transform.position - transform.position;
        lookPos.y = 0;
        if(timePass > rotateBackCoolDown)
        {
            head.transform.rotation = Quaternion.Slerp(head.transform.rotation, originalRotation, 5 * Time.deltaTime);
        }
        if (noHit == true)
        {
            timePass += Time.deltaTime;
        }

        RaycastHit hit;
        if (Physics.Raycast(head.transform.position, head.transform.TransformDirection(Vector3.forward), out hit, rayDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Quaternion rotation = Quaternion.LookRotation(lookPos);
                head.transform.rotation = Quaternion.Slerp(head.transform.rotation, rotation, 25 * Time.deltaTime);
                timePass = 0f;
                noHit = false;
            }
        }
        if (!Physics.Raycast(head.transform.position, head.transform.TransformDirection(Vector3.forward), out hit, rayDistance))
        {
            noHit = true;
        }
    }
    private void OnDrawGizmos()
    {
        if (noHit)
        {
            Gizmos.color = Color.white;
            Vector3 direction = head.transform.TransformDirection(Vector3.forward) * rayDistance;
            Gizmos.DrawRay(head.transform.position, direction);
        }
        if (!noHit)
        {
            Gizmos.color = Color.red;
            Vector3 direction = head.transform.TransformDirection(Vector3.forward) * rayDistance;
            Gizmos.DrawRay(head.transform.position, direction);
        }

    }
}
