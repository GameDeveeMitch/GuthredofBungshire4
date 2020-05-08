using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTracker : MonoBehaviour
{

    public Room[] roomArray = new Room[0];
    public Room currentRoom;
    public Room desiredRoom;
    public Officer[] officers = new Officer[0];
    public float roomTimer = 10;
    // Start is called before the first frame update
    void Start()
    {
        roomArray = FindObjectsOfType<Room>();
        officers = FindObjectsOfType<Officer>();
    }

    // Update is called once per frame
    void Update()
    {
        TestGetBackToCell();
        if(roomTimer > 0)
        {
            roomTimer -= Time.deltaTime;
        }
        else
        {
            if (!currentRoom.Equals(desiredRoom))
                SendTheTroops();
            else
                CallTheGaurdsOff();
        }
    }
    private void SendTheTroops()
    {
        for(int i = 0; i<officers.Length; i++)
        {
            if (!officers[i].Equals(null))
            {
                officers[i].GetThePrisoner();
            }
        }
        //Debug.Log("sending the troops");
    }
    public void TestGetBackToCell()
    {
        for(int i = 0; i < roomArray.Length; i++)
        {
            if(roomArray[i].roomName.Equals("Your Cell"))
            {
                desiredRoom = roomArray[i];
            }
        }
        if (!currentRoom.Equals(desiredRoom))
        {
            Debug.Log("Get Back To Room");
        }
        else
        {
            Debug.Log("lucky ass bitch");
            
        }
    }
    public void CallTheGaurdsOff()
    {
        for (int i = 0; i < officers.Length; i++)
        {
            if (!officers[i].Equals(null))
            {
                officers[i].CalledOff();
            }
        }
        Debug.Log("calling them off");
    }
}
