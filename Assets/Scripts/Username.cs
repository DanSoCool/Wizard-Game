using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Username : MonoBehaviour
{
    public TMP_InputField inputField;
    public Image Background;
    public AudioSource Error;

    public string wizard_name;

    public void SetName()
    {
        if (inputField.text == "" || inputField.text == null || inputField.text == " ")
        {
            Error.Play();
            Background.color = new Color32(255, 0, 0, 48);
            return;
        }
        else
        {
            Background.color = new Color32(255, 255, 255, 48);
            wizard_name = inputField.text;
            Debug.Log("User set their name to: " + wizard_name);
        }
    }

    public void ResetName()
    {
        wizard_name = "";
        inputField.text = "";
    }
}
