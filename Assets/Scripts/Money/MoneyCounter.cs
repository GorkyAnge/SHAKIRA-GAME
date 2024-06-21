using UnityEngine;
using TMPro;

public class MoneyCounter : MonoBehaviour
{
    public static MoneyCounter Instance { get; private set; }

    public TextMeshProUGUI moneyText;
    private int moneyAmount;

    private void Awake()
    {
        // Singleton pattern para asegurar que solo hay una instancia de MoneyCounter
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        moneyAmount = 0;
        UpdateMoneyText();
    }

    public void AddMoney(int amount)
    {
        moneyAmount += amount;
        UpdateMoneyText();
    }

    private void UpdateMoneyText()
    {
        moneyText.text = moneyAmount.ToString();
    }

    public int GetMoneyAmount()
    {
        return moneyAmount;
    }

}
