using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSetUp : MonoBehaviour
{
    public GameObject spacePrefab;

    public float distanceBetweenSpaces = 1;

    private GameObject[] gameObjects;

    public float BaseDistance { get { return distanceBetweenSpaces / 2; } }

    public float HeightDistance { get { return Mathf.Sqrt((distanceBetweenSpaces * distanceBetweenSpaces) - ((distanceBetweenSpaces / 2) * (distanceBetweenSpaces / 2))); }}
    

    // Start is called before the first frame update
    void Start()
    {
        gameObjects = new GameObject[121];
        for(int i = 0;i<121;i++)
        {
            gameObjects[i] = Instantiate(spacePrefab);
        }
        gameObjects[1].transform.position = new Vector3(-BaseDistance, -HeightDistance, 0);
        gameObjects[2].transform.position = new Vector3(BaseDistance, -HeightDistance, 0);
        float level = 2;
        gameObjects[3].transform.position = new Vector3(-BaseDistance * 2, -HeightDistance * level, 0);
        gameObjects[4].transform.position = new Vector3(0, -HeightDistance * level, 0);
        gameObjects[5].transform.position = new Vector3(BaseDistance * 2, -HeightDistance * level, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
