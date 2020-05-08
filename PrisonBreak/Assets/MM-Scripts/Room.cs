using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public string roomName;
    public RoomTracker roomTracker;
    // Start is called before the first frame update
    void Start()
    {
        roomTracker = GameObject.FindObjectOfType<RoomTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        roomTracker.currentRoom = this.gameObject.GetComponent<Room>();//might change this to just looking at strings
    }
}
