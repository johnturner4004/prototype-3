using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
  public GameObject[] obsticalPrefab;
  private float startDelay = 7.0f;
  private float repeatRate = 2.0f;
  private Vector3 spawnPosition;
  private PlayerController playerControllerScript;
  private MoveLeft moveLeftScript;
  // Start is called before the first frame update
  void Start()
  {
    moveLeftScript = GameObject.Find("Background").GetComponent<MoveLeft>();
    InvokeRepeating("SpawnObstical", startDelay, repeatRate);
    playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
  }

  // Update is called once per frame
  void Update()
  {

  }

  void SpawnObstical()
  {
    if (!playerControllerScript.gameOver)
    {
      int obsticalIndex = Random.Range(0, 3);
      playerControllerScript.score += obsticalIndex * 5;
      Debug.Log("Score = " + playerControllerScript.score);

      if (obsticalIndex == 2)
      {
        spawnPosition = new Vector3(25, 4, 0);
      } 
      else
      {
          spawnPosition = new Vector3(25, 0, 0);
      }

      Instantiate(obsticalPrefab[obsticalIndex], spawnPosition, obsticalPrefab[obsticalIndex].transform.rotation);
    }
  }
}
