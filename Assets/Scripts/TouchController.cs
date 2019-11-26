using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public bool IsActionAllowed = true;

    public bool OnClick()
    {
        if (IsActionAllowed)
        {
            IsActionAllowed = false;
            gameObject.SetActive(true);
            return true;
        }

        return false;
    }

    public void OnActionEnd()
    {
        IsActionAllowed = true;
        gameObject.SetActive(false);
    }
}
