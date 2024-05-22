using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Note", menuName = "NoteCreater", order = 0)]
public class NoteCreater : ScriptableObject
{
    public string NameOfPotion;
    public Ingridients[] NamesOfIngrdients;
}
