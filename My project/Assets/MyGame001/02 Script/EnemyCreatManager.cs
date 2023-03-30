using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreatManager : MonoBehaviour
{
    public GameObject copyObj = null;
    public float createSec = 1;
    public float currentSec = 0;

    void Start()
    {
        
    }

    void CreateMob()
    {
        GameObject cloneObj = GameObject.Instantiate(copyObj);

        float randPosx = Random.Range(-17.0f, 17.0f);
        Vector3 randomPos = new Vector3(randPosx, 5.0f, 0);
        cloneObj.transform.position = new Vector3(randPosx, 5.0f, 0);
        cloneObj.SetActive(true);

    }

    void Update()
    {
        currentSec -= Time.deltaTime;
        if (currentSec <= 0)
        {
            currentSec = createSec;
            CreateMob();
        }
    }
}
