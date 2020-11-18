using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicUI : MonoBehaviour {

    private void OnGUI()
    {
        int posX = Screen.width - 200;
        int posY = 410;
        int width = 175;
        int height = 25;
        int buffer = 10;

        List<string> itemList = Managers.Inventory.GetItemList();

        Managers.Inventory.DisplayItems();

        if (itemList.Count == 0)
        {
            GUI.Box(new Rect(posX, posY, width, height), "No Items");
        }

        foreach (string item in itemList) {
            int count = Managers.Inventory.GetItemCount(item);
            //Texture2D image = Resources.Load<Texture2D>("Icons/" + item); 
            GUI.Box(new Rect(posX, posY, width, height), new GUIContent("(" + count + ")"));
            posX += width + buffer;
        }
    }
}
