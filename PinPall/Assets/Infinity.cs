using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infinity : MonoBehaviour
{
    [SerializeField] GameObject[] locations;
    [SerializeField] GameObject prima;
    [SerializeField] float lenght_y;
    [SerializeField] float lenght_x;
    private float playerPositionY;
    private float lastSpawnPositionY;
    private float lastSpawnPositionX;
    public int additionalLocations = 2;
    public Transform player;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        lastSpawnPositionY = prima.transform.position.y;
        lastSpawnPositionX = prima.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 5f)
        {
            GenerateAdditionalLocations();
            playerPositionY = 0 + player.transform.position.y;
            timer = 0;
        }
    }

    void GenerateAdditionalLocations()
    {
        for(int i = 0; i<additionalLocations; i++)
        {
            lastSpawnPositionY = lastSpawnPositionY + lenght_y;
            lastSpawnPositionX = lastSpawnPositionX + lenght_x;
            int randomIndex = Random.Range(0, locations.Length);
            GameObject selectedPrefab = locations[randomIndex];
            GameObject newlocation = Instantiate(selectedPrefab, new Vector3(lastSpawnPositionX, lastSpawnPositionY, 0), Quaternion.identity);
        }
    }
}
