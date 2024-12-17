using UnityEngine;

public class playerSoundScript : MonoBehaviour
{
    [SerializeField] AudioSource walkS;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        walkS.mute = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerScript.isWalking > 0){
            walkS.mute = false;
        }else{
            walkS.mute = true;
        }
    }
    
}
