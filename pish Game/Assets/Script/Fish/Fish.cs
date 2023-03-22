using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{

    float min = -10;
    float max = 10;
    float randomizedNum;
    public int swimSpeed =1;

    bool random_moving_flag = false;

    public static bool catched_flag = false;
    void Start()
    {
     
        StartCoroutine("Random_Moving");
    }


    void Update()
    { 
        // x 는 30 ~ -20 
      
        if (catched_flag == false)
        {
            randomizedNum = Random.Range(min, max);
            moveForward();
            rotateHead();
        }
        else if (catched_flag == true)
        {
            StopCoroutine("Random_Moving");
        }
    }

    void moveForward()  // 앞으로 가는 함수
    {
        this.transform.Translate(Vector3.forward * Time.deltaTime*swimSpeed);
    }

    void rotateHead() // 생선 대가리 위치
    {
        if (random_moving_flag == true)
        {
            random_moving_flag = false;
            this.transform.Rotate(Vector3.up, 100);
            //Debug.Log(randomizedNum);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "wall")
        {
            this.transform.Rotate(Vector3.up, 180);
            Debug.Log("부딪힘");
        }

    }

    private IEnumerator Random_Moving()
    {
        while (true)
        {
            int randtime = (int)Random.Range(2, 8);
            yield return new WaitForSeconds(randtime);
            random_moving_flag = true; // 생선 대가리 위치 바꿈
        }
    }


}
