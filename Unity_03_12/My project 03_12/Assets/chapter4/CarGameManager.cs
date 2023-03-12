using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class CarGameManager : MonoBehaviour
{
    CarController carController;

    GameObject car;
    GameObject flag;
    GameObject distanceText;
    public bool result = true;
    public float length;

    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.Find("car");
        flag = GameObject.Find("flag");
        distanceText = GameObject.Find("Distance");

        carController = car.GetComponent<CarController>();

        string[] recode;
        if (File.Exists("recode.txt"))
        {
            recode = File.ReadAllText("recode.txt").Split(" ");
        }

        //string recodeName = recode[0];

    }

    // Update is called once per frame
    void Update()
    {
        if (result)
        {
            length = flag.transform.position.x - car.transform.position.x;
            distanceText.GetComponent<TMP_Text>().text = "Distance : " + length.ToString("F2") + "m";
            if (length <= 0.5 && carController.speed <= 0.0001 && carController.speed >= -0.0001)
            {
                if (length < 0)
                {
                    Debug.Log("Lose");
                    distanceText.GetComponent<TMP_Text>().text = "Lose";
                }
                else
                {
                    Debug.Log("Win");
                    distanceText.GetComponent<TMP_Text>().text = "Win";
                }

                result = false;
            }
        }
        
        if (carController.count == 5 && result == false && length > 0.5)
        {
            Debug.Log("Lose");
            distanceText.GetComponent<TMP_Text>().text = "Lose";
            carController.count++;
        }



    }
}
