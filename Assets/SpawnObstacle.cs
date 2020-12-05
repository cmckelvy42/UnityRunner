using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    private PlayerController playerControllerScript;
    public GameObject obstacle;
    public float timerMin = 0.85f;
    public float timerMax = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        StartCoroutine(Spawn());
    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private IEnumerator Spawn()
    {
        int mod = 3;
        while (playerControllerScript.getGameOver() == false)
        {
            float min = timerMin;
            float max = timerMax;
            float timeSinceStart = Time.timeSinceLevelLoad;
            int rnd = Random.Range(0, 10);

            if (timeSinceStart < 60)
                max += 0.60f - Mathf.Floor(timeSinceStart * 0.01f);
            if (timeSinceStart < 30)
            {
                min += 0.30f - Mathf.Floor(timeSinceStart * 0.01f);
                mod = (int)(timeSinceStart * 0.1f); //modify the random range for quick spawns if under 30 seconds, caps after 30
            }

            if (rnd < mod)
            {
                min = 0.1f;
                max = 0.1f;

                Instantiate(obstacle, transform);
                yield return new WaitForSeconds(Random.Range(min, max));
            }
            else
            {
                Instantiate(obstacle, transform);
                yield return new WaitForSeconds(Random.Range(min, max));
            }
        }
    }
}
