using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Scene_Teleportation_Kit.Scripts.player;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [System.Serializable]
    public class DialogueSegment
    {
        public string SubjectText;

        [TextArea]
        public string DialogueToPrint;
        public bool skippable;

        [Range(1f, 25f)]
        public float LettersPerSecond;
    }

    [SerializeField] private DialogueSegment[] DialogueSegments;
    [Space]
    [SerializeField] private TMP_Text SubjectText;
    [SerializeField] private TMP_Text BodyText;

    private int DialogueIndex;
    private bool PlayingDialogue;
    private bool skip;

    public CharacterController PlayerMov;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        StartCoroutine(PlayDialogue(DialogueSegments[DialogueIndex]));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))
        {
            if (DialogueIndex >= DialogueSegments.Length)
            {
                Debug.Log("can move again");
                DialogueIndex = 0;
                gameObject.SetActive(false);
                PlayerMov.enabled = true;
                return;
            }

            if (!PlayingDialogue)
            {
                StartCoroutine(PlayDialogue(DialogueSegments[DialogueIndex]));
            }
            else
            {
                if (DialogueSegments[DialogueIndex].skippable)
                {
                    skip = true;
                }
            }
        }
    }

    private IEnumerator PlayDialogue(DialogueSegment segment)
    {
        PlayingDialogue = true;

        BodyText.SetText(string.Empty);
        SubjectText.SetText(segment.SubjectText);

        float delay = 1f / segment.LettersPerSecond;
        for (int i = 0; i < segment.DialogueToPrint.Length; i++)
        {
            if (skip)
            {
                BodyText.SetText(segment.DialogueToPrint);
                skip = false;
                break;
            }

            string chunkToAdd = string.Empty;
            chunkToAdd += segment.DialogueToPrint[i];
            if (segment.DialogueToPrint[i] == ' ' && i < segment.DialogueToPrint.Length -1)
            {
                chunkToAdd = segment.DialogueToPrint.Substring(i, 2);
                i++;
            }

            BodyText.text += chunkToAdd;
            yield return new WaitForSeconds(delay);
        }

        PlayingDialogue = false;
        DialogueIndex++;
    }
}
