using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TopDownPlayerController : MonoBehaviour
{
    public static Rigidbody2D rb;
    Animator anim;
    private Vector2 moveVector;
    private PlayerMovement playerMovement;
    private InputAction moveInput;
    private InputAction fireInput;
    private InputAction sprintInput;
    private static bool spawned;
    private bool battleBool = false;

    [SerializeField] float speed = 5f;
    [SerializeField] float runMultiplier = 1.5f;
    
    private void Awake()
    {        
        if (!spawned)
        {
            gameObject.transform.position = new Vector3(1,-1.87f);
            spawned = true;
        }
        else
        {
            gameObject.transform.position = new Vector3(PlayerPrefs.GetFloat("xPos"),PlayerPrefs.GetFloat("yPos"));
        }
        playerMovement = new PlayerMovement();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        moveInput = playerMovement.Player.Move;
        moveInput.Enable();
        fireInput = playerMovement.Player.Fire;
        fireInput.Enable();
        fireInput.performed += EnterBattle;
        sprintInput = playerMovement.Player.Sprint;
        sprintInput.Enable();
    }
    
    private void OnDisable()
    {
        moveInput.Disable();
        fireInput.Disable();
        sprintInput.Disable();
    }

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveVector = moveInput.ReadValue<Vector2>();
        SetAnimations();
    }

    private void FixedUpdate()
    {
        if (sprintInput.inProgress)
        {
            rb.velocity = new Vector2(moveVector.x * speed * runMultiplier, moveVector.y * speed * runMultiplier);
        }
        else
        {
            rb.velocity = new Vector2(moveVector.x * speed, moveVector.y * speed);
        }
    }
    
    private void SetAnimations()
    { 
        // If the player is moving
        if (moveVector != Vector2.zero)
        {
            // Trigger transition to moving state
            anim.SetBool("IsMoving", true);

            // Set X and Y values for Blend Tree
            anim.SetFloat("MoveX", moveVector.x);
            anim.SetFloat("MoveY", moveVector.y);
        }
        else
            anim.SetBool("IsMoving", false);
    }
    private void EnterBattle(InputAction.CallbackContext context)
    {
        if (battleBool)
        {
            PlayerPrefs.SetFloat("xPos",gameObject.transform.position.x);
            PlayerPrefs.SetFloat("yPos",gameObject.transform.position.y);
            PlayerPrefs.Save();
            SceneManager.LoadScene("BattleScene");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        //false if trigger is leaved
        battleBool = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //true if trigger slime
        if (col.CompareTag("Enemy"))
        {
            if(ChangeRoomScript.roomState != ChangeRoomScript.RoomState.mainRoom)
                battleBool = true;
        }
    }
}
