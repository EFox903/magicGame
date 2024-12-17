using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.Mathematics;

public class playerScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D rB;
    [SerializeField] float speed;
    [SerializeField] float sprintSpeed;
    [SerializeField] float standerdSpeed;
    [SerializeField] static int health;
    [SerializeField] bool slow;
    [SerializeField] int stanama;
    [SerializeField] int maxStanama;
    [SerializeField] int peffect;
    [SerializeField] int effectDur;
    [SerializeField] TMP_Text tmp;
    [SerializeField] TMP_Text sTmp;
    [SerializeField] int tpTimer;
    [SerializeField] GameObject tpEffect;
    [SerializeField] GameObject tpHEffect;
    [SerializeField] GameObject tpHEffectrender;
    bool tpStun;
    public static int isWalking;
    // Start is called before the first frame update
    void Start()
    {
        tpStun = false;
        if(gameManager.pIn == false)
       {
        gameManager.enemysLeft = 0;
        health = 200;
        gameManager.pIn = true;
       }
       else
       {
        pDamage(-50);
       }
        standerdSpeed = speed;
        sprintSpeed = speed + 2;
        stanama = maxStanama;
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        healthCheck();
            effectsCheck();
            lookUpdate();
            moveUpdate();
            teleport();
            if(Input.GetKey(KeyCode.Space) && stanama > 0){
                speed = sprintSpeed;
                stanama--;
            
            }
            else{
                speed = standerdSpeed;
               
            }   
             if(stanama < maxStanama && Input.GetKey(KeyCode.Space) == false)
            {
                stanama++;
            }
            
            int dis = stanama / 5;
            dis = Convert.ToInt32(math.floor(dis));
            sTmp.text = "Stanama: " + dis.ToString();
            
    }

void teleport()
{
if(Input.GetKey(KeyCode.B))
{
    tpStun = false;
    
    if(stanama == maxStanama)
    {
        
        if(tpHEffectrender == null)
        {
            tpHEffectrender = Instantiate(tpHEffect,new Vector3(transform.position.x,transform.position.y, -0.3f), quaternion.identity);
        }
            
        
        
   
    tpTimer++;
    tpStun = true;
    if(tpTimer == 50)
    {
        stanama = 0;
        transform.position = new Vector3(0, 0,0);
        Instantiate(tpEffect,new Vector3(transform.position.x,transform.position.y, -0.3f),Quaternion.identity);
        Destroy(tpHEffectrender);
    }

    }else{
        if(tpHEffectrender != null)
    {
        Destroy(tpHEffectrender);
    }
    }
    
}
else{
        tpTimer = 0;
        tpStun = false;
        if(tpHEffectrender != null)
    {
        Destroy(tpHEffectrender);
    }
        
    }
}
    void lookUpdate()
    {
        Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
            transform.up = direction;
            transform.Rotate(0,0,transform.rotation.z);
    }
    void moveUpdate()
    {
        
        isWalking = 0;
        if(tpStun == false)
        {
             if(Input.GetKey(KeyCode.D))
            {
                if(rB.linearVelocity.x < speed)
                {
                    if(slow){
                        rB.linearVelocity = (new Vector2(speed * 0.5f, rB.linearVelocity.y));
                    }
                     else{
                            rB.linearVelocity = (new Vector2(speed, rB.linearVelocity.y));
                     }
                     isWalking ++;
                }
            }
            
             if(Input.GetKey(KeyCode.A))
             {
                if(rB.linearVelocity.x > -speed){
                    if(slow){
                        rB.linearVelocity = (new Vector2(-speed * 0.5f, rB.linearVelocity.y));
                    }
                     else{
                            rB.linearVelocity = (new Vector2(-speed, rB.linearVelocity.y));
                     }
                 isWalking ++;
                    }
             }
             if(Input.GetKey(KeyCode.W))
             {
                    if(rB.linearVelocity.y < speed)
                    {
                        if(slow){
                        rB.linearVelocity = (new Vector2(rB.linearVelocity.x,speed * 0.5f));
                    }
                     else{
                            rB.linearVelocity = (new Vector2(rB.linearVelocity.x, speed));
                     }
                        
                        isWalking ++;
                    }
             }
             if(Input.GetKey(KeyCode.S))
             {
                    if(rB.linearVelocity.y > -speed)
                    {
                        if(slow){
                        rB.linearVelocity = (new Vector2(rB.linearVelocity.x,-speed * 0.5f));
                    }
                     else{
                            rB.linearVelocity = (new Vector2(rB.linearVelocity.x, -speed));
                     }
                        isWalking ++;
                    }
             }
             if(isWalking > 1)
             {
                rB.linearVelocity = rB.linearVelocity * 0.7071f;
             }
        }
           
    }

    void pDamage(int loss)
    {
        health -= loss;
        if(health > 200)
        {
            health = 200;
        }
    }

    void healthCheck()
    {
        tmp.text = "Health: " + health.ToString();
        if(health <= 0){
            gameManager.pIn = false;
          PlayerPrefs.SetInt("highscore", gameManager.score);
            PlayerPrefs.Save();
            SceneManager.LoadScene("menu");
            Destroy(gameObject);
        }
    }

    void effectsCheck()
    {
       slow = false;
        if(effectDur > 0)
        {
            effectDur --;
            if(peffect != 0)
            {
            if(peffect == 1)
            {
                slow = true;

            }
            }
            
        }
    }

    void setEffect(int effect){
        peffect = effect;
        
    }
    void setEffectDur(int dur){
        effectDur = dur;
    }
}
