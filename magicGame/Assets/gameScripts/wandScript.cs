using UnityEngine;

public class wandScript : MonoBehaviour
{
    [SerializeField] float orbitDis;
    [SerializeField] Transform pT;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pT = GameObject.Find("player").GetComponent<Transform>();
        orbitDis = handScript.orbitDis + 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = pT.rotation;
        
            transform.position = pT.position;
        Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
            transform.position = new Vector3(transform.position.x + transform.up.x * orbitDis, transform.position.y + transform.up.y * orbitDis, transform.position.z);
        
        
            
            
    }
}
