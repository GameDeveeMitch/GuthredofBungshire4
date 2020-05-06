using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDetectGameObject : MonoBehaviour
{
    // Detects manually if obj is being seen by the main camera

    public GameObject obj;
    Collider objCollider;

    Camera cam;
    Plane[] planes;

    void Start()
    {
        cam = this.GetComponent<Camera>();
        planes = GeometryUtility.CalculateFrustumPlanes(cam);
        objCollider = obj.GetComponent<Collider>();
    }

    void Update()
    {
        if (GeometryUtility.TestPlanesAABB(planes, objCollider.bounds))
        {
            Debug.Log(obj.name + " has been detected!");
        }
        else
        {
            Debug.Log("Nothing has been detected");
        }
    }
}
