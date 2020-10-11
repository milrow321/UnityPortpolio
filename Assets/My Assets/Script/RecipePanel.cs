using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipePanel : MonoBehaviour
{
    public Kitchen kitchen;

    public RecipeSlotPanel[] recipeSlotPanel;

    

    private void Awake()
    {

        recipeSlotPanel = GetComponentsInChildren<RecipeSlotPanel>();

        
    }

    private void Update()
    {
        SetRecipe();
        
    }
    private void SetRecipe()
    {
        //for (int i = 0; i < kitchen.recipe.Length; i++)
        //{
        //    if (kitchen.recipe[i].Count != 0)
        //    {
        //        int res;
        //        Item _item;
        //        kitchen.recipeBook.TryGetValue(kitchen.recipe[i], out res);
        //        DatabaseManager.instance.foodItemDictionary.TryGetValue(res, out _item);
        //        recipeSlotPanel[i].recipeSlots[5].SetItemImage(_item.itemImage);
        //    }
        //    else continue;
        //}


        for (int i = 0; i < kitchen.recipe.Length; i++)
        {

            if (kitchen.recipe[i] == null) continue;
               
            
            for (int j = 0; j < kitchen.recipe[i].Count; j++)
            {
                
                if (kitchen.recipe[i][j] == null) continue;

               

                Color color = recipeSlotPanel[i].recipeSlots[j].icon.color;
                color.a = 1f;
                recipeSlotPanel[i].recipeSlots[j].icon.color = color;
                //recipeSlotPanel[i].recipeSlots[j].icon.sprite = kitchen.recipe[i][j].itemImage;
                recipeSlotPanel[i].recipeSlots[j].SetItemImage(kitchen.recipe[i][j].itemImage);   

            }
            

        }
    }
}
