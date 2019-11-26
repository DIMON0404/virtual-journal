using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI_Controllers.Introducing
{
    public abstract class DropDownAbstract<T> : MonoBehaviour where T : Enum
    {
        [SerializeField] protected Dropdown Dropdown;
        [SerializeField] protected JournalModelProxy JournalModelProxy;
        private Dictionary<int, int> Types;
        [SerializeField] private string DefaultName;
        private bool NotDefaultSelected = false;

        private void Awake()
        {
            List<Dropdown.OptionData> datas = new List<Dropdown.OptionData>();
            Types = new Dictionary<int, int>();
            string[] items = Enum.GetNames(typeof(T));
            datas.Add(new Dropdown.OptionData(DefaultName));
            for (int i = 0; i < items.Length; i++)
            {
                Types.Add(i, (int)Enum.Parse(typeof(T), items[i]));
                datas.Add(new Dropdown.OptionData(GetItemName(items[i])));
            }

            Dropdown.options = datas;
        }

        public void OnChanged(int index)
        {
            if (!NotDefaultSelected)
            {
                if (index != 0)
                {
                    Dropdown.options.RemoveAt(0);
                    NotDefaultSelected = true;
                    Dropdown.value = index - 1;
                    OnChanged(index - 1);
                }
            }
            else
            {
                OnChangedEnum(Types[index]);
            }
        }

        protected abstract void OnChangedEnum(int item);

        protected abstract string GetItemName(string item);
    }
}