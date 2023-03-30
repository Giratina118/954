using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float asteroidSpeed = 2.0f;
    public int score = 0;

    public Player player;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"충돌 : {other.gameObject.name}");

        GameObject.Destroy(this.gameObject);
        GameObject.Destroy(other.gameObject);

        score += 1;
        Debug.Log($"스코어 : {score}");

        player.createSec *= 0.98f;
        if (player.createSec < 0.5f)
            player.createSec = 0.5f;
    }

    void Start()
    {
        
    }


    void Update()
    {
        if (transform.position.z <= -10.0f)
            GameObject.Destroy(gameObject);

        asteroidSpeed = score * 0.2f + 2.0f;

        Vector3 pos = transform.position;
        pos.z -= asteroidSpeed * Time.deltaTime;
        transform.position = pos;

    }
}
