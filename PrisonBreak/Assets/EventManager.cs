using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    public delegate void DestroyBlock();
    public static event DestroyBlock DestroyingBlock;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public static void DestroyItNow()
    {
        DestroyingBlock();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
