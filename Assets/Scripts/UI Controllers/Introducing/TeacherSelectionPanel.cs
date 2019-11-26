using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace UI_Controllers.Introducing
{
    public class TeacherSelectionPanel : MonoBehaviour, IInitable
    {
        private TeacherControllerAbstract TeacherController;
        [SerializeField] private Content AvailableTeachers;
        [SerializeField] private Content SelectedTeachers;
        [SerializeField] private InputField SearchField;
        private List<ItemSO> SelectedItems;
        private List<ItemSO> NotSelectedItmes;

        public void Init()
        {
            AvailableTeachers.OnClick = SelectAndUpdate;
            SelectedTeachers.OnClick = DeselectAndUpdate;
        }
    
        public void Init(TeacherControllerAbstract teacherController, ItemSO[] items, ItemSO[] selectedItems)
        {
            TeacherController = teacherController;
            NotSelectedItmes = new List<ItemSO>(items);
            SelectedItems = new List<ItemSO>();
            SetSelectedItems(selectedItems);
            UpdateItems();
        }

        public void SetSelectedItems(ItemSO[] items)
        {
            foreach (ItemSO item in items)
            {
                if (NotSelectedItmes.Contains(item) && !SelectedItems.Contains(item))
                {
                    Select(item, false);
                }
            }
        
            UpdateItems();
        }

        public void SelectAndUpdate(ItemSO item)
        {
            Select(item, true);
        }

        public void Select(ItemSO item, bool update)
        {
            NotSelectedItmes.Remove(item);
            SelectedItems.Add(item);
            if (update)
                UpdateItems();
        }

        public void DeselectAndUpdate(ItemSO item)
        {
            Deselect(item, true);
        }

        public void Deselect(ItemSO item, bool update)
        {
            NotSelectedItmes.Add(item);
            SelectedItems.Remove(item);
            if (update)
                UpdateItems();
        }

        public void UpdateItems()
        {
            string searchedText = SearchField.text;
            if (searchedText == String.Empty)
                AvailableTeachers.SetItems(NotSelectedItmes);
            else
                AvailableTeachers.SetItems(NotSelectedItmes
                    .Where(item => item is Teacher teacher && teacher.IsMatched(searchedText)).ToList());
            SelectedTeachers.SetItems(SelectedItems);
        }

        public void OnSearchFieldChanged()
        {
            UpdateItems();
        }

        public void ApplyNewItems()
        {
            TeacherController.UpdateTeachersList(SelectedItems.Select(item => item as Teacher).ToList());
            TeacherController.UpdateTeachersView();
        }
    }
}