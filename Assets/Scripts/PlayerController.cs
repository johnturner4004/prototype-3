using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  private Rigidbody playerRb;
  public float jumpForce = 10.0f;
  public float gravityModifier = 1.0f;
  private bool isOnGround = true;
  public bool gameOver = false;
  private Animator playerAnimator;
  public ParticleSystem explosionParticle;
  public ParticleSystem dirtParticle;
  public AudioClip jumpSound;
  public AudioClip crashSound;
  // Start is called before the first frame update
  void Start()
  {
    playerRb = GetComponent<Rigidbody>();
    Physics.gravity *= gravityModifier;
    playerAnimator = GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space) && isOnGround  && !gameOver)
    {
      playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
      isOnGround = false;
      playerAnimator.SetTrigger("Jump_trig");
      dirtParticle.Stop();
    }
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("Ground") && !gameOver)
    {
      isOnGround = true;
      dirtParticle.Play();
    }
    else if (collision.gameObject.CompareTag("Obstacle"))
    {
      gameOver = true;
      Debug.Log("Game Over");
      playerAnimator.SetBool("Death_b", true);
      playerAnimator.SetInteger("DeathType_int", 1);
      explosionParticle.Play();
      dirtParticle.Stop();
    }
  }
}
