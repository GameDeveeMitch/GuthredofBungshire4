using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HDMIManager : MonoBehaviour
{
    public List<HDMIScript> hdmiAdapters = new List<HDMIScript>();
    public HDMIScript curHDMI;
    //going to have to assosciate a camera and possibly a rendertexture with each hdmiadapter. Might be best to use a dictionary here? 
    private void OnEnable()
    {
        hdmiAdapters = FindAllHDMIAdpaters();
    }
    private List<HDMIScript> FindAllHDMIAdpaters()
    {
        List<HDMIScript> tempList = new List<HDMIScript>();
        HDMIScript[] hdA = FindObjectsOfType<HDMIScript>();
     
        for(int i = 0; i < hdA.Length; i++)
        {
            tempList.Add(hdA[i]);
        }
        return tempList;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            NextAdapter();
    }
    public HDMIScript NextAdapter()
    {
        if(hdmiAdapters.Count <= 0)
            return null;
        else
        {
            if (hdmiAdapters.Count > 1)
            {
                Debug.Log("more than one");
                for (int i = 0; i < hdmiAdapters.Count; i++)
                {
                    if (curHDMI.gameObject.name.Equals(hdmiAdapters[i].gameObject.name))
                    {
                        if (i < hdmiAdapters.Count)
                            //check to make sure that it is not at the end
                            return curHDMI = hdmiAdapters[i++];
                        else
                            return curHDMI = hdmiAdapters[0];
                    }
                }
            } else
                return null;
        }

        return null;
    }
}
