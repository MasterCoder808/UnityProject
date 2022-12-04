using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleSceneController : MonoBehaviour
{
    Animator anim;
    [SerializeField] private GameObject enisEnemy1;
    [SerializeField] private GameObject enisEnemy2;
    [SerializeField] private GameObject bedriyeEnemy1;
    [SerializeField] private GameObject bedriyeEnemy2;
    [SerializeField] private GameObject mustafaEnemy1;
    [SerializeField] private GameObject mustafaEnemy2; 
    
    private GameObject enemyObj;
    
    private void Awake()
    {
        FindEnemy();
        enemyObj.SetActive(true);
        anim = enemyObj.GetComponent<Animator>();
        Debug.Log(anim.name);
    }

    public void Hit()
    {
        anim.SetTrigger("Hit");
    }
    public void Attack()
    {
        anim.SetTrigger("Attack");
    }
    public void Special()
    {
        anim.SetTrigger("Special");
    }
    
    public void Run()
    {
        Debug.Log("Escape");
        SceneManager.LoadScene("SceneB2");
    }

    private void FindEnemy()
    {
        switch (ChangeRoomScript.roomState)
        {
            case ChangeRoomScript.RoomState.mainRoom:
                enemyObj= GameObject.Find("EnemyMain");
                enemyObj.SetActive(true);
                break;
            case ChangeRoomScript.RoomState.enis1:
                enemyObj = enisEnemy1;
                enemyObj.SetActive(true);
                break;
            case ChangeRoomScript.RoomState.enis2:
                enemyObj= enisEnemy2;
                enemyObj.SetActive(true);
                break;
            case ChangeRoomScript.RoomState.bedriye1:
                enemyObj= bedriyeEnemy1;
                enemyObj.SetActive(true);
                break;
            case ChangeRoomScript.RoomState.bedriye2:
                enemyObj= bedriyeEnemy2;
                enemyObj.SetActive(true);
                break;
            case ChangeRoomScript.RoomState.mustafa1:
                enemyObj = mustafaEnemy1;
                Debug.Log(enemyObj.name);
                break;
            case ChangeRoomScript.RoomState.mustafa2:
                enemyObj = mustafaEnemy2;
                Debug.Log(enemyObj.name);
                break;
        }
    }
}
