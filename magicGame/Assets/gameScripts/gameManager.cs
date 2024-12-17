using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class gameManager : MonoBehaviour
{
    public static bool clear = false;
    public static bool pIn = false; 
     public static int score;
    [SerializeField] public static int enemysLeft;
     [SerializeField] TMP_Text tmp;
     [SerializeField] TMP_Text stmp;
    [SerializeField] GameObject lastmade;
    [SerializeField] GameObject lastmade2;
    [SerializeField] GameObject mainRoom1;
    [SerializeField] GameObject hallway1;
    [SerializeField] GameObject room1;
    [SerializeField] GameObject room2;
    [SerializeField] GameObject room3;
    [SerializeField] GameObject room4;
    [SerializeField] GameObject room5;
    
    // Start is called before the first frame update
    void Start()
    {
       if(score == 0 && clear == false)
       {
        score = -1;
        clear = true;
       }
        score++;
        if(score > PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", score);
        }
        if(true)
        {
           lastmade = Instantiate(mainRoom1,new Vector3(0,0,0), Quaternion.identity);
           lastmade2 = Instantiate(hallway1,new Vector3(lastmade.transform.position.x - 15.7f,0,0), Quaternion.identity);
            lastmade = Instantiate(hallway1,new Vector3(lastmade.transform.position.x + 15.8f,0,0), Quaternion.identity);
            
            if(Random.Range(0,2) == 0)
            {
                lastmade = Instantiate(room1,new Vector3(lastmade.transform.position.x + 15.7f,0,0), Quaternion.identity);
                lastmade = Instantiate(hallway1,new Vector3(lastmade.transform.position.x - 0.2f,lastmade.transform.position.y + 13.1f,0), Quaternion.identity);
                lastmade.transform.Rotate(0,0,90);
                lastmade = Instantiate(room2,new Vector3(lastmade.transform.position.x - 0.65f,lastmade.transform.position.y + 11.5f,0), Quaternion.identity);
                lastmade.transform.Rotate(0,0,180);
                enemysLeft +=4;
            }else{
                lastmade = Instantiate(room3,new Vector3(lastmade.transform.position.x + 15.7f,0,0), Quaternion.identity);
                lastmade = Instantiate(hallway1,new Vector3(lastmade.transform.position.x + 15.8f,0,0), Quaternion.identity);
                lastmade = Instantiate(room4,new Vector3(lastmade.transform.position.x + 15.7f,0,0), Quaternion.identity);
                enemysLeft +=4;
            }

            if(Random.Range(0,2) == 0)
            {
                lastmade2 = Instantiate(room5,new Vector3(lastmade2.transform.position.x - 15.7f,0,0), Quaternion.identity);
                lastmade2 = Instantiate(hallway1,new Vector3(lastmade2.transform.position.x - 0.7f,lastmade2.transform.position.y + 13.1f,0), Quaternion.identity);
                lastmade2.transform.Rotate(0,0,90);
                lastmade2 = Instantiate(room2,new Vector3(lastmade2.transform.position.x - 0.65f,lastmade2.transform.position.y + 11.5f,0), Quaternion.identity);
                lastmade2.transform.Rotate(0,0,180);
                enemysLeft +=4;
                
            }else{
                lastmade2 = Instantiate(room3,new Vector3(lastmade2.transform.position.x - 15.7f,0,0), Quaternion.identity);
                lastmade2 = Instantiate(hallway1,new Vector3(lastmade2.transform.position.x - 15.7f,0,0), Quaternion.identity);
                lastmade2 = Instantiate(room4,new Vector3(lastmade2.transform.position.x - 16.6f,0.4f,0), Quaternion.identity);
                lastmade2.transform.Rotate(0,0,180);
                enemysLeft +=4;
            }
        }
        else
        {

        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        stmp.text = "Score: " + score.ToString();
        tmp.text = "Enemies: " + enemysLeft.ToString();
        if(enemysLeft == 0 && clear)
        {
            SceneManager.LoadScene("game");
        }
    }
    void pSet()
    {
        pIn = true;
    }
}
