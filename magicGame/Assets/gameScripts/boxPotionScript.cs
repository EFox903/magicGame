using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxScript : MonoBehaviour
{
    public GameObject potion;
    [SerializeField] int healAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void destroy()
    {
        Instantiate(potion,transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("player"))
        {
            GameObject.Find("player").SendMessage("pDamage", -healAmount);
            Destroy(gameObject);
        }
    }
}
