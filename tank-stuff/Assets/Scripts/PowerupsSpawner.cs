using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupsSpawner : MonoBehaviour
{

    public GameObject[] powerups;
    [SerializeField] private float Timer = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Timer);
        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-8,8), Random.Range(-4,4), 0);
            //Debug.Log("Spawning Powerup");
            Instantiate(powerups[Random.Range(0,powerups.Length)], randomPosition, Quaternion.identity);
            Timer = 5f;
        }
    }
}
