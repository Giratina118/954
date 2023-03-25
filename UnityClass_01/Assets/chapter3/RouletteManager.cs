using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Android.Gradle;
using UnityEngine;
using UnityEngine.UIElements;

public class RouletteManager : MonoBehaviour
{
    float rouletteSpeed = 0;
    public int rouletteState = 0;
    public int rouletteNumber = 0;
    GameObject leftChance;

    // Start is called before the first frame update
    void Start()
    {
        leftChance = GameObject.Find("leftChanceText");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && rouletteState == 0)
        {
            rouletteSpeed += 0.05f;
        }
        if (Input.GetMouseButtonUp(0) && rouletteState == 0)
        {
            rouletteState = 1;
        }

        if (rouletteSpeed <= 0.01 && rouletteState == 1)
        {
            Debug.Log("����");
            rouletteSpeed = 0;
            rouletteState = 2;
        }

        rouletteSpeed *= 0.995f;
        transform.Rotate(0, 0, rouletteSpeed);
        
        if (rouletteState == 2)
        {
            switch (((int)transform.rotation.eulerAngles.z + 30) / 60)
            {
                
                case 0:
                    Debug.Log("�������");
                    rouletteNumber = 2;
                    break;
                case 1:
                    Debug.Log("�������");
                    rouletteNumber = 6;
                    break;
                case 2:
                    Debug.Log("����ſ쳪��");
                    rouletteNumber = 1;
                    break;
                case 3:
                    Debug.Log("�������");
                    rouletteNumber = 4;
                    break;
                case 4:
                    Debug.Log("�������");
                    rouletteNumber = 3;
                    break;
                default:
                    Debug.Log("�������");
                    rouletteNumber = 5;
                    break;
            }
            rouletteState = 3;
        }
        

        if (rouletteState == 3)
        {
            leftChance.GetComponent<TMP_Text>().text = "Left Chance :  " + rouletteNumber;
        }

        // 0 ~ 30, 330 ~ 360
        // 30 ~ 90
        // 90 ~ 150
        // 150 ~ 210
        // 210 ~ 270
        // 270 ~ 330

    }
}
