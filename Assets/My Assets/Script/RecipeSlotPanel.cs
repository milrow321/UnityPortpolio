using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeSlotPanel : MonoBehaviour
{
   

    public RecipeSlot[] recipeSlots;
    public RecipeComplete recipeComplete;

    private void Awake()
    {

        recipeSlots = GetComponentsInChildren<RecipeSlot>();
        recipeComplete = GetComponent<RecipeComplete>();
    }


}
