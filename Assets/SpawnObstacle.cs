using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    private PlayerController playerControllerScript;
    public GameObject obstacle;
    public float initialWait = 2.0f;
    public float intervalTime = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("Spawn", initialWait, intervalTime);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void Spawn()
    {
        if (playerControllerScript.getGameOver() == true)
        {
            CancelInvoke();
            return;
        }
        Instantiate(obstacle, transform);
    }
}
