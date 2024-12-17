using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGenScript : MonoBehaviour
{
    [SerializeField] GameObject wallBox;
    [SerializeField] GameObject hpBox;
    [SerializeField] GameObject enemy1;
    [SerializeField] GameObject lanturn;
    GameObject lastMade;
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.name == "Room1(Clone)" ||gameObject.name == "Room5(Clone)" )
        {
           lastMade = Instantiate(wallBox, (new Vector3(transform.position.x - 6.5f + Random.Range(-0.2f, 0.2f), transform.position.y - 4 + Random.Range(-0.2f, 0.2f),transform.position.z)),Quaternion.identity);
           Instantiate(lanturn, lastMade.transform.position, Quaternion.identity);
            Instantiate(wallBox, (new Vector3(transform.position.x + 5.7f + Random.Range(-0.2f, 0.2f), transform.position.y + 3.3f + Random.Range(-0.2f, 0.2f),transform.position.z)),Quaternion.identity);
            Instantiate(enemy1, (new Vector3(transform.position.x + 4.7f + Random.Range(-0.2f, 0.2f), transform.position.y - 1 + Random.Range(-0.2f, 0.2f),transform.position.z)),Quaternion.identity);
            Instantiate(enemy1, (new Vector3(transform.position.x + 2 + Random.Range(-0.2f, 0.2f), transform.position.y - 4.4f + Random.Range(-0.2f, 0.2f),transform.position.z)),Quaternion.identity);
        }
        if(gameObject.name == "Room2(Clone)")
        {
           lastMade = Instantiate(wallBox, (new Vector3(transform.position.x - 6.4f + Random.Range(-0.2f, 0.2f), transform.position.y -2.8f + Random.Range(-0.2f, 0.2f),transform.position.z)),Quaternion.identity);
           Instantiate(lanturn, lastMade.transform.position, Quaternion.identity);
            Instantiate(wallBox, (new Vector3(transform.position.x + 4.86f + Random.Range(-0.2f, 0.2f), transform.position.y - 2.16f + Random.Range(-0.2f, 0.2f),transform.position.z)),Quaternion.identity);
            Instantiate(enemy1, (new Vector3(transform.position.x - 6.95f + Random.Range(-0.2f, 0.2f), transform.position.y + 0.5f + Random.Range(-0.2f, 0.2f),transform.position.z)),Quaternion.identity);
            Instantiate(enemy1, (new Vector3(transform.position.x + 6.9f + Random.Range(-0.2f, 0.2f), transform.position.y + 0.3f + Random.Range(-0.2f, 0.2f),transform.position.z)),Quaternion.identity);
            Instantiate(hpBox, new Vector3(transform.position.x - 7.4f, transform.position.y + 5, transform.position.z) , Quaternion.identity);
        }
        if(gameObject.name == "Room3(Clone)")
        {
            Instantiate(wallBox, (new Vector3(transform.position.x - 3.5f + Random.Range(-0.2f, 0.2f), transform.position.y + 4.1f + Random.Range(-0.2f, 0.2f),transform.position.z)),Quaternion.identity);
            lastMade = Instantiate(wallBox, (new Vector3(transform.position.x - 3.5f + Random.Range(-0.2f, 0.2f), transform.position.y - 3.7f + Random.Range(-0.2f, 0.2f),transform.position.z)),Quaternion.identity);
            Instantiate(lanturn, lastMade.transform.position, Quaternion.identity);
            Instantiate(wallBox, (new Vector3(transform.position.x + 3.6f + Random.Range(-0.2f, 0.2f), transform.position.y + 0f + Random.Range(-0.2f, 0.2f),transform.position.z)),Quaternion.identity);
            Instantiate(enemy1, (new Vector3(transform.position.x - 0f + Random.Range(-0.2f, 0.2f), transform.position.y + 4.5f + Random.Range(-0.2f, 0.2f),transform.position.z)),Quaternion.identity);
            Instantiate(enemy1, (new Vector3(transform.position.x + 0f + Random.Range(-0.2f, 0.2f), transform.position.y - 3.9f + Random.Range(-0.2f, 0.2f),transform.position.z)),Quaternion.identity);
        }
        if(gameObject.name == "Room4(Clone)")
        {
            Instantiate(wallBox, (new Vector3(transform.position.x - 0f , transform.position.y + 2.65f ,transform.position.z)),Quaternion.identity);
           lastMade =  Instantiate(wallBox, (new Vector3(transform.position.x - 0f , transform.position.y - 0f ,transform.position.z)),Quaternion.identity);
           Instantiate(lanturn, lastMade.transform.position, Quaternion.identity);
            Instantiate(wallBox, (new Vector3(transform.position.x + 0f , transform.position.y - 2.65f ,transform.position.z)),Quaternion.identity);
            Instantiate(enemy1, (new Vector3(transform.position.x - 0f + Random.Range(-0.2f, 0.2f), transform.position.y + 5.5f + Random.Range(-0.2f, 0.2f),transform.position.z)),Quaternion.identity);
            Instantiate(enemy1, (new Vector3(transform.position.x + 0f + Random.Range(-0.2f, 0.2f), transform.position.y - 5.3f + Random.Range(-0.2f, 0.2f),transform.position.z)),Quaternion.identity);
             Instantiate(hpBox, new Vector3(transform.position.x + 8.7f, transform.position.y + -5.8f, transform.position.z) , Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
