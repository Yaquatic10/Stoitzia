using UnityEngine;
using TMPro;
using System.Collections;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager instance;

    public int currentCurrency = 100;
    public int rewardPerEnemy = 25;

    public int turretPrice = 50;
    public int currencyPerSecond = 15;

    public TextMeshProUGUI currencyText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateCurrencyText();
        StartCoroutine(GenerateCurrency());
    }

    public bool CanBuildTurret()
    {
        return currentCurrency >= turretPrice;
    }

    public void BuildTurret()
    {
        if (CanBuildTurret())
        {
            currentCurrency -= turretPrice;
            UpdateCurrencyText();
        }
        else
        {
            Debug.Log("No hay suficiente currency para construir la torreta.");
        }
    }

    public void EnemyKilled()
    {
        currentCurrency += rewardPerEnemy;
        UpdateCurrencyText();
    }

    private void UpdateCurrencyText()
    {
        if (currencyText != null)
        {
            currencyText.text = "Currency: " + currentCurrency.ToString();
        }
    }

    private IEnumerator GenerateCurrency()
    {
        while (true)
        {
            currentCurrency += currencyPerSecond;
            UpdateCurrencyText();
            yield return new WaitForSeconds(1f);
        }
    }
}
