using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToNextArea : MonoBehaviour
{

    public GameObject TP1;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)) 
        {
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TP1"))
        {
            print("heyyyyy");
            player.transform.position = new Vector3(TP1.transform.position.x, TP1.transform.position.y, TP1.transform.position.z);
            print("heyyyyyteraygvuhbdsiljncoæka<VSJgrbie ");
        }
    }
}
