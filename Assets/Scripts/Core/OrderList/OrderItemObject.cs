using System;
using UnityEngine;

namespace Core.OrderList
{
    public class OrderItemObject<T> : MonoBehaviour where T : OrderItem
    {
        public virtual T OrderItem { get; set; }
        public RectTransform Rect;
        public Action<OrderItemObject<T>> OnRemove;

        public void Remove()
        {
            OnRemove.Invoke(this);
        }
    }
}