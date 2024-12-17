using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] TMP_Dropdown b;
    [SerializeField] TMP_Dropdown s1;
    [SerializeField] TMP_Dropdown s2;

    // Start is called before the first frame update
    void Start()
    {
       
        b.SetValueWithoutNotify(PlayerPrefs.GetInt("bSpell"));
        s1.SetValueWithoutNotify(PlayerPrefs.GetInt("spell1"));
        s2.SetValueWithoutNotify(PlayerPrefs.GetInt("spell2"));
         rD();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        
    }

    
    public void rD()
    {
        if(s1.value == s2.value)
        {
            if(s1.value == 0)
            {
                 s2.SetValueWithoutNotify(1);
                 menuScript.spell2Choose(1);
            }
            else
            {
                s2.SetValueWithoutNotify(0);
                menuScript.spell2Choose(0);
            }
           
        }
        
    }

    public void backBClicked(){
        SceneManager.LoadScene("start");
    }
}
