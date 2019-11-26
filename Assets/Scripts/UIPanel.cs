using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel : MonoBehaviour
{
    public UIManager Manager;
    private bool IsActive = false;

    public bool Active
    {
        get { return IsActive; }
        set
        {
            IsActive = value;
            gameObject.SetActive(value);
        }
    }
    
    public void Init(UIManager manager)
    {
        Manager = manager;
    }
}
