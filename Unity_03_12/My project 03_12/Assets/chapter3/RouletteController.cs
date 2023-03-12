using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    float rotSpeed = 0;     // 회전 속도
    int state = 0;          // 0-> 초기 상태,  1 -> 회전 상태,  2 -> 회전 후 멈춘 상태 (결과 출력 전),  3 -> 결과 출력한 후

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(0))
        {
           //Debug.Log("마우스 클릭 입력됨");
            //rotSpeed = 10;
            rotSpeed += 0.011f;

            state = 1;
        }
        else
        {
            //rotSpeed *= 0.98f;
            rotSpeed *= 0.995f;
        }

        /*
        if (state == 1 && rotSpeed < 0.1)
        {
            rotSpeed = 0;
            state = 2;
        }
        */
        
        if (state == 1 && rotSpeed < 0.01)
        {
            rotSpeed = 0;
            state = 2;
        }
        

        // 회전 속도만큼 룰렛을 회전한다.
        transform.Rotate(0, 0, rotSpeed);
        //Debug.Log($"현재 스피드: {rotSpeed}");

        
        if (state == 2)
        {  
            if (transform.rotation.eulerAngles.z >= 30 && transform.rotation.eulerAngles.z < 90)
                Debug.Log("운수 대통");
            else if (transform.rotation.eulerAngles.z >= 90 && transform.rotation.eulerAngles.z < 150)
                Debug.Log("운수 매우나쁨");
            else if (transform.rotation.eulerAngles.z >= 150 && transform.rotation.eulerAngles.z < 210)
                Debug.Log("운수 보통");
            else if (transform.rotation.eulerAngles.z >= 210 && transform.rotation.eulerAngles.z < 270)
                Debug.Log("운수 조심");
            else if (transform.rotation.eulerAngles.z >= 270 && transform.rotation.eulerAngles.z < 330)
                Debug.Log("운수 좋음");
            else
                Debug.Log("운수 나쁨");

            state = 3;
        }
        
            
        

    }
}
