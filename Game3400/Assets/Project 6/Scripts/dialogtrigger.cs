using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public DialogManagerforP6 DialogManager;
    public string dialogText = "";
    public string playerText = "";
    private bool dialogShown = false;
    void Start()
    {

    }

    void Update()
    {
        if (dialogShown && Input.GetMouseButtonDown(0) && !string.IsNullOrEmpty(playerText))
        {
            DialogManager.ShowIcon(playerText);
            dialogShown = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!string.IsNullOrEmpty(dialogText))
            {
                DialogManager.ShowDialog(dialogText);
                dialogShown = true;
            }
            else
            {
                DialogManager.ShowIcon(playerText);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DialogManager.HideDialog();
            DialogManager.HideIcon();
            dialogShown = false;
        }
    }
}
