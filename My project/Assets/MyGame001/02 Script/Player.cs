using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    public GameObject copyObj = null;
    public float ShotSpeed = 5;
    public Transform BulletPos = null;

    public float m_RemineSec = 1;
    public float spaceDealySec = 0;

    GameObject cloneObj = null;
    List<GameObject> cloneObjList = new List<GameObject>();


    void Start()
    {
        
    }


    void Update()
    {
        // 이동처리 마우스 키보드
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            Vector3 pos = transform.position;
            pos.x -= moveSpeed * Time.deltaTime;
            this.transform.position = pos;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            Vector3 pos = transform.position;
            pos.x += moveSpeed * Time.deltaTime;
            this.transform.position = pos;
        }

        m_RemineSec -= Time.deltaTime;


        // 발사체
        if (m_RemineSec <= 0.0f && Input.GetKeyDown(KeyCode.Space))
        {
            m_RemineSec = spaceDealySec;

            Vector3 pos = transform.position;
            pos.y = 0.76f;
            cloneObj = GameObject.Instantiate(copyObj);
            cloneObj.transform.position = BulletPos.position;
            cloneObj.SetActive(true);

            Shoot cloneshot = cloneObj.GetComponent<Shoot>();
            cloneshot.ShotSpeed = 5.0f;

            cloneObjList.Add(cloneObj);
        }

        


    }
}
