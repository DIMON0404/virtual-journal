using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Initer : MonoBehaviour
{
    private void Awake()
    {
        List<IInitable> IInitables = Resources.FindObjectsOfTypeAll<MonoBehaviour>().OfType<IInitable>().ToList();
        foreach (IInitable initable in IInitables)
        {
            if ((initable as MonoBehaviour).gameObject.scene.buildIndex == -1)
                continue;
            initable.Init();
        }
    }
}
