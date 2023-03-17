using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    public RouletteManager roulette;
    Vector2 startPos;
    Vector2 endPos;
    float carSpeed = 0.0f;
    int carState = 0;
    float goalLength;

    GameObject car;
    GameObject flag;
    GameObject leftLength;


    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.Find("car");
        flag = GameObject.Find("flag");
        leftLength = GameObject.Find("leftLength");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (roulette.rouletteNumber > 0)
        {
            if (carState == 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    startPos = Input.mousePosition;
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    endPos = Input.mousePosition;
                    carState = 1;
                }
                carSpeed = (endPos.x - startPos.x) / 3000;
            }
            if (carState == 1)
            {
                transform.Translate(carSpeed, 0, 0);
                
                carSpeed *= 0.98f;

                if (carSpeed <= 0.01 && carSpeed >= -0.01)
                {
                    carSpeed = 0;
                    carState = 2;
                }
                goalLength = flag.transform.position.x - car.transform.position.x;
                leftLength.GetComponent<TMP_Text>().text = "Left Length :  " + goalLength + "m";
            }
            if (carState == 2)
            {
                roulette.rouletteNumber -= 1;

                if (goalLength < 0 || roulette.rouletteNumber <= 0)
                {
                    Debug.Log("Lose");
                    leftLength.GetComponent<TMP_Text>().text = "Lose";
                    carState = 3;
                }
                else if (goalLength <= 0.5)
                {
                    Debug.Log("Win");
                    leftLength.GetComponent<TMP_Text>().text = "Win";
                    carState = 3;
                }
                else
                {
                    carState = 0;
                }
            }
        }
        

    }
}
