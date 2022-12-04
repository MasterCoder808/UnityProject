using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public EnemyState enemyState;
    //changed bei trigger den boss
    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (ChangeRoomScript.roomState)
        {
            case ChangeRoomScript.RoomState.mainRoom:
                Debug.Log("Main Room Enemy");
                break;
            case ChangeRoomScript.RoomState.enis1:
                Debug.Log("Enis1 Room Enemy");
                break;
            case ChangeRoomScript.RoomState.enis2:
                Debug.Log("Enis2 Room Enemy");
                break;
            case ChangeRoomScript.RoomState.bedriye1:
                Debug.Log("Bedriye1 Room Enemy");
                break;
            case ChangeRoomScript.RoomState.bedriye2:
                Debug.Log("Bedriye2 Room Enemy");
                break;
            case ChangeRoomScript.RoomState.mustafa1:
                Debug.Log("Mustafa1 Room Enemy");
                break;
            case ChangeRoomScript.RoomState.mustafa2:
                Debug.Log("Mustafa2 Room Enemy");
                break;
            
        }
    }

    public enum EnemyState
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
