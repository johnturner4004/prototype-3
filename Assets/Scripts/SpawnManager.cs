using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
  public GameObject obsticalPrefab;
  private Vector3 spawnPosition = new Vector3(25, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(obsticalPrefab, spawnPosition, obsticalPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
