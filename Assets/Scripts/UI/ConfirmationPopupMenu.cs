using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using UnityEngine.EventSystems;

public class ConfirmationPopupMenu : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private TextMeshProUGUI displayText;
    [SerializeField] private Button confirmButton;
    [SerializeField] private Button cancelButton;

    public void ActivateMenu(string displayText, UnityAction confirmAction, UnityAction cancelAction)
    {
        this.gameObject.SetActive(true);
        this.displayText.text = displayText;
        confirmButton.onClick.RemoveAllListeners();
        cancelButton.onClick.RemoveAllListeners();
        cancelButton.Select();//opens menu with cancel pre selected

        confirmButton.onClick.AddListener(() =>
        {
            DeactivateMenu();
            confirmAction();
        });
        cancelButton.onClick.AddListener(() =>
        {
            DeactivateMenu();
            cancelAction();
        });
    }
    private void DeactivateMenu()
    {
        this.gameObject.SetActive(false);
    }
}
