using UnityEngine;

public class handEScript : MonoBehaviour
{
    [SerializeField] public static float orbitDis = 0.75f;
    [SerializeField] Transform eT;
    [SerializeField] Transform pT;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        eT = transform.parent;
    pT = GameObject.Find("player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
            transform.position = eT.position;
        Vector2 direction = new Vector2(pT.position.x - transform.position.x, pT.position.y - transform.position.y);
            transform.up = direction;
            transform.Rotate(0,0,transform.rotation.z + 90);
            transform.position = new Vector3(transform.position.x + transform.right.x * orbitDis, transform.position.y + transform.right.y * orbitDis, transform.position.z);
       
      
        
    }
}
