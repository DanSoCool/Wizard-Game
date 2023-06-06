using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image UserHealthBar;
    public TextMeshProUGUI UserNumberAmount;
    public float UserHealthAmount = 100f;

    public Image AiHealthBar;
    public TextMeshProUGUI AiNumberAmount;
    public float AiHealthAmount = 100f;

    public void UserTakeDamage(float damage)
    {
        UserHealthAmount -= damage;
        UserHealthBar.fillAmount = UserHealthAmount / 100f;
        UserNumberAmount.text = UserHealthAmount.ToString("F1");

        if (UserHealthAmount <= 0f)
        {
            UserHealthAmount = 0f;
            UserHealthBar.fillAmount = 0f / 100f;
            UserNumberAmount.text = "0";
        }
    }

    public void AiTakeDamage(float damage)
    {
        AiHealthAmount -= damage;
        AiHealthBar.fillAmount = AiHealthAmount / 100f;
        AiNumberAmount.text = AiHealthAmount.ToString("F1");

        if (AiHealthAmount <= 0f)
        {
            AiHealthAmount = 0f;
            AiHealthBar.fillAmount = 0f / 100f;
            AiNumberAmount.text = "0";
        }
    }

    public void Refresh()
    {
        UserHealthAmount = 100f;
        AiHealthAmount = 100f;

        UserHealthBar.fillAmount = UserHealthAmount / 100f;
        AiHealthBar.fillAmount = AiHealthAmount / 100f;
    }
}
