using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed;
    [SerializeField] float jumpForce = 5f;
    
    private bool isGrounded;
    
    [SerializeField] AudioSource jumpSound;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if(Input.GetButton("Fire3"))
        {
            movementSpeed = 5f;
        }
        else
        {
            movementSpeed = 2.5f;
        }
        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            PlayerPrefs.SetInt("HighScore " + SceneManager.GetActiveScene().name ,GameManager.highScore);
            PlayerPrefs.Save();
            SceneManager.LoadScene("MainMenuScene");
        }
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        jumpSound.Play();
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision other)
    {
        isGrounded = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ResetTrigger"))
        {
            PlayerPrefs.SetInt("HighScore " +  SceneManager.GetActiveScene().name,GameManager.highScore);
            PlayerPrefs.Save();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
