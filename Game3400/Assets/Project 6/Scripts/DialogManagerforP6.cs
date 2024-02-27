using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManagerforP6 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dialogPanel;
    public GameObject iconPanel;
    public TextMeshProUGUI dialogText;

    void Start()
    {
        HideDialog();
        HideIcon();
    }

    public void ShowDialog(string text)
    {
        dialogText.text = text;
        dialogPanel.SetActive(true);
    }

    public void HideDialog()
    {
        dialogPanel.SetActive(false);
    }

    public void ShowIcon(string text)
    {
        dialogText.text = text;
        iconPanel.SetActive(true);
        dialogPanel.SetActive(true);
    }

    public void HideIcon()
    {
        iconPanel.SetActive(false);
    }
}

