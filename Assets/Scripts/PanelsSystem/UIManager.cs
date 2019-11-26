using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour, IInitable
{
    public List<UIPanel> Panels;
    [HideInInspector]
    public UIPanel ActivePanel;
    
    public void Init()
    {
        foreach (UIPanel panel in Panels)
        {
            panel.Init(this);
        }
        
        ActivePanel = null;
        if (Panels.Count > 0)
        {
            SetPanel(Panels[0]);
        }
    }

    public void SetPanel(UIPanel panel)
    {
        if (panel == ActivePanel)
            return;
        
        if (ActivePanel)
        {
            ActivePanel.Active = false;
        }

        ActivePanel = panel;
        if (panel)
            ActivePanel.Active = true;
    }
}
