using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopConteiner : MonoBehaviour
{
    public void ShowItems(List<FigureModel> items, ItemView template)
    {
        for (int i = 0; i < items.Count; i++)
        {
            ItemView item = Instantiate(template, transform);
            item.Render(items[i]);
        }
    }
}
