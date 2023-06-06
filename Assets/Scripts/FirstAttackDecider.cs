using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class FirstAttackDecider : MonoBehaviour
{
    public GameObject DeciderObject;
    public GameObject ReavealerObject;

    public TextMeshProUGUI UserGuess;
    public TextMeshProUGUI BotStartMsg;
    public TextMeshProUGUI BotReveal;
    public TextMeshProUGUI Confirmation;

    public int PlayerChoice;
    public int AiChoice;

    public bool PlayerHasPriority;

    public async void Reveal()
    {
        ReavealerObject.SetActive(true);
        UserGuess.text = "You Selected " + PlayerChoice;
        await Task.Delay(2000);
        BotStartMsg.text = "The Bot Guessed...";
        await Task.Delay(2000);
        BotReveal.text = AiChoice.ToString();
        if (PlayerHasPriority)
        {
            Confirmation.color = new Color32(89,255,83,255);
            Confirmation.text = "You keep your priority!";
        }
        else
        {
            Confirmation.color = new Color32(255,51,45,255);
            Confirmation.text = "You lose your priority!";
        }
        await Task.Delay(3500);
        ReavealerObject.SetActive(false);

        UserGuess.text = "";
        BotStartMsg.text = "";
        BotReveal.text = "";
        Confirmation.text = "";

        if (PlayerHasPriority)
        {
            FindAnyObjectByType<Gameplay>().Attack();
        }
        else if (!PlayerHasPriority)
        {
            FindAnyObjectByType<Gameplay>().Defend();
        }
    }

    public void Chosen()
    {
        if (AiChoice == PlayerChoice)
        {
            PlayerHasPriority = false;
        }
        else
        {
            PlayerHasPriority = true;
        }
        Reveal();
    }

    public void OneClick()
    {
        PlayerChoice = 1;
        AiChoice = Random.Range(1,5);
        DeciderObject.SetActive(false);
        Chosen();
    }
    public void TwoClick()
    {
        PlayerChoice = 2;
        AiChoice = Random.Range(1, 5);
        DeciderObject.SetActive(false);
        Chosen();
    }
    public void ThreeClick()
    {
        PlayerChoice = 3;
        AiChoice = Random.Range(1, 5);
        DeciderObject.SetActive(false);
        Chosen();
    }
    public void FourClick()
    {
        PlayerChoice = 4;
        AiChoice = Random.Range(1, 5);
        DeciderObject.SetActive(false);
        Chosen();  
    }
}
