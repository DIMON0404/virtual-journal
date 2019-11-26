using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimaationController : MonoBehaviour
{
    public Animator Animator;
    public TouchController TouchController;

    public void OnClick()
    {
        if (TouchController.OnClick())
        {
            Animator.SetTrigger("Action");
        }
    }

    public void ResetTrigger()
    {
        TouchController.OnActionEnd();
        Animator.ResetTrigger("Action");
    }
}
