using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
  public GameObject obsticalPrefab;
  public float startDelay = 2.0f;
  public float repeatRate = 2.0f;
  private Vector3 spawnPosition = new Vector3(25, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
      InvokeRepeating("SpawnObstical", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstical()
    {
        Instantiate(obsticalPrefab, spawnPosition, obsticalPrefab.transform.rotation);
    }
}
