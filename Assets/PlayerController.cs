using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 400;
    public float gravityMod = 1;
    private bool isGrounded = true;
    private bool inputLocked = true;
    private Rigidbody playerRb;
    private bool gameOver = false;
    private Animator playerAnim;
    private AudioSource sfx;
    public ParticleSystem explosion;
    public AudioClip[] crashSound = new AudioClip[3];
    public AudioClip jumpSound;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        sfx = GetComponent<AudioSource>();
        Physics.gravity = new Vector3(0, -9.8f * gravityMod, 0);
        inputLocked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputLocked) return;
        foreach(Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                Touch();
                break;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space)) Touch();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && gameOver == false)
        {
            isGrounded = true;
            playerAnim.SetBool("Jump_b", false);
        }
        else if (collision.gameObject.CompareTag("Obstacle") && gameOver == false)
        {
            inputLocked = true;
            Invoke("unlockInput", 0.4f);
            playerRb.constraints = RigidbodyConstraints.FreezeAll;
            playerRb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            Physics.gravity *= 0.25f;
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosion.Play();
            sfx.PlayOneShot(crashSound[Random.Range(0, 3)]);
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * playerRb.mass * collision.gameObject.GetComponent<MoveLeft>().speed);
        }
    }
    private void Touch()
    {
        if (isGrounded && gameOver == false)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            sfx.PlayOneShot(jumpSound);
            isGrounded = false;
        }
        else if (gameOver == true)
        {
            SceneManager.LoadScene("Prototype 3");
        }
    }
    public bool getGameOver() { return gameOver; }
    private void unlockInput() { inputLocked = false; }
}
