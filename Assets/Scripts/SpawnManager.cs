using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
  public GameObject[] obsticalPrefab;
  public float startDelay = 2.0f;
  public float repeatRate = 2.0f;
  private Vector3 spawnPosition;
  private PlayerController playerControllerScript;
  // Start is called before the first frame update
  void Start()
  {
    InvokeRepeating("SpawnObstical", startDelay, repeatRate);
    playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
  }

  // Update is called once per frame
  void Update()
  {

  }

  void SpawnObstical()
  {
    if (playerControllerScript.gameOver == false)
    {
      int obsticalIndex = Random.Range(0, 3);

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
