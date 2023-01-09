using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;
    Animator playerAnim;
    AudioSource playerAudio;
    public ParticleSystem dirtAnim;
    public ParticleSystem explosionAnim;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    [SerializeField] float jumpForce = 10;
    [SerializeField] float gravityModifier = 1;
    public bool isGrounded = true;
    public bool gameOver = false;
    


    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) &&  isGrounded && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            playerAudio.PlayOneShot(jumpSound, 1.5f);
            playerAnim.SetTrigger("Jump_trig");
            dirtAnim.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            dirtAnim.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            dirtAnim.Stop();
            explosionAnim.Play();
            playerAudio.PlayOneShot(crashSound, 2f);
        }

    }
}
