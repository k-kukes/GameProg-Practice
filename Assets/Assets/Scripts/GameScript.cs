using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    private float nextStarTime = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        nextStarTime = Time.deltaTime;
        if (nextStarTime > 3f )
        {
            float xPos = Random.Range(-25f, 25f);
            Vector3 newPos = new Vector3(xPos, 0f, 5f);
            nextStarTime = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
