using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int randomValue = 20;
    private Vector2 firstPos;
    public List<float> radius;
    Vector2 finalDir;
    private int index;
    private bool increase = true;
    void Start()
    {
        firstPos = new Vector2(Random.Range(-randomValue, randomValue), Random.Range(-randomValue, randomValue));
        Vector2 dir = firstPos - Vector2.zero;
        dir.Normalize();
        int index = Random.Range(0, 2);
        finalDir = dir * radius[index];
        transform.position = finalDir;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (increase)
            {
                index++;
            }
            else
            {
                index--;
            }
            if(index >= 3)
            {
                index = radius.Count - 2;
                increase = false;
            }
            else if(index < 0) 
            {
                index = 1;
                increase = true;
            }

            Vector2 dir = (Vector2)transform.position - Vector2.zero;
            dir.Normalize();           
            finalDir = dir * radius[index];
            transform.position = finalDir;
        }
        transform.RotateAround(Vector2.zero,transform.forward,50f * Time.deltaTime);
    }
       
}
