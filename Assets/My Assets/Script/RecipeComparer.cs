using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RecipeComparer : IEqualityComparer<Item>
{
    public bool Equals(Item a, Item b)
    {
        if (Object.ReferenceEquals(a, b)) return true;

        if (a == null || a == null) return false;

        return a.itemID == b.itemID;
    }

    

    public int GetHashCode(Item tem)
    {
        if (tem == null) return 0;
        return tem.itemID.GetHashCode();
    }
}
