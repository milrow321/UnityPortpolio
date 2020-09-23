using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitchen : MonoBehaviour
{



    public List<ItemSlot> ingredients;


    public void AddIngredient()
    {
        ingredients.Add(DragSlot.instance.dragSlot);


    }

    public void Cook()
    {
        for (int i = 0; i < ingredients.Count; i++)
        {
            
        }
    }

    public void Erase()
    {
    }
}
