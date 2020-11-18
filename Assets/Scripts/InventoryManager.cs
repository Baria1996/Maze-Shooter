using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour, IGameManager {
    public ManagerStatus status { get; private set; }

    private Dictionary<string, int> _items;

    public void Startup() {
        _items = new Dictionary<string, int>();
        status = ManagerStatus.Started;
    }

    public void DisplayItems()
    {
        string itemPrint = "Items in the inv: ";
        foreach (KeyValuePair<string, int> item in _items)
            itemPrint += " key: " + item.Key + " Val: " + item.Value;
        Debug.Log(itemPrint);
    }

    public void AddItem(string name)
    {
        if (_items.ContainsKey(name))
            _items[name] += 1;
        else
            _items[name] = 1;
        //DisplayItems();
    }

    public List<string> GetItemList()
    {
        List<string> list = new List<string>();
        return list;
    }

    public int GetItemCount(string name)
    {
        if (_items.ContainsKey(name))
            return _items[name];
        return 0;
    }
}
