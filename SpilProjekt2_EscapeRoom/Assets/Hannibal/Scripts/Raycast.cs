using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Raycast : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI DoorOpen;
    [SerializeField] private TextMeshProUGUI keyPickup;
    [SerializeField] private TextMeshProUGUI locked;
    public bool OpenDoor = false;
    public bool getKey = false;
    private void Start()
    {
        
    }

    void Update()
    {

        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward*3, Color.red);

        if (Physics.Raycast(transform.position, transform.forward, out hit, 3) && hit.collider.gameObject.CompareTag("LockedDoor"))
        {
            Debug.Log("DoorHit");
            DoorOpen.enabled = true;
            if (Input.GetKeyDown(KeyCode.E)/* && getKey == true*/)
            {
                door hitDoor = hit.collider.gameObject.GetComponent<door>();
                hitDoor.toggleDoor();

            }

            if (Input.GetKeyDown(KeyCode.E) && getKey == false)
            {
                locked.enabled = true;
                StartCoroutine(removeLockedText());
            }
        }
        else
        {
            DoorOpen.enabled = false;
        }

        if (Physics.Raycast(transform.position, transform.forward, out hit, 3) && hit.collider.gameObject.CompareTag("Key"))
        {
            keyPickup.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                getKey = true;
                Destroy(hit.collider.gameObject);
                
            }
        }
        else
        {
            keyPickup.enabled = false;
        }

    }
    
    IEnumerator removeLockedText()
    {
        yield return new WaitForSeconds(0.5f);
        locked.enabled = false;
    }

}
