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
  // Start is called before the first frame update
  void Start()
  {
    playerRb = GetComponent<Rigidbody>();
    Physics.gravity *= gravityModifier;
    playerAnimator = GetComponent<Animator>();
    playerAudio = GetComponent<AudioSource>();
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space) && isOnGround > 0 && !gameOver)
    {
      playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
      isOnGround -= 1;
      playerAnimator.SetTrigger("Jump_trig");
      dirtParticle.Stop();
      playerAudio.PlayOneShot(jumpSound, 4.0f);
    }

    gameTime += Time.deltaTime;
      if (gameTime >= 1 && !gameOver)
      {
        score += 1;
        gameTime = 0.0f;
        Debug.Log("Score = " + score);
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
