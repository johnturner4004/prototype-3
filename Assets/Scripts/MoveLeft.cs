using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
  private float speed = 30.0f;
  private float leftBoundary = -10.0f;
  private PlayerController playerControllerScript;
  // Start is called before the first frame update
  void Start()
  {
    playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
  }

  // Update is called once per frame
  void Update()
  {
    if (playerControllerScript.gameOver == false)
    {
      transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
    }

    if (transform.position.x < leftBoundary && gameObject.CompareTag("Obstacle"))
    {
      Destroy(gameObject);
    }
  }
}