using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    private float halfway;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        halfway = GetComponent<BoxCollider>().size.x / 2;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= startPos.x - halfway) transform.position = startPos;
    }
}
