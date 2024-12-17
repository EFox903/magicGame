using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class menuScript : MonoBehaviour
{
    public static int spellSelected = 0;
    public static int spell1Selected = 0;
    public static int spell2Selected = 0;
    [SerializeField] TMP_Text tmp;
   
    /*
    0 = blast
    1 = fire 
    2 = ice
    */
    void Start()
    {
        if(PlayerPrefs.HasKey("gameLanuched") == false)
        {
            PlayerPrefs.SetInt("gameLanuched",1);
            PlayerPrefs.SetInt("highscore",0);
            PlayerPrefs.SetInt("bSpell",0);
            PlayerPrefs.SetInt("spell1",0);
            PlayerPrefs.SetInt("spell2",1);
            
        }
        spellSelected = PlayerPrefs.GetInt("bSpell");
            spell1Selected = PlayerPrefs.GetInt("spell1");
            spell2Selected = PlayerPrefs.GetInt("spell2");
            if(gameObject.name != "MenuScriptHolder"){tmp.text = PlayerPrefs.GetInt("highscore").ToString();}
            
        
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space)){
            PlayerPrefs.DeleteAll();
        }
    }

    public void spellChoose(int sC)
    {
        PlayerPrefs.SetInt("bSpell",sC);
        spellSelected = sC;
    }
public static void spell1Choose(int sC)
    {
        spell1Selected = sC;
        PlayerPrefs.SetInt("spell1",sC);
    }
    public static void spell2Choose(int sC)
    {
        spell2Selected = sC;
        PlayerPrefs.SetInt("spell2",sC);
    }
    public void startBClicked()
    {
        SceneManager.LoadScene("game");
        
    }
}
