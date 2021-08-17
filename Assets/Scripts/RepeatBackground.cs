using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
  private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
  {
    startPosition = transform.position;
  }

  // Update is called once per frame
  void Update()
  {
    if (transform.position.x < startPosition.x - 50.0f)
    {
      transform.position = startPosition;
    }
  }
}
