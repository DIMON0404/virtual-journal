using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(InputField))]
public class InputFieldInt : MonoBehaviour
{
    private InputField InputField;
    [SerializeField] private IntEvent OnValueChangedEvent;
    [SerializeField] private bool UseMinValue;
    [SerializeField] private int MinValue;
    [SerializeField] private bool UseMaxValue;
    [SerializeField] private int MaxValue;
    
    private int LastValidateValue;

    private void Awake()
    {
        InputField = GetComponent<InputField>();
        InputField.onEndEdit.AddListener(OnEndEdit);
        if (UseMinValue)
        {
            if (MinValue > 0)
            {
                LastValidateValue = MinValue;
            }
            else if (UseMaxValue && MaxValue < 0)
            {
                LastValidateValue = MaxValue;
            }
            else
            {
                LastValidateValue = 0;
            }
        }
    }
    
    private void OnEndEdit(string text)
    {   
        bool validate = false;
        int parsed = int.Parse(text);
        if (!string.IsNullOrEmpty(text) && (!UseMinValue || parsed >= MinValue) && (!UseMaxValue || parsed <= MaxValue))
        {
            validate = true;
        }

        if (validate)
        {
            SetValue(parsed);
        }
        else
        {
            InputField.text = LastValidateValue.ToString();
            InputField.onEndEdit.Invoke(LastValidateValue.ToString());
        }
    }

    private void SetValue(int value)
    {
        OnValueChangedEvent.Invoke(value);
    }

    [Serializable]
    private class IntEvent : UnityEvent<int>
    {}
}
