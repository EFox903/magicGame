using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldScript : MonoBehaviour
{
    [SerializeField] int shieldHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
       if(col.gameObject.CompareTag("eSpell") )
       {
       var temp = col.gameObject.GetComponent<enemySpellScript>();
       shieldHealth -= temp.spellDamage;
       Destroy(col.gameObject);
       if(shieldHealth <= 0)
       {  
        Destroy(gameObject);
        Destroy(col.gameObject);
       }
       else
       {
        Destroy(col.gameObject);
       }
       }
    }
}
