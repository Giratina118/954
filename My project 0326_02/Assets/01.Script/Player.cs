using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public GameObject shotCopyObj = null;
    GameObject shotCloneObj = null;

    public GameObject asteroidCopyObj = null;

    public float createSec = 2;
    float currentSec = 0;


    void Start()
    {
        
    }

    void CreateAsteroid()
    {
        GameObject asteroidCloneObj = GameObject.Instantiate(asteroidCopyObj);

        float randPosx = Random.Range(-8.0f, 8.0f);
        Vector3 randomPos = new Vector3(randPosx, 0, 10.0f);
        asteroidCloneObj.transform.position = new Vector3(randPosx, 0, 10.0f);
        asteroidCloneObj.SetActive(true);

    }


    void Update()
    {
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 pos = transform.position;
            pos.x -= moveSpeed * Time.deltaTime;
            this.transform.position = pos;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 pos = transform.position;
            pos.x += moveSpeed * Time.deltaTime;
            this.transform.position = pos;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 pos = transform.position;
            pos.z -= moveSpeed * Time.deltaTime;
            this.transform.position = pos;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 pos = transform.position;
            pos.z += moveSpeed * Time.deltaTime;
            this.transform.position = pos;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 pos = this.transform.position;
            pos.z += 1.0f;
            shotCloneObj = GameObject.Instantiate(shotCopyObj);
            shotCloneObj.transform.position = pos;
            shotCloneObj.SetActive(true);
        }


        currentSec -= Time.deltaTime;
        if (currentSec <= 0.0f)
        {
            currentSec = createSec;
            CreateAsteroid();
        }
    }
}
