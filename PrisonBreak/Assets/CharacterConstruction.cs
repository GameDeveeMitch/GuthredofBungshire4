using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterConstruction : MonoBehaviour
{
    public float constructionRaycast = 2f;
    public LayerMask constructionLayer;
    public GameObject constructionRaycastPosition;

    private GameObject tempBlock;
    private GameObject oldBlock;
    // Start is called before the first frame update
    void Start()
    {
        tempBlock = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(constructionRaycastPosition.transform.position, constructionRaycastPosition.transform.TransformDirection(Vector3.forward), out hit, constructionRaycast,constructionLayer))
        {
            hit.transform.GetComponent<BreakableBlockScript>().LightItUp();
            if (CheckTempBlock(hit.transform.gameObject))
            {
                tempBlock.transform.GetComponent<BreakableBlockScript>().LightItUp();
                TurnOldBlockOff();
            }
            Debug.DrawRay(constructionRaycastPosition.transform.position, constructionRaycastPosition.transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            if (Input.GetKeyDown(KeyCode.R) && hit.transform.GetComponent<BreakableBlockScript>())
            {
                Debug.Log("so far so good");
                hit.transform.GetComponent<BreakableBlockScript>().DestroyBlock();
            }
        }
    }
    private bool CheckTempBlock(GameObject newBlock)
    {
        if(tempBlock != newBlock || tempBlock.Equals(null))
        {
            oldBlock = tempBlock;
            tempBlock = newBlock;
            return true;
        }
        return false;
    }
    private void TurnOldBlockOff()
    {
        if(!oldBlock.Equals(null) && oldBlock.GetComponent<Outline>())
            oldBlock.GetComponent<Outline>().enabled = false;
    }
}
