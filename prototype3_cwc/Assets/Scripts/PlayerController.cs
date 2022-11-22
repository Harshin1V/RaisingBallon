using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float jumpForce = 10;
    public float gravityModifier ;
    private Rigidbody palyerRb;
    public bool isOnGround = true;
    public bool gameOver;

    private Animator playerAnime;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jump;
    public AudioClip crash;
    private AudioSource playerAudio;

    void Start()
    {
        palyerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnime = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            palyerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnime.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jump,1.0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if(collision.gameObject.CompareTag("Obstracle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");

            playerAnime.SetBool("Death_b" , true);
            playerAnime.SetInteger("DeathType_int",1);

            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crash,1.0f);

        }
        
    }
}
