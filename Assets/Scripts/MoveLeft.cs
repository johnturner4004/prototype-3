using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
  private float speed = 30.0f;
  private float leftBoundary = -10.0f;
  private PlayerController playerControllerScript;
  public bool isWalking = true;
  // Start is called before the first frame update
  void Start()
  {
    playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
  }

  // Update is called once per frame
  void Update()
  {
    if (isWalking)
    {
      speed = 0.0f;
    }
    else
    {
      speed = 30.0f;
    }
    if (playerControllerScript.isRunning && !playerControllerScript.gameOver)
    {
      transform.Translate(Vector3.left * speed * 2 * Time.deltaTime, Space.World);
    }
    else if (!playerControllerScript.gameOver)
    {
      transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
    }

    if (transform.position.x < leftBoundary && gameObject.CompareTag("Obstacle"))
    {
      Destroy(gameObject);
    }
  }
}