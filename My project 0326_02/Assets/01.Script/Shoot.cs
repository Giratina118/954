using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float shotSpeed = 10.0f;

    void Start()
    {
        
    }


    void Update()
    {
        if (transform.position.z >= 10.0f)
            GameObject.Destroy(gameObject);
        
        Vector3 pos = transform.position;
        pos.z += shotSpeed * Time.deltaTime;
        transform.position = pos;
    }
}
