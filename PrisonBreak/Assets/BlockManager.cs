using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Outline))]

public class BlockManager : MonoBehaviour
{
    public virtual void DestroyBlock()
    {
        Debug.Log("youre doing it");
        this.gameObject.SetActive(false);
    }
    public virtual void HighLightBlockTurnOff()
    {
        if (this.GetComponent<Outline>())
            this.GetComponent<Outline>().enabled = false;
    }
    public virtual void LightItUp()
    {
        if (this.GetComponent<Outline>())
            this.GetComponent<Outline>().enabled = true;
    }
}
