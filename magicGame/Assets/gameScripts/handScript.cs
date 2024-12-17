using Unity.VisualScripting;
using UnityEngine;

public class handScript : MonoBehaviour
{
    [SerializeField] public static float orbitDis = 0.75f;
    [SerializeField] Transform pT;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pT = GameObject.Find("player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        
            transform.position = pT.position;
        Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
            transform.up = direction;
            transform.position = new Vector3(transform.position.x + transform.up.x * orbitDis, transform.position.y + transform.up.y * orbitDis, transform.position.z);
       
      
        
    }
}
