using UnityEngine;
using System.Collections;

public class Item
{
    public int Id { get; private set; }
    public Sprite Icon { get; private set; }
    public Item(int id, Sprite icon)
    {
        this.Id = id;
        this.Icon = icon;
      
    }
}

