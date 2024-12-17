using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpellScript : MonoBehaviour
{
    public Rigidbody2D rB;
    public int spellSpeed;
    public int spellDamage;
    public int spellEffect;
    public int spellEffectDur;
    [SerializeField] GameObject p;
    // Start is called before the first frame update
    void Start()
    {
        p = GameObject.Find("player");
         

            rB.linearVelocity = (transform.right * spellSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("enemy") == false)
        {
            if(collision.gameObject.CompareTag("player"))
            {
                p.SendMessage("pDamage", spellDamage);
                p.SendMessage("setEffect", spellEffect);
                p.SendMessage("setEffectDur", spellEffectDur);
            }
            Destroy(gameObject);
        }
    }
}

