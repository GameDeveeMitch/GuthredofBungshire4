using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterConstruction : MonoBehaviour
{
    public float constructionRaycast = 2f;
    public LayerMask constructionLayer;
    public GameObject constructionRaycastPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(constructionRaycastPosition.transform.position, transform.TransformDirection(Vector3.forward), out hit, constructionRaycast,constructionLayer))
        {
            Debug.DrawRay(constructionRaycastPosition.transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            Debug.Log("hit");
        }
    }
}
