using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RouletteManager : MonoBehaviour
{
    Vector2 startPoint, endPoint;
    float rotateX, rotateY, rotateSpeed = 0;
    public int rouletteResult;
    GameObject carMove;
    public CarManager car;

    // Start is called before the first frame update
    void Start()
    {
        carMove = GameObject.Find("RouletteResultText");
        rouletteResult = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (rouletteResult == 0 && rotateSpeed == 0 && car.leftLength > 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                startPoint = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                endPoint = Input.mousePosition;
                rotateX = endPoint.x - startPoint.x;
                rotateY = endPoint.y - startPoint.y;
                rotateSpeed = Mathf.Sqrt(rotateX * rotateX + rotateY * rotateY) * 0.01f;

                if ((startPoint.y > 210 && rotateX > 0 || startPoint.y < 210 && rotateX < 0))
                {
                    rotateSpeed *= -1;
                }

            }
        }
        

        if (rotateSpeed != 0 && Mathf.Abs(rotateSpeed) < 0.005)
        {
            rotateSpeed = 0;
            
            switch ((int)((transform.rotation.eulerAngles.z + 30) / 60))
            {
                case 0:
                    rouletteResult = 2;
                    break;
                case 1:
                    rouletteResult = 6;
                    break;
                case 2:
                    rouletteResult = 1;
                    break;
                case 3:
                    rouletteResult = 4;
                    break;
                case 4:
                    rouletteResult = 3;
                    break;
                default:
                    rouletteResult = 5;
                    break;
            }
            
        }

        carMove.GetComponent<TMP_Text>().text = "Move :  " + rouletteResult;
        transform.Rotate(0, 0, rotateSpeed);
        rotateSpeed *= 0.995f;

    }
}
