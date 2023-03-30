using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float ShotSpeed = 5.0f;

    public float LifeSec = 0f;
    public float RemineSec = 3;
    public static int score = 0;
    public int val = 10;


    private void OnCollisionEnter(Collision collision)
    {
        /*
        Shoot ss = new Shoot();
        Shoot ss2 = new Shoot();
        */
        Debug.Log($"충돌 : {collision.gameObject.name}");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"충돌 : {other.gameObject.name}");

        GameObject.Destroy(this.gameObject);
        GameObject.Destroy(other.gameObject);

        score += 1;
        this.val = 10;
        Debug.Log($"스코어 : {Shoot.score}");
    }

    

    void Start()
    {
        
    }


    void Update()
    {
        
        LifeSec += Time.deltaTime;
        if (LifeSec > RemineSec)
        {
            GameObject.Destroy(gameObject);
        }
        
        /*
        if (transform.position.y >= 30.0f)
            GameObject.Destroy(gameObject);
        */

        Vector3 pos = transform.position;
        pos.y += ShotSpeed * Time.deltaTime;
        transform.position = pos;

        
    }
}
