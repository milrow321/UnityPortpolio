using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipes : MonoBehaviour
{
    


    public Dictionary<List<Item>, string> recipeBook;

    List<Item> recipe;

    // Start is called before the first frame update
    private void Awake()
    {
        recipe.Add(new Item(00000,"apple", "사과", "잘익은 빨간 사과", Item.ItemType.INGREDIENT));
        recipe.Add(new Item(00100,"water", "물", "모든 음료의 기본이 되는 맑은 물", Item.ItemType.INGREDIENT));
        recipeBook.Add(recipe, "사과주스");
        recipe.Clear();
    }

    

}
