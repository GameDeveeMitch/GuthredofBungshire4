using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    /*
     * each ability will have its own script
     * ex) simple unlock
     * they will all inherit from this manager
     */
    public string abilityName;
    public byte abilityID;
    public KeyCode useButton;
    public LayerMask useLayer;
    
    public float RaycastDistance//may want to make this a public variable
    {
        get { return raycastDistance; }
        set { raycastDistance = value; }
    }
    
    private float raycastDistance;
    public virtual bool CanUseAbility()
    {
        //can you use the current ability
        return false;
    }
    public virtual void UseAbility()
    {
        //ability functionality
    }
    public virtual void Update()
    {

    }
}
