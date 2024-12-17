using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class startScript : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startBClick(){
        SceneManager.LoadScene("game");
    }
    public void spellBClick(){
        SceneManager.LoadScene("spellSelect");
    }
}
