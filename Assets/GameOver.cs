using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<TextMeshPro>().transform.position = new Vector3(100, 100, 100);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<PlayerController>().getGameOver())
            gameObject.GetComponent<TextMeshPro>().transform.position = new Vector3(5, 3, -5);
    }
}
