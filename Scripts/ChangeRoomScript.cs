using UnityEngine;

public class ChangeRoomScript : MonoBehaviour
{
    public static RoomState roomState = RoomState.mainRoom;
    [SerializeField] private GameObject playerObj;

    private void Awake()
    {
        if (playerObj == null)
            playerObj = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // from main room to different rooms
        if (roomState == RoomState.mainRoom)
        {
            if (col.CompareTag("DoorEnis1"))
            {
                playerObj.transform.position = new Vector2(-30, -6);
                roomState = RoomState.enis1;
            }
            if (col.CompareTag("DoorEnis2"))
            {
                playerObj.transform.position = new Vector2(-30, 7);
                roomState = RoomState.enis2;
            }
            if (col.CompareTag("DoorBedriye1"))
            {
                playerObj.transform.position = new Vector2(-16, 21);
                roomState = RoomState.bedriye1;
            }
            else if (col.CompareTag("DoorBedriye2"))
            {
                playerObj.transform.position = new Vector2(17, 21);
                roomState = RoomState.bedriye2;
            }
            else if (col.CompareTag("DoorMustafa1"))
            {
                playerObj.transform.position = new Vector2(31, 7);
                roomState = RoomState.mustafa1;
            }
            else if (col.CompareTag("DoorMustafa2"))
            {
                playerObj.transform.position = new Vector2(31, -7);
                roomState = RoomState.mustafa2;
            }
        }
        //from enis room to main room
        if (col.CompareTag("DoorMain") && roomState == RoomState.enis1)
        {
            playerObj.transform.position = new Vector2(-18, -6);
            roomState = RoomState.mainRoom;
        }
        if (col.CompareTag("DoorMain") && roomState == RoomState.enis2)
        {
            playerObj.transform.position = new Vector2(-18, 7);
            roomState = RoomState.mainRoom;
        }
        
        //from bedriye room to main room
        if (col.CompareTag("DoorMain") && roomState == RoomState.bedriye1)
        {
            playerObj.transform.position = new Vector2(-16, 9);
            roomState = RoomState.mainRoom;
        }
        if (col.CompareTag("DoorMain") && roomState == RoomState.bedriye2)
        {
            playerObj.transform.position = new Vector2(17, 9);
            roomState = RoomState.mainRoom;
        }
        
        //from mustafa room to main room
        if (col.CompareTag("DoorMain") && roomState == RoomState.mustafa1)
        {
            playerObj.transform.position = new Vector2(19, 7);
            roomState = RoomState.mainRoom;
        }
        if (col.CompareTag("DoorMain") && roomState == RoomState.mustafa2)
        {
            playerObj.transform.position = new Vector2(19, -7);
            roomState = RoomState.mainRoom;
        }
    }

    public enum RoomState
    {
        mainRoom,
        enis1,
        enis2,
        bedriye1,
        bedriye2,
        mustafa1,
        mustafa2
    }
}
