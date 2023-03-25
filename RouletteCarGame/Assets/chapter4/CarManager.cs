using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using TMPro;

public class CarManager : MonoBehaviour
{
    public RouletteManager Roulette;
    GameObject leftLengthText;
    public int leftLength = 14;

    // Start is called before the first frame update
    void Start()
    {
        leftLengthText = GameObject.Find("LeftLengthText");
    }

    // Update is called once per frame
    void Update()
    {
        if (Roulette.rouletteResult > 0)
        {
            Thread.Sleep(500);
            transform.Translate(1, 0, 0);
            Roulette.rouletteResult--;
            leftLength--;
        }


        leftLengthText.GetComponent<TMP_Text>().text = $"Left Length :  {leftLength}";


        if (Roulette.rouletteResult == 0)
        {
            if (leftLength < 0)
            {
                leftLengthText.GetComponent<TMP_Text>().text = "Lose";
            }
            else if (leftLength < 2)
            {
                leftLengthText.GetComponent<TMP_Text>().text = "Win";
            }
        }
        


    }
}
