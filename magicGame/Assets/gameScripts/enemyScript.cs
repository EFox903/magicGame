using System;
using Unity.Mathematics;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    [SerializeField] AudioSource soundE;
    [SerializeField] AudioClip spellA1;
    [SerializeField] AudioClip spellA2;
    [SerializeField] AudioClip spellA3;
    [SerializeField] AudioClip spellA4;
    [SerializeField] AudioClip spellA5;
    [SerializeField] GameObject wand;
    [SerializeField] AudioSource walkS;
    [SerializeField] Transform pT;
    [SerializeField] bool los;
    [SerializeField] int magicCoolDown;
    [SerializeField] int magicCoolDownSet;
    [SerializeField] GameObject eBlast;
    [SerializeField] GameObject eFire;
    [SerializeField] GameObject eIce;
    [SerializeField] GameObject spell;
    [SerializeField] int ehealth;
    [SerializeField] int eEffect;
    [SerializeField] int eEDuration;
    [SerializeField] string moveMode;
    [SerializeField] int patrolCooldown;
    [SerializeField] int enemySpeed;
    [SerializeField] int enemySpeedStan;
    Rigidbody2D rB;
    int moveDir;
    int sound;
    // Start is called before the first frame update
    void Start()
    {
        if(UnityEngine.Random.Range(0, 2) == 1)
        {
            spell = eBlast;
            magicCoolDownSet = 75;
            sound = 0;
        }
        else
        {
            if(UnityEngine.Random.Range(0, 2) == 1)
            {
                spell = eFire;
                magicCoolDownSet = 90;
                sound = 1;
            }
            else
            {
                spell = eIce;
                magicCoolDownSet = 90;
                sound = 2;
            }
        }
        
        enemySpeedStan = enemySpeed;
        rB = gameObject.GetComponent<Rigidbody2D>();
        moveMode = "patrol";
        patrolCooldown = 35 + UnityEngine.Random.Range(-8,10);
        GameObject p = GameObject.Find("player");
        pT = p.transform;
        magicCoolDown = magicCoolDownSet;
        ehealth = 100;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        healthCheck();
        effectsCheck();
        ray();
        if(los)
        { 
            Vector2 direction = new Vector2(pT.position.x - transform.position.x, pT.position.y - transform.position.y);
            transform.up = direction;
            transform.Rotate(0,0,transform.rotation.z + 90);
            
        }

        magic();
        move();
    }

    void ray()
    {
      RaycastHit2D[] ray = Physics2D.RaycastAll(transform.position,pT.position - transform.position);
      if(ray[1].collider != null)
      {
        bool temp = ray[1].collider.CompareTag("shield");
        if(temp)
        {
            
        los = ray[2].collider.CompareTag("player");
        if(los){
        Debug.DrawRay(transform.position,pT.position - transform.position,Color.green);
        }else{
         Debug.DrawRay(transform.position,pT.position - transform.position,Color.red);
      }
        }
        else
        {
            los = ray[1].collider.CompareTag("player");
      if(los){
        Debug.DrawRay(transform.position,pT.position - transform.position,Color.green);
        }else{
         Debug.DrawRay(transform.position,pT.position - transform.position,Color.red);
      }
        }
        

      }

    }
    void magic()
    {
        double dis = Math.Sqrt(Math.Pow(transform.position.x - pT.position.x,2) +  Math.Pow(transform.position.y - pT.position.y,2));
        if(magicCoolDown > 0)
        {
            magicCoolDown--;
        }
        else
        {
            if(los && dis <= 12)
            {
                if(sound == 0){
                    soundE.PlayOneShot(spellA1);
                }else if(sound == 1){
                    soundE.PlayOneShot(spellA4);
                }else if(sound == 2){
                    soundE.PlayOneShot(spellA3);
                }
                Instantiate(spell,wand.transform.position,transform.rotation);
                magicCoolDown = magicCoolDownSet;
            }
        }
    }

    void healthCheck()
    {
        if(ehealth <= 0){
            gameManager.enemysLeft --;
            Destroy(gameObject);
        }
    }
    void eDamage(int damage)
    {
        ehealth -= damage;
    }

    void move()
    {
        double dis = Math.Sqrt(Math.Pow(transform.position.x - pT.position.x,2) +  Math.Pow(transform.position.y - pT.position.y,2));
        if(dis <= 9 && los)
        {
            moveMode = "chase";
        } 
        else
        {
            moveMode = "patrol";
        }

      if(moveMode == "patrol")
      {
        if(patrolCooldown == 0)
        {
        moveDir = UnityEngine.Random.Range(1,5);
        patrolCooldown = 120;
        }else{
            if(patrolCooldown >= 60)
            {
                walkS.mute = false;
                if(moveDir == 1)
                {   
                    rB.linearVelocity = (new Vector2(enemySpeed, rB.linearVelocity.y));
                }
                if(moveDir == 2)
                {   
                    rB.linearVelocity = (new Vector2(-enemySpeed, rB.linearVelocity.y));
                }
                if(moveDir == 3)
                {   
                    rB.linearVelocity = (new Vector2( rB.linearVelocity.x,enemySpeed));
                }
                if(moveDir == 4)
                {   
                    rB.linearVelocity = (new Vector2( rB.linearVelocity.x, -enemySpeed));
                }
            }else{
                walkS.mute = true;
            }
            
        }
      }else
      {
        walkS.mute = false;
        transform.position = Vector2.MoveTowards(transform.position, pT.position, enemySpeed * 0.017f);
      }
        if(patrolCooldown > 0)
        {
            patrolCooldown --;
        }
    }
    void effectsCheck()
    {
        enemySpeed = enemySpeedStan;
        if(eEDuration > 0)
        {
            eEDuration --;
            if(eEffect != 0)
            {
            if(eEffect == 1)
            {
                enemySpeed = Convert.ToInt32(math.ceil(enemySpeed * 0.4));
            }
            }
            
        }
    }

    void setEffect(int effect){
        eEffect = effect;
    }
    void setEffectDur(int dur){
        eEDuration = dur;
    }
}

