using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public CarGameManager carGameManager;

    public float speed = 0;
    Vector2 startPos;
    public int count = 0;

    float mouseLength;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (speed < 0.0001 && speed > -0.0001)
        {
            if (count == 5)
            {
                carGameManager.result = false;
            }
            if (Input.GetMouseButtonDown(0))
            {
                startPos = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                Vector2 endPos = Input.mousePosition;

                mouseLength = endPos.x - startPos.x;
                speed = mouseLength / 2000.0f;

                GetComponent<AudioSource>().Play();
                count++;
            }
            
        }
        

        if (carGameManager.result)
        {
            transform.Translate(speed, 0, 0);
            speed *= 0.98f;
        }

        
        



    }
}
