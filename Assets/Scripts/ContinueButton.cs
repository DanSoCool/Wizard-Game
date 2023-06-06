using UnityEngine;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour
{
    public GameObject PlayerCard;
    public GameObject AiCard;
    public GameObject CustomiseScreen;
    public GameObject Title;
    public GameObject PlayerCardScript;
    public GameObject AiCardScript;
    public GameObject Decider;

    public void OnPress()
    {
        string name = FindObjectOfType<Username>().wizard_name;
        AudioSource errorSFX = FindObjectOfType<Username>().Error;
        Image BG = FindObjectOfType<Username>().Background;

        if (name == "" || name == " " || name == null)
        {
             errorSFX.Play();
             BG.color = new Color32(255, 0, 0, 48);
        }
        else
        {
            Title.SetActive(false);
            CustomiseScreen.SetActive(false);
            PlayerCard.SetActive(true);
            AiCard.SetActive(true);
            PlayerCardScript.SetActive(true);
            AiCardScript.SetActive(true);
            Decider.SetActive(true);
        }
    }
}
