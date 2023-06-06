using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UserLoader : MonoBehaviour
{
    public int Wisdom;
    public int Dexterity;

    public Image Avatar;
    public Image WisdomBar;
    public Image DexterityBar;

    public TextMeshProUGUI HealthAmount;
    public TextMeshProUGUI WisdomTextAmount;
    public TextMeshProUGUI DexterityTextAmount;
    public TextMeshProUGUI Name;

    public void LoadUser()
    {
        HealthAmount.text = "100";
        Wisdom = Random.Range(5, 15);
        Dexterity = Random.Range(5, 20);

        WisdomBar.fillAmount = Wisdom / 15f;
        DexterityBar.fillAmount = Dexterity / 20f;

        WisdomTextAmount.text = Wisdom.ToString();
        DexterityTextAmount.text = Dexterity.ToString();

        Avatar.sprite = FindAnyObjectByType<ImageChanger>().Selected.sprite;
        Name.text = FindObjectOfType<Username>().wizard_name;
    }

}
