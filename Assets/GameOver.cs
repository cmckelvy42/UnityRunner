using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    private TextMeshPro text;
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<TextMeshPro>();
        text.transform.position = new Vector3(100, 100, 100);
#if UNITY_WEBGL
        text.text = "Game Over\n<size=30%>Press Space to restart</size>";
#endif
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<PlayerController>().getGameOver())
            gameObject.GetComponent<TextMeshPro>().transform.position = new Vector3(5, 3, -5);
    }
}
