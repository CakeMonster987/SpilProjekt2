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
    public bool getBlomst = false;
    public Transform n�gleSpawn;
    public bool wizHarBlomst = false;
    public GameObject minN�gle;

    public GameObject dialogueButtonPrompt;
    public GameObject dialogueObject;

    public Animator StenAni;
    public Animator KnapAni;
    public bool HarGem;
    public GameObject GemOutline;
    public GameObject GemSat;
    public bool GemDone;
    public GameObject TeleportEffect;
    public GameObject TeleportTrigger;

    public Player PlayerMov;

    private void Start()
    {
        GemOutline.SetActive(false);
    }

    void Update()
    {

        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward*3, Color.red);
        
        if (Physics.Raycast(transform.position, transform.forward, out hit, 3) && hit.collider.gameObject.CompareTag("LockedDoor"))
        {
            Debug.Log("DoorHit");
            //sDoorOpen.enabled = true;
            if (Input.GetKeyDown(KeyCode.E) && getKey == true)
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
            //DoorOpen.enabled = false;
        }

        if (Physics.Raycast(transform.position, transform.forward, out hit, 3) && hit.collider.gameObject.CompareTag("Blomst"))
        {
            Debug.Log("Blomst hit");

            if (Input.GetKeyDown(KeyCode.E))
            {
                getBlomst = true;
                Destroy(hit.collider.gameObject);
            }
        }
        if (Physics.Raycast(transform.position, transform.forward, out hit, 3) && hit.collider.gameObject.CompareTag("K�lling") && getBlomst == true)
        {
            Debug.Log("K�lling hit");

            if (Input.GetKeyDown(KeyCode.E) && !wizHarBlomst)
            {
                wizHarBlomst = true;
                Instantiate(minN�gle, n�gleSpawn.transform.position, Quaternion.identity);
            }
        }
        if (Physics.Raycast(transform.position, transform.forward, out hit, 3) && hit.collider.gameObject.CompareTag("Key") && wizHarBlomst == true)
        {
            //keyPickup.enabled = true;
            Debug.Log("Key hit");
            if (Input.GetKeyDown(KeyCode.E))
            {
                getKey = true;
                Destroy(hit.collider.gameObject);
            }
        }
        else
        {
            //keyPickup.enabled = false;
        }

 
        float maxDistanceFromCharacter = 5f;

        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistanceFromCharacter) && hit.collider.gameObject.CompareTag("K�lling") && !getBlomst)
        {
            /*
            if (dialogueObject.activeSelf == false)
            {
                dialogueButtonPrompt.SetActive(true);
            }
            else
            {
                dialogueButtonPrompt.SetActive(false);
            }
            */

            //Debug.Log("looking at character and is in range for dialogue");
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Debug.Log("start");
                dialogueObject.SetActive(true);
                PlayerMov.enabled = false;
            }
        }/*
        else
        {
            dialogueButtonPrompt.SetActive(false);
        }*/

        if (Physics.Raycast(transform.position, transform.forward, out hit, 3) && hit.collider.gameObject.CompareTag("Knap"))
        {
            Debug.Log("Knap hit");

            if (Input.GetKeyDown(KeyCode.E))
            {
                KnapAni.SetBool("KnapTrykket", true);
                StenAni.SetBool("RulSten", true);
            }
        }
        if (Physics.Raycast(transform.position, transform.forward, out hit, 3) && hit.collider.gameObject.CompareTag("Gem"))
        {
            Debug.Log("Gem hit");

            if (Input.GetKeyDown(KeyCode.E))
            {
                HarGem = true;
                Destroy(hit.collider.gameObject);
                GemOutline.SetActive(true);
            }
        }
        if (Physics.Raycast(transform.position, transform.forward, out hit, 3) && hit.collider.gameObject.CompareTag("GemOutline") && HarGem == true)
        {
            Debug.Log("Gem Outline hit");

            if (Input.GetKeyDown(KeyCode.E))
            {
                GemOutline.SetActive(false);
                GemSat.SetActive(true);
                GemDone = true;
                TeleportEffect.SetActive(true);
            }
        }

        if (GemDone == true)
        {
            TeleportTrigger.SetActive(true);
        }
    }

    IEnumerator removeLockedText()
    {
        yield return new WaitForSeconds(0.5f);
        locked.enabled = false;
    }

}
