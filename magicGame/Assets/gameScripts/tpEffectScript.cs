using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tpEffectScript : MonoBehaviour
{
    [SerializeField] Light l;
    [SerializeField] int timer = 0;
    [SerializeField] int timerL;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer++;
        if (timer <= timerL / 2)
        {
            l.intensity += 0.2f;
        }
        else
        {
            l.intensity += -0.2f;
        }
        if (timer == timerL)
        {
            Destroy(gameObject);
        }
    }
}
