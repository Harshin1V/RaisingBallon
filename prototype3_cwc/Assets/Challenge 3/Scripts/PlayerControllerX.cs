using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    public float floatForce=50 ;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;

    int coins = 0;
    public TextMeshProUGUI coinsText;

    UIManger _uimanager;


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

        // Apply a small upward force at the start of the game
        playerRb = GetComponent<Rigidbody>();
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

        _uimanager = GameObject.Find("Canvas").GetComponent<UIManger>();
        if(!_uimanager)
        {
            Debug.Log("error");
        }

    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce);
            
        }
        if (this.transform.position.y >= 18.0f)
        {
            this.transform.position = new Vector2(transform.position.x, 18.0f);
            playerRb.AddForce(Vector3.down * floatForce);
        }
        else if (this.transform.position.y < 1.5f && !gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
            _uimanager.ActiveGO();
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            coins++;
            coinsText.text ="Coins: "+ coins.ToString();
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

    }

}
