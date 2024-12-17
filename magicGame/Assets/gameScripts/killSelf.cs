using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killSelf : MonoBehaviour
{
    [SerializeField] int time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time --;
        if(time <= 0)
        {
            Destroy(gameObject);
        }
    }
}
