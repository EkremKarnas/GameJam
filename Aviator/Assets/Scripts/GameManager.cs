using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private float roundCountDown;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI roundCountdownText;
    [SerializeField] private TextMeshProUGUI multiplierText;
    [SerializeField] private TextMeshProUGUI betAmountText;
    [SerializeField] private TextMeshProUGUI bankAmountText;

    [Header("Images")]
    [SerializeField] private Image betButtonImage;
    [SerializeField] private Image cashOutButtonImage;

    [Header("Buttons")]
    [SerializeField] private GameObject fiftyDollarsButton;
    [SerializeField] private GameObject hundredDollarsButton;
    [SerializeField] private GameObject fiveHundredDollarsButton;
    [SerializeField] private GameObject betButton;
    [SerializeField] private GameObject cashOutButton;

    [Header("Variables")]
    [SerializeField] private float multiplier = 1f;
    [SerializeField] private float sessionMultiplier;
    [SerializeField] private float betMoney;
    [SerializeField] private float bettedMoney;
    [SerializeField] private float bankMoney = 10000f;


    [Header("Booleans")]
    [SerializeField] private bool canBet = true;

    [SerializeField]

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }


    private void Start()
    {
        roundCountDown = 10;
        canBet = true;
        canBet = false;
        sessionMultiplier = UnityEngine.Random.Range(1f, 30f);
    }

    private void CountDown()
    {
        if (roundCountDown <= 0)
        {
            roundCountdownText.gameObject.SetActive(false);
            StartRound();
        }

        roundCountDown -= 1 * Time.deltaTime;
        roundCountdownText.text = Mathf.RoundToInt(roundCountDown).ToString();
    }

    private void Update()
    {
        betAmountText.text = betMoney.ToString();
        bankAmountText.text = bankMoney.ToString();
        multiplierText.text = multiplier.ToString() + "x";
        CountDown();

    }

    private void StartRound()
    {
        //fiftyDollarsButton.GetComponent<Button>().enabled = false;
        //hundredDollarsButton.GetComponent<Button>().enabled = false;
        //fiveHundredDollarsButton.GetComponent<Button>().enabled = false;
        betButton.SetActive(false);
        betButtonImage.gameObject.SetActive(false);
        cashOutButton.SetActive(true);
        cashOutButtonImage.gameObject.SetActive(true);
        StartMultiplier();

    }

    private void StartMultiplier()
    {
        if (sessionMultiplier > multiplier)
        {
            multiplier += Time.deltaTime / 5;
            multiplier = Mathf.Round(multiplier * 1000.0f) * 0.001f;
            betMoney = bettedMoney * multiplier;
        }

        if(sessionMultiplier <= multiplier)
        {
            Time.timeScale = 0f;
        }
    }

    public void bet50Dollars()
    {
        if (bankMoney - betMoney >= 50 && canBet == true)
        {
            betMoney += 50;
        }
    }

    public void bet100Dollars()
    {
        if (bankMoney - betMoney >= 100 && canBet == true)
        {
            betMoney += 100;
        }
    }

    public void bet500Dollars()
    {
        if (bankMoney - betMoney >= 500 && canBet == true)
        {
            betMoney += 500;
        }
    }

    public void betTotalBetMoney()
    {
        if (canBet == true)
        {
            bankMoney -= betMoney;
            bettedMoney = betMoney;
        }
        canBet = false;
    }
}
