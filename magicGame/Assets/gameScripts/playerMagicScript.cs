using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class playerMagicScript : MonoBehaviour
{
    [SerializeField] GameObject wand;
    [SerializeField] AudioSource sound;
    [SerializeField] AudioClip spellA1;
    [SerializeField] AudioClip spellA2;
    [SerializeField] AudioClip spellA3;
    [SerializeField] AudioClip spellA4;
    [SerializeField] AudioClip spellA5;
    public int spell;
    /*
    0 = blast
    1 = fire 
    2 = ice
    */
    public int spell1;
     public int spell2;
    /*
    0 = tripple blast
    1 = snow
    2 = flamethrower
    */
        [SerializeField] GameObject blast;
        [SerializeField] GameObject flame;
        [SerializeField] GameObject ice;
        [SerializeField] GameObject trippleBlast;
        [SerializeField] GameObject snow;
        [SerializeField] GameObject flamethrower;
        [SerializeField] GameObject shield;
        int blastCoolDown = 35;
        int flameCooldown = 48;
        int iceCooldown = 32;
        int trippleBlastCooldown = 150;
        int snowCooldown = 300;
        int flamethrowerCooldown = 200;
        int shieldCooldown = 300;
        int fTick;
        int fTimer;
        int fTimerStan = 3;
        
    public int spellCoolDown = 0;
    public int spell1CoolDown = 0;
    public int spell2CoolDown = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        spell = menuScript.spellSelected;
        spell1 = menuScript.spell1Selected;
        spell2 = menuScript.spell2Selected;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        coolDownUpdate();
        if(fTimer > 0)
        {
            fTimer--;
        }else
        {
            if(fTick > 0)
            {
                fTimer = fTimerStan;
                GameObject lastF = Instantiate(flamethrower,wand.transform.position,quaternion.identity);
                lastF.SendMessage("rotate",UnityEngine.Random.Range(-7,8));
                if(fTick % 4 == 0){
                    sound.PlayOneShot(spellA4);
                }
                else {
                    if(fTick % 3 == 0 ){
                    sound.PlayOneShot(spellA4);
                }
                }
                fTick --;
            }
        }
    }

    void coolDownUpdate()
    {
        if(spellCoolDown == 0)
        {
            castCheck();
        }
        else
        {
            spellCoolDown -= 1;
        }
        if(spell1CoolDown == 0)
        {
            castCheck1();
        }
        else
        {
            spell1CoolDown -= 1;
        }
        if(spell2CoolDown == 0)
        {
            castCheck2();
        }
        else
        {
            spell2CoolDown -= 1;
        }
    }
    void castCheck()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            
            if(spell == 0)
            {
                sound.PlayOneShot(spellA1);
                spellCoolDown = blastCoolDown;
                Instantiate(blast,wand.transform.position,Quaternion.identity);
            }
            if(spell == 1)
            {
                sound.PlayOneShot(spellA4);
                spellCoolDown = flameCooldown;
                Instantiate(flame,wand.transform.position,Quaternion.identity);
            }
            if(spell == 2)
            {
                sound.PlayOneShot(spellA3);
                spellCoolDown = iceCooldown;
                Instantiate(ice,wand.transform.position,Quaternion.identity);
            }
        }
    }
    void castCheck1()
    {
        if(Input.GetKey(KeyCode.E))
        {
            
            if(spell1 == 0)
            {
                sound.PlayOneShot(spellA1);
                GameObject temp;
                spell1CoolDown = trippleBlastCooldown;
                temp = Instantiate(trippleBlast,transform.position,quaternion.identity);
                temp.SendMessage("rotate",8);
                Instantiate(trippleBlast,transform.position,quaternion.identity);
                temp = Instantiate(trippleBlast,transform.position,quaternion.identity);
                temp.SendMessage("rotate",-8);
            }
            
            if(spell1 == 1)
            {
                sound.PlayOneShot(spellA2);
                spell1CoolDown = snowCooldown;
                Instantiate(snow,wand.transform.position,quaternion.identity);
            }
            if(spell1 == 2)
            {
                
                spell1CoolDown = flamethrowerCooldown;
                fTick = 9;
                fTimer = fTimerStan;
            }
            if(spell1 == 3)
            {
                sound.PlayOneShot(spellA5);
                spell1CoolDown = shieldCooldown;
                Instantiate(shield,transform);
            }
        }
    }

    void castCheck2()
    {
        
        if(Input.GetKey(KeyCode.Q))
        {
            
            if(spell2 == 0)
            {
                sound.PlayOneShot(spellA1);
                GameObject temp;
                spell2CoolDown = trippleBlastCooldown;
                temp =Instantiate(trippleBlast,wand.transform.position,quaternion.identity);
                temp.SendMessage("rotate",8);
                Instantiate(trippleBlast,wand.transform.position,quaternion.identity);
                temp = Instantiate(trippleBlast,wand.transform.position,quaternion.identity);
                temp.SendMessage("rotate",-8);
            }
            
            if(spell2 == 1)
            {
                sound.PlayOneShot(spellA2);
                spell2CoolDown = snowCooldown;
                Instantiate(snow,wand.transform.position,quaternion.identity);
            }
            if(spell2 == 2)
            {
                spell2CoolDown = flamethrowerCooldown;
                fTick = 9;
                fTimer = fTimerStan;
            }
            if(spell2 == 3)
            {
                sound.PlayOneShot(spellA5);
                spell2CoolDown = shieldCooldown;
                Instantiate(shield,transform);
            }
        }
    }
}
