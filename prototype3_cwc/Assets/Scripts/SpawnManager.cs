using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private Vector3 spawnPoz = new Vector3(25,0,0);
    public GameObject obstraclePrefab;
    public int startDelay = 2;
    public int repeatrate = 2;

    private PlayerController playerControllerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstracles"  ,startDelay ,repeatrate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObstracles()
    {
        if(playerControllerScript.gameOver==false)
        {
            Instantiate(obstraclePrefab , spawnPoz , obstraclePrefab.transform.rotation);
        }
        
    }
}
