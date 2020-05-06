using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorScript : MonoBehaviour
{
    public HDMIScript hdmiAdapter;
    public Transform hdmiPlacement;
    //might want to put a reference to the correct hdmi script into this?
    private void Update()
    {
        //adding an adapter
        if (Input.GetKeyDown(KeyCode.P) && hdmiAdapter.Equals(null))
        {
            HDMIToMonitor();
        }
        if (!hdmiAdapter.Equals(null))
        {
            //Debug.Log("it has an hdmi adapter");
            //going to have to set the rendertexture to true
        }
    }
    public void HDMIToMonitor()
    {
        //going to add the adapter to the tv for the first time
        //going to use the placement to put the adapter in the correct position and then will have to add the initial hdmi "reciever" to the manager
    }
}
