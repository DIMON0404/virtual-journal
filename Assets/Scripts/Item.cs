using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public virtual ItemSO ItemSO { get; set; }
    public RectTransform Rect;
    public Action<ItemSO> OnClick;
    
    public void Click()
    {
        OnClick.Invoke(ItemSO);
    }
}
