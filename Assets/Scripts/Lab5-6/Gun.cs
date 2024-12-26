using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform hitSphere;

    Ray ray;
    RaycastHit hitInfo;
    public LayerMask layerMask;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //set up the ray to start shooting from the camera
        ray.origin = Camera.main.transform.position;
        ray.direction = Camera.main.transform.forward;
        float distance = 100f;

        //if ray hits something, put the hitSphere at the location ray hit
        if (Physics.Raycast(ray, out hitInfo, distance, layerMask))
        {
            Debug.Log("Ray Hit: " + hitInfo.transform.name);
            //We hit something!
            hitSphere.gameObject.SetActive(true);
            hitSphere.position = hitInfo.point;

            if (hitInfo.transform.CompareTag("PhysicsActor"))
            {
                hitInfo.rigidbody.AddForceAtPosition(ray.direction * 10, hitInfo.point, ForceMode.Impulse);
            }
            else if (!hitInfo.transform.CompareTag("Environment"))
            {
                Destroy(hitInfo.transform.gameObject);
            }

            
        }
        else
        {
            //hitSphere.gameObject.SetActive(false);
            hitSphere.position = ray.origin + ray.direction * distance;
        }

        Debug.DrawLine(ray.origin, hitSphere.position, Color.red, 3f);
    }
}
