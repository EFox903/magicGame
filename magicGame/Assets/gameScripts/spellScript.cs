using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellScript : MonoBehaviour
{
    public Rigidbody2D rB;
    public int spellSpeed;
    public int spellDamage;
    public int spellEffect;
    public int spellEffectDur;
    int[] effects;
    float rotation;
    // Start is called before the first frame update
    void Start()
    {
        
         Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
            transform.up = direction;
            transform.position = new Vector3(transform.position.x + transform.up.x , transform.position.y + transform.up.y , transform.position.z);
            transform.Rotate(0,0,transform.rotation.z + 90);
            transform.Rotate(0,0,rotation);
            rB.linearVelocity = (transform.right * spellSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("player") == false){
            if(collision.gameObject.CompareTag("enemy"))
            {
                
                collision.gameObject.SendMessage("eDamage", spellDamage);
                collision.gameObject.SendMessage("setEffect", spellEffect);
                collision.gameObject.SendMessage("setEffectDur", spellEffectDur);
            }
            if(collision.gameObject.CompareTag("box"))
            {
                collision.gameObject.SendMessage("destroy");
            }
        Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(gameObject.name == "snow(Clone)")
        {
            if(col.gameObject.CompareTag("enemy"))
            {
                col.gameObject.SendMessage("eDamage", spellDamage);
                col.gameObject.SendMessage("setEffect", spellEffect);
                col.gameObject.SendMessage("setEffectDur", spellEffectDur);

            }
            if(col.gameObject.CompareTag("box"))
            {
                col.gameObject.SendMessage("destroy");
            }
        }
    }
    void rotate(float r)
    {
        rotation = r;
    }
}
