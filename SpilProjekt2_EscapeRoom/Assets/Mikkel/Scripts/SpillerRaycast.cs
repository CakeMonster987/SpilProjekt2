using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using StarterAssets;

public class SpillerRaycast : MonoBehaviour
{

    public GameObject TP1;
    public GameObject TP2;
    private CharacterController _controller;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void LateUpdate()
    {

        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * 3, Color.blue);

        if (Physics.Raycast(transform.position, transform.forward, out hit, 3) && hit.collider.gameObject.CompareTag("TP1"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("TP1 Hit");
                //this.transform.position = new Vector3(TP1.transform.position.x, TP1.transform.position.y, TP1.transform.position.z);
                _controller.enabled = false;
                transform.position = TP2.transform.position;
                _controller.enabled = true;
            }
        }

        if (Physics.Raycast(transform.position, transform.forward, out hit, 3) && hit.collider.gameObject.CompareTag("TP2"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("TP1 Hit");
                //this.transform.position = new Vector3(TP1.transform.position.x, TP1.transform.position.y, TP1.transform.position.z);
                _controller.enabled = false;
                transform.position = TP1.transform.position;
                _controller.enabled = true;
            }
        }
    }
}
