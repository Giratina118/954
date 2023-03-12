using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    float rotSpeed = 0;     // ȸ�� �ӵ�
    int state = 0;          // 0-> �ʱ� ����,  1 -> ȸ�� ����,  2 -> ȸ�� �� ���� ���� (��� ��� ��),  3 -> ��� ����� ��

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(0))
        {
           //Debug.Log("���콺 Ŭ�� �Էµ�");
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
        

        // ȸ�� �ӵ���ŭ �귿�� ȸ���Ѵ�.
        transform.Rotate(0, 0, rotSpeed);
        //Debug.Log($"���� ���ǵ�: {rotSpeed}");

        
        if (state == 2)
        {  
            if (transform.rotation.eulerAngles.z >= 30 && transform.rotation.eulerAngles.z < 90)
                Debug.Log("��� ����");
            else if (transform.rotation.eulerAngles.z >= 90 && transform.rotation.eulerAngles.z < 150)
                Debug.Log("��� �ſ쳪��");
            else if (transform.rotation.eulerAngles.z >= 150 && transform.rotation.eulerAngles.z < 210)
                Debug.Log("��� ����");
            else if (transform.rotation.eulerAngles.z >= 210 && transform.rotation.eulerAngles.z < 270)
                Debug.Log("��� ����");
            else if (transform.rotation.eulerAngles.z >= 270 && transform.rotation.eulerAngles.z < 330)
                Debug.Log("��� ����");
            else
                Debug.Log("��� ����");

            state = 3;
        }
        
            
        

    }
}
