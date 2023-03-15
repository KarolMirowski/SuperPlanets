using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inst : MonoBehaviour
{
    public GameObject obj;
    public int num1;
    public int num2;


    private void Start()
    {
        for (int i = 0; i < num1; i++)
        {
            for (int x = 0; x < num2; x++)
            {
                Instantiate(obj, new Vector3(i, 40, x), Quaternion.identity);
         
            
            }

        }
    }

    private void Awake()
    {
        for (int i = 0; i < num1; i++)
        {
            for (int x = 0; x < num2; x++)
            {
                Instantiate(obj, new Vector3(i, 40, x), Quaternion.identity);
            }
        }
    }
   
    
}
