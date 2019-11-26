using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Content : MonoBehaviour
{
    public RectTransform Rect;
    public Item ItemPrefab;
    public List<ItemSO> Items;
    public float ItemHeight;
    public Action<ItemSO> OnClick;
    private List<Item> InstantiatedItems;

    public void Init(Action<ItemSO> onClick)
    {
        OnClick = onClick;
        InstantiatedItems = new List<Item>();
    }

    public void SetItems(List<ItemSO> Items)
    {
        if (InstantiatedItems != null && InstantiatedItems.Count > 0)
        {
            foreach (Item item in InstantiatedItems)
            {
                Destroy(item.gameObject);
            }
        }

        InstantiatedItems = new List<Item>();
        int itemCount = 0;
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i] == null)
                continue;

            var localPosition = ItemPrefab.Rect.anchoredPosition;
            Item item = Instantiate(
                ItemPrefab,
                Rect.transform);
            item.Rect.anchoredPosition = new Vector3(localPosition.x, -ItemHeight * (itemCount));
            item.ItemSO = Items[i];
            item.OnClick = OnClick;
            InstantiatedItems.Add(item);
            itemCount++;
        }

        Vector2 sizeDelta = Rect.sizeDelta;
        sizeDelta.y = ItemHeight * itemCount;
        Rect.sizeDelta = sizeDelta;
    }
}
