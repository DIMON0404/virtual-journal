﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Core.OrderList
{
    [RequireComponent(typeof(ScrollRect))]
    public class OrderList<T1, T2> : MonoBehaviour 
        where T1 : OrderItem, new()
        where T2 : OrderItemObject<T1>, new()
    {
        private ScrollRect ScrollRect;
        private RectTransform Content;

        [SerializeField] protected T2 Prefab;
        [SerializeField] protected RectTransform AdditionalData;
        [SerializeField] private AdditionalDataPosition Position = AdditionalDataPosition.Bottom;
        private List<T1> m_OrderItems;
        protected List<T2> OrderItemObjects;

        public List<T1> OrderItems
        {
            get => m_OrderItems ?? (m_OrderItems = new List<T1>());
            set => m_OrderItems = value;
        }

        protected virtual void Awake()
        {
            ScrollRect = GetComponent<ScrollRect>();
            Content = ScrollRect.content;
            OrderItemObjects = new List<T2>();
        }

        protected virtual void OnEnable()
        {
            UpdateItems();
        }

        public virtual void UpdateItems()
        {
            foreach (OrderItemObject<T1> orderItemObject in OrderItemObjects)
            {
                Destroy(orderItemObject.gameObject);
            }
            
            OrderItemObjects.Clear();

            float totalHeight = 0f;
            if (Position == AdditionalDataPosition.Top)
            {
                LocateAdditionalPanel(ref totalHeight);
            }
            
            foreach (T1 orderItem in OrderItems)
            {
                T2 newItem = Instantiate(Prefab, Content);
                newItem.OrderItem = orderItem;
                InitializeNewItemObject(newItem);
                Vector2 position = newItem.Rect.anchoredPosition;
                position.y = -totalHeight;
                newItem.Rect.anchoredPosition = position;
                totalHeight += newItem.Rect.rect.height;
                OrderItemObjects.Add(newItem);
            }
            
            if (Position == AdditionalDataPosition.Bottom)
            {
                LocateAdditionalPanel(ref totalHeight);
            }
            
            Vector2 sizeDelta = Content.sizeDelta;
            sizeDelta.y = totalHeight;
            Content.sizeDelta = sizeDelta;
        }

        private void LocateAdditionalPanel(ref float totalHeight)
        {
            Vector2 additionalDataAnchoredPosition = AdditionalData.anchoredPosition;
            additionalDataAnchoredPosition.y = -totalHeight;
            AdditionalData.anchoredPosition = additionalDataAnchoredPosition;
            totalHeight += AdditionalData.rect.height;
        }

        public void OnRemoveItem(OrderItemObject<T1> item)
        {
            if (OrderItems.Contains(item.OrderItem))
            {
                OrderItems.Remove(item.OrderItem);
                UpdateItems();
            }
        }

        public void OnAddItem()
        {
            OrderItems.Add(GetItemForAdd());
            UpdateItems();
        }

        public virtual T1 GetItemForAdd()
        {
            return new T1();
        }

        public virtual void InitializeNewItemObject(T2 itemObject)
        {
            itemObject.OnRemove = OnRemoveItem;
        }

        private enum AdditionalDataPosition
        {
            Top,
            Bottom
        }
    }
}