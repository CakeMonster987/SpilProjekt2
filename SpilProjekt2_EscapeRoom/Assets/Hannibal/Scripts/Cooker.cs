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
    //public List<Ingridients> IngridientsNeeded = new();
    public List<Ingridients> currentIngridient = new();
    public GameObject spawnPoint;
    public NoteCreater CurrentNote;
    private NoteCreater noteLastFrame;
    public NoteCreater recipe1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    


    public void AddIngredientToCooker(Ingridients ingredient)
    {
        currentIngridient.Add((ingredient));
        bool ingridentsMatch = true;
        foreach (var ingridient in recipe1.NamesOfIngrdients)
        {
            if (!currentIngridient.Contains(ingridient))
            {
                
                ingridentsMatch = false;
            }
                
        }

        if (ingridentsMatch)
        {
            SkullTonic.SetActive(true);
        }
    }

   /* public void UpdateIngridients()
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
    }*/
}


