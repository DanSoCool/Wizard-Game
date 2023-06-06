using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AiLoader : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public Image SelectedImage;
    public Sprite[] SpriteList;

    public string[] names = {"Meowmer", "Harold", "Fren", "Fhur", "Pawr", "Scretch", "Dilbert", "Fang"};

    public int Wisdom;
    public int Dexterity;

    public Image WisdomBar;
    public Image DexterityBar;

    public TextMeshProUGUI HealthAmount;
    public TextMeshProUGUI WisdomTextAmount;
    public TextMeshProUGUI DexterityTextAmount;
    public void LoadAi()
    {
        HealthAmount.text = "100";
        SelectedImage.sprite = SpriteList[Random.Range(0,4)];
        Name.text = names[Random.Range(0,8)];

        Wisdom = Random.Range(5, 16);
        Dexterity = Random.Range(5, 21);

        WisdomBar.fillAmount = Wisdom / 15f;
        DexterityBar.fillAmount = Dexterity / 20f;

        WisdomTextAmount.text = Wisdom.ToString();
        DexterityTextAmount.text = Dexterity.ToString();
    }
}
