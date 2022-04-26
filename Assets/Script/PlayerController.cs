using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    private Animator playerAnimator;
    private Rigidbody playerRidgidbody;
    private AudioSource playerAudio;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;


    // Start is called before the first frame update
    void Start()
    {
        playerRidgidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
      //playerRidgidbody.AddForce(Vector3.up * 1000);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            dirtParticle.Stop();
            playerRidgidbody.AddForce(Vector3.up * 10, ForceMode.Impulse);
            isOnGround = false;
            playerAnimator.SetTrigger("Jump_trig");
            //playerAudio.PlayOneShot(jumpSound, 1.0f);
        }   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            //playerAudio.PlayOneShot(crashSound,1.0f);
            gameOver = true;
            dirtParticle.Stop();
            explosionParticle.Play();
            Debug.Log("Game Over!");
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
        }
    }

}

/**
 * #Unity Analytics
 * Automatically resolve simple syntax errors in scripts. 
 * 
 * 
 * A message that accompanies a “commit” to a repository explaining a change that was made.
 **/
