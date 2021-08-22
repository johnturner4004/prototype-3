using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  private Rigidbody playerRb;
  public float jumpForce = 10.0f;
  public float gravityModifier = 1.0f;
  private int isOnGround = 2;
  public bool gameOver = false;
  private Animator playerAnimator;
  private AudioSource playerAudio;
  public ParticleSystem explosionParticle;
  public ParticleSystem dirtParticle;
  public AudioClip jumpSound;
  public AudioClip crashSound;
  private MoveLeft moveLeftScript;
  public int score;
  public float gameTime;
  public bool isRunning = false;
  // public Vector3 startPosition = new Vector3(-4, 0, 0);
  public Vector3 runPosition = new Vector3(2, 0, 0);
  // Start is called before the first frame update
  void Start()
  {
    playerRb = GetComponent<Rigidbody>();
    Physics.gravity *= gravityModifier;
    playerAnimator = GetComponent<Animator>();
    playerAudio = GetComponent<AudioSource>();
    moveLeftScript = GameObject.Find("Background").GetComponent<MoveLeft>();
  }

  // Update is called once per frame
  void Update()
  {
    // if (transform.position.x >= 2)
    // {
    //   moveLeftScript.isWalking = false;
    // }
    if (moveLeftScript.isWalking)
    {
      if (transform.position.x < 2)
      {
        transform.Translate(Vector3.forward * Time.deltaTime);
        playerAnimator.SetFloat("Speed_f", 0.3f);
      }
      else
      {
        playerAnimator.SetFloat("Speed_f", 1.0f);
        moveLeftScript.isWalking = false;
      }
    }
    if (!moveLeftScript.isWalking)
    {
      if (Input.GetKeyDown(KeyCode.Space) && isOnGround > 0 && !gameOver)
      {
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isOnGround -= 1;
        playerAnimator.SetTrigger("Jump_trig");
        dirtParticle.Stop();
        playerAudio.PlayOneShot(jumpSound, 4.0f);
      }

      if (Input.GetKey(KeyCode.F) && !gameOver)
      {
        isRunning = true;
      }
      else
      {
        isRunning = false;
      }

      gameTime += Time.deltaTime;
      if (gameTime >= 1 && !gameOver)
      {
        if (!isRunning)
        {
          score += 1;
          gameTime = 0.0f;
          Debug.Log("Score = " + score);
        }
        else if (isRunning)
        {
          score += 3;
          gameTime = 0.0f;
        }
      }
    }
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("Ground") && !gameOver)
    {
      isOnGround = 2;
      dirtParticle.Play();
    }
    else if (collision.gameObject.CompareTag("Obstacle"))
    {
      gameOver = true;
      Debug.Log("Game Over. Final score = " + score);
      playerAnimator.SetBool("Death_b", true);
      playerAnimator.SetInteger("DeathType_int", 1);
      explosionParticle.Play();
      dirtParticle.Stop();
      playerAudio.PlayOneShot(crashSound, 3.0f);
    }
  }
}
