using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpillerRaycast : MonoBehaviour
{

    public GameObject TP1;
    public GameObject TP2;

    private void Start()
    {
    }

    void Update()
    {

        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * 3, Color.red);

        if (Physics.Raycast(transform.position, transform.forward, out hit, 3) && hit.collider.gameObject.CompareTag("TP1"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("TP1 Hit");
                //this.transform.position = new Vector3(TP1.transform.position.x, TP1.transform.position.y, TP1.transform.position.z);
                this.transform.position = TP1.transform.position;
            }
        }



    }
}
