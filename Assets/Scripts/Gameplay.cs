using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public string PlayerElement;
    public string AiElement;

    public string AiName;

    public string[] Elements;

    public GameObject AttackChoice;
    public GameObject DefendChoice;
    public GameObject Title;
    public GameObject Customisation;
    public GameObject OutcomeScreen;
    public GameObject WinScreen;
    public GameObject LoseScreen;
    public GameObject PlayerCard;
    public GameObject AiCard;

    public TextMeshProUGUI UserElement;
    public TextMeshProUGUI BotElement;
    public TextMeshProUGUI CritMsg;
    public TextMeshProUGUI EvadeMsg;
    public TextMeshProUGUI DamageMsg;

    public TextMeshProUGUI WinMsg;
    public TextMeshProUGUI LoseMsg;

    public int result;
    public float dmg;

    public float PlayerDex;
    public float AiDex;

    public float PlayerWis;
    public float AiWis;

    public float UserHP;
    public float AiHP;

    public bool IsAttacking;
    public bool Evaded;

    public bool UserAlive = true;
    public bool AiAlive = true;

    public bool AttackCrit = false;
    public bool DefenseCrit = false;
    public void Attack()
    {
        AttackChoice.SetActive(true);
        IsAttacking = true;
    }

    public void Defend()
    {
        DefendChoice.SetActive(true);
        IsAttacking = false;
    }

    public void Restart()
    {
        FindObjectOfType<HealthManager>().Refresh();
        FindObjectOfType<ImageChanger>().LoadSprite();
        FindObjectOfType<Username>().ResetName();

        if (WinScreen.activeInHierarchy)
        {
            WinScreen.SetActive(false);
        }
        if (LoseScreen.activeInHierarchy)
        {
            LoseScreen.SetActive(false);
        }

        Customisation.SetActive(true);
        Title.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    void Win()
    {
        UserHP = FindAnyObjectByType<HealthManager>().UserHealthAmount;

        PlayerCard.SetActive(false);
        AiCard.SetActive(false);

        WinMsg.text = "You won with <color=#FF3D3D>" + UserHP.ToString("F1") + "</color> health remaining";
        WinScreen.SetActive(true);
    }

    void Lose()
    {
        AiName = FindAnyObjectByType<AiLoader>().Name.text;
        AiHP = FindAnyObjectByType<HealthManager>().AiHealthAmount;

        PlayerCard.SetActive(false);
        AiCard.SetActive(false);

        LoseMsg.text = AiName + " Had <color=#FF3D3D>" + AiHP.ToString("F1") + "</color> health remaining";
        LoseScreen.SetActive(true) ;
    }

    public void Fire()
    {
        if (AttackChoice.activeInHierarchy)
        {
            AttackChoice.SetActive(false);
        }

        if (DefendChoice.activeInHierarchy)
        {
            DefendChoice.SetActive(false);
        }

        PlayerElement = "Fire";
        AiElement = Elements[Random.Range(0,4)];
        StartOutcome();
    }

    public void Air() 
    {
        if (AttackChoice.activeInHierarchy)
        { 
            AttackChoice.SetActive(false);
        }

        if (DefendChoice.activeInHierarchy)
        { 
            DefendChoice.SetActive(false); 
        }

        PlayerElement = "Air";
        AiElement = Elements[Random.Range(0, 4)];
        StartOutcome();
    }

    public void Earth() 
    {
        if (AttackChoice.activeInHierarchy)
        {
            AttackChoice.SetActive(false);
        }

        if (DefendChoice.activeInHierarchy)
        {
            DefendChoice.SetActive(false);
        }

        PlayerElement = "Earth";
        AiElement = Elements[Random.Range(0, 4)];
        StartOutcome();
    }

    public void Water()
    {
        if (AttackChoice.activeInHierarchy)
        {
            AttackChoice.SetActive(false);
        }

        if (DefendChoice.activeInHierarchy)
        {
            DefendChoice.SetActive(false);
        }

        PlayerElement = "Water";
        AiElement = Elements[Random.Range(0, 4)];
        StartOutcome();
    }

    public async void BeginReveal()
    {
        AiName = FindAnyObjectByType<AiLoader>().Name.text;

        AttackChoice.SetActive(false);
        DefendChoice.SetActive(false);
        OutcomeScreen.SetActive(true);

        string fire = "<color=#FF3B3B>fire</color>";
        string air = "<color=#40D91A>air</color>";
        string earth = "<color=#FF651E>earth</color>";
        string water = "<color=#3B87FF>water</color>";

        switch (PlayerElement)
        {
            case "Fire":
                UserElement.text = "You chose " + fire;
                break;

            case "Air":
                UserElement.text = "You chose " + air;
                break;

            case "Earth":
                UserElement.text = "You chose " + earth;
                break;

            case "Water":
                UserElement.text = "You chose " + water;
                break;
        }
        await Task.Delay(1000);
        switch (AiElement)
        {
            case "Fire":
                BotElement.text = AiName + " chose " + fire;
                break;

            case "Air":
                BotElement.text = AiName + " chose " + air;
                break;

            case "Earth":
                BotElement.text = AiName + " chose " + earth;
                break;

            case "Water":
                BotElement.text = AiName + " chose " + water;
                break;
        }
    }

    void Critical()
    {
        if (IsAttacking)
        {
            switch (PlayerElement)
            {
                case "Fire":
                    if (AiElement == "Air")
                    {
                        AttackCrit = true;
                        DefenseCrit = false;
                    }
                    else if (AiElement == "Water")
                    {
                        DefenseCrit = true;
                        AttackCrit = false;
                    }
                    else
                    {
                        AttackCrit = false;
                        DefenseCrit = false;
                    }
                    break;

                case "Air":
                    if (AiElement == "Earth")
                    {
                        AttackCrit = true;
                        DefenseCrit = false;
                    }
                    else if (AiElement == "Fire")
                    {
                        DefenseCrit = true;
                        AttackCrit = false;
                    }
                    else
                    {
                        AttackCrit = false;
                        DefenseCrit = false;
                    }
                    break;

                case "Earth":
                    if (AiElement == "Water")
                    {
                        AttackCrit = true;
                        DefenseCrit = false;
                    }
                    else if (AiElement == "Air")
                    {
                        DefenseCrit = true;
                        AttackCrit = false;
                    }
                    else
                    {
                        AttackCrit = false;
                        DefenseCrit = false;
                    }
                    break;

                case "Water":
                    if (AiElement == "Fire")
                    {
                        AttackCrit = true;
                        DefenseCrit = false;
                    }
                    else if (AiElement == "Earth")
                    {
                        DefenseCrit = true;
                        AttackCrit = false;
                    }
                    else
                    {
                        AttackCrit = false;
                        DefenseCrit = false;
                    }
                    break;
            }
        }
        else if (!IsAttacking)
        {
            switch (AiElement)
            {
                case "Fire":
                    if (PlayerElement == "Air")
                    {
                        AttackCrit = true;
                        DefenseCrit = false;
                    }
                    else if (PlayerElement == "Water")
                    {
                        DefenseCrit = true;
                        AttackCrit = false;
                    }
                    else
                    {
                        AttackCrit = false;
                        DefenseCrit = false;
                    }
                    break;

                case "Air":
                    if (PlayerElement == "Earth")
                    {
                        AttackCrit = true;
                        DefenseCrit = false;
                    }
                    else if (PlayerElement == "Fire")
                    {
                        DefenseCrit = true;
                        AttackCrit = false;
                    }
                    else
                    {
                        AttackCrit = false;
                        DefenseCrit = false;
                    }
                    break;

                case "Earth":
                    if (PlayerElement == "Water")
                    {
                        AttackCrit = true;
                        DefenseCrit = false;
                    }
                    else if (PlayerElement == "Air")
                    {
                        DefenseCrit = true;
                        AttackCrit = false;
                    }
                    else
                    {
                        AttackCrit = false;
                        DefenseCrit = false;
                    }
                    break;

                case "Water":
                    if (PlayerElement == "Fire")
                    {
                        AttackCrit = true;
                        DefenseCrit = false;
                    }
                    else if (PlayerElement == "Earth")
                    {
                        DefenseCrit = true;
                        AttackCrit = false;
                    }
                    else
                    {
                        AttackCrit = false;
                        DefenseCrit = false;
                    }
                    break;
            }
        }
        if (AttackCrit)
        {
            CritMsg.text = "Critical Attack!";
        }
        else if (DefenseCrit)
        {
            CritMsg.text = "Critical Defence!";
        }
        else
        {
            CritMsg.text = "No Criticals";
        }
    }

    void Evasion()
    {
        AiName = FindAnyObjectByType<AiLoader>().Name.text;
        PlayerDex = FindAnyObjectByType<UserLoader>().Dexterity;
        AiDex = FindObjectOfType<AiLoader>().Dexterity;
        result = Random.Range(1, 100);
        if (IsAttacking)
        {
            if (result <= AiDex)
            {
                EvadeMsg.text = AiName + " Evaded!";
                Evaded = true;
            }
            else
            {
                EvadeMsg.text = AiName + " Could not evade!";
                Evaded = false;
            }
        }
        else
        {
            if (result <= PlayerDex)
            {
                EvadeMsg.text = "You evaded!";
                Evaded = true;
            }
            else
            {
                EvadeMsg.text = "You could not evade!";
                Evaded = false;
            }
        }
    }

    public void DamageHandler()
    {
        PlayerWis = FindAnyObjectByType<UserLoader>().Wisdom;
        AiWis = FindObjectOfType<AiLoader>().Wisdom;
        AiName = FindAnyObjectByType<AiLoader>().Name.text;
        if (IsAttacking)
        {
            dmg = PlayerWis;
            if (AttackCrit)
            {
                dmg *= 1.2f;
            }
            else if (DefenseCrit)
            {
                dmg *= 0.5f;
            }
            if (Evaded)
            {
                dmg = 0f;
            }
            DamageMsg.text = "You dealt " + dmg.ToString("F1") + " damage!";
            FindAnyObjectByType<HealthManager>().AiTakeDamage(dmg);
        }
        else if (!IsAttacking)
        {
            dmg = AiWis;
            if (AttackCrit)
            {
                dmg *= 1.2f;
            }
            else if (DefenseCrit)
            {
                dmg *= 0.5f;
            }
            if (Evaded)
            {
                dmg = 0f;
            }
            DamageMsg.text = AiName + " Dealt " + dmg.ToString("F1") + " damage!";
            FindAnyObjectByType<HealthManager>().UserTakeDamage(dmg);
        }
    }

    public void CheckLiving()
    {
        UserHP = FindAnyObjectByType<HealthManager>().UserHealthAmount;
        AiHP = FindAnyObjectByType<HealthManager>().AiHealthAmount;

        if (UserHP <= 0f)
        {
            UserAlive = false;
            
        }
        if (AiHP <= 0f)
        {
            AiAlive = false;
        }
        if (UserHP > 0f)
        {
            UserAlive = true;
        }
        if (AiHP > 0f)
        {
            AiAlive = true;
        }
    }

    void StartNewBattle()
    {
        if (IsAttacking)
        {
            OutcomeScreen.SetActive(false);
            UserElement.text = "";
            BotElement.text = "";
            CritMsg.text = "";
            EvadeMsg.text = "";
            DamageMsg.text = "";
            if (UserAlive && AiAlive)
            {
                AttackChoice.SetActive(true);
            }

        }    
        if (!IsAttacking)
        {
            OutcomeScreen.SetActive(false);
            UserElement.text = "";
            BotElement.text = "";
            CritMsg.text = "";
            EvadeMsg.text = "";
            DamageMsg.text = "";
            if (UserAlive && AiAlive)
            {
                DefendChoice.SetActive(true);
            }
        }
    }

    async void StartOutcome()
    {
        if (IsAttacking) 
        {
            switch(PlayerElement) 
            {
                case "Fire":
                    BeginReveal();
                    await Task.Delay(1500);
                    Critical();
                    await Task.Delay(1500);
                    Evasion();
                    await Task.Delay(1000);
                    DamageHandler();
                    CheckLiving();
                    await Task.Delay(3000);
                    break;

                case "Air":
                    BeginReveal();
                    await Task.Delay(1500);
                    Critical();
                    await Task.Delay(1500);
                    Evasion();
                    await Task.Delay(1000);
                    DamageHandler();
                    CheckLiving();
                    await Task.Delay(3000);
                    break;

                case "Earth":
                    BeginReveal();
                    await Task.Delay(1500);
                    Critical();
                    await Task.Delay(1500);
                    Evasion();
                    await Task.Delay(1000);
                    DamageHandler();
                    CheckLiving();
                    await Task.Delay(3000);
                    break;

                case "Water":
                    BeginReveal();
                    await Task.Delay(1500);
                    Critical();
                    await Task.Delay(1500);
                    Evasion();
                    await Task.Delay(1000);
                    DamageHandler();
                    CheckLiving();
                    await Task.Delay(3000);
                    break;
            }
        }
        if (!IsAttacking)
        {
            switch (AiElement)
            {
                case "Fire":
                    BeginReveal();
                    await Task.Delay(1500);
                    Critical();
                    await Task.Delay(1500);
                    Evasion();
                    await Task.Delay(1000);
                    DamageHandler();
                    CheckLiving();
                    await Task.Delay(3000);
                    break;

                case "Air":
                    BeginReveal();
                    await Task.Delay(1500);
                    Critical();
                    await Task.Delay(1500);
                    Evasion();
                    await Task.Delay(1000);
                    DamageHandler();
                    CheckLiving();
                    await Task.Delay(3000);
                    break;

                case "Earth":
                    BeginReveal();
                    await Task.Delay(1500);
                    Critical();
                    await Task.Delay(1500);
                    Evasion();
                    await Task.Delay(1000);
                    DamageHandler();
                    CheckLiving();
                    await Task.Delay(3000);
                    break;

                case "Water":
                    BeginReveal();
                    await Task.Delay(1500);
                    Critical();
                    await Task.Delay(1500);
                    Evasion();
                    await Task.Delay(1000);
                    DamageHandler();
                    CheckLiving();
                    await Task.Delay(3000);
                    break;
            }
        }
        if (IsAttacking)
        {
            IsAttacking = false;
        }
        else if (!IsAttacking)
        { 
            IsAttacking = true; 
        }
        StartNewBattle();
        if (AiAlive == false)
        {
            Win();
        }
        if (UserAlive == false)
        {
            Lose();
        }
    }
}
