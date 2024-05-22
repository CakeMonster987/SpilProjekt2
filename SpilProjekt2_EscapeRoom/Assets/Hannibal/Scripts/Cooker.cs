using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooker : MonoBehaviour
{
    public GameObject SkullTonic;
    public GameObject LoveEssence;
    public GameObject LiquidGold;
    private int cookingCondition;
    public List<Ingridients> IngridientsNeeded = new();
    public List<Ingridients> currentIngridient = new();
    public GameObject spawnPoint;
    public NoteCreater CurrentNote;
    private NoteCreater noteLastFrame;
    private Ingridients addIngridients;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateIngridients();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentIngridient.Count == IngridientsNeeded.Count)
        {
            
        }
    }

    public void UpdateIngridients()
    {
        IngridientsNeeded.Clear();
        for (int i = 0; i < CurrentNote.NamesOfIngrdients.Length; i++)
        {
            IngridientsNeeded.Add(CurrentNote.NamesOfIngrdients[i]);
        }
    }

    private void Reset()
    {
        currentIngridient.Clear();
    }

    public void CheckIfIngridientIsPresent()
    {
        for (int i = 0; i < CurrentNote.NamesOfIngrdients.Length; i++)
        {
            if (currentIngridient[i] = CurrentNote.NamesOfIngrdients[i])
            {
                cookingCondition++;
            }
        }
        
    }

    public void CheckPot()
    {
        if (cookingCondition == CurrentNote.NamesOfIngrdients.Length)
        {
            
        }
    }
}


