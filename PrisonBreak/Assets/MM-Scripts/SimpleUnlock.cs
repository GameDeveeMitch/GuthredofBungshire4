using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleUnlock : AbilityManager
{
    
    public float rayDistance;
    private bool useAbility = false;
    private void Start()
    {
        RaycastDistance = rayDistance;
    }
    public override void UseAbility()
    {
        useAbility = true;
        base.UseAbility();
    }
    public override void Update()
    {
        if (Input.GetKeyDown(useButton))
        {
            Debug.Log("use button");
            RaycastHit hit;
            if (Physics.Raycast(new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z), transform.forward, out hit, RaycastDistance, useLayer))
            {
                Debug.DrawRay(new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z), transform.forward);
                Debug.Log("hit door");
                hit.collider.gameObject.SetActive(false);
                
            }
        }
    }
}
