using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemsObserver : MonoBehaviour
{
    private List<ItemTemplate> _items;

    public IEnumerable<ItemTemplate> GetSelected()
    {
        FindItems();

        return _items.Where(element => element.IsSelected == true);
    }

    public void SetItemsStatus(bool status)
    {
        FindItems();

        foreach (var item in _items)
        {
            item.Select(status);
        }
    }

    private void Start()
    {
        FindItems();
    }

    private void FindItems()
    {
        _items = GetComponentsInChildren<ItemTemplate>().ToList();
    }
}
