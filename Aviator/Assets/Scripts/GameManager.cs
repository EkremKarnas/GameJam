using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Cinemachine;

public class GameManager : MonoBehaviour
{

    private float roundCountDown;

    [SerializeField] CinemachineVirtualCamera virtualCam2;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI roundCountdownText;
    [SerializeField] private TextMeshProUGUI multiplierText;
    [SerializeField] private TextMeshProUGUI betAmountText;
    [SerializeField] private TextMeshProUGUI bankAmountText;
    [SerializeField] private TextMeshProUGUI flewAwayText;

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
    [SerializeField] private float bankMoney;

    [Header("Booleans")]
    [SerializeField] private bool canBet = true;


    private void Start()
    {
        bankMoney = SceneManager.instance.bankMoney;
        sessionMultiplier = UnityEngine.Random.Range(1f, 10f);
        roundCountDown = 10;
        canBet = true;
    }

    private void Update()
    {
        betAmountText.text = betMoney.ToString();
        bankAmountText.text = bankMoney.ToString();
        multiplierText.text = multiplier.ToString() + "x";
        CountDown();

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

    private void StartRound()
    {
        canBet = false;
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
            multiplier += (5f * Time.deltaTime) / 5;
            multiplier = Mathf.Round(multiplier * 100.0f) * 0.01f;
            betMoney = bettedMoney * multiplier;
        }

        if(sessionMultiplier <= multiplier)
        {
            multiplier = Mathf.Round(multiplier * 1000.0f) * 0.001f;
            virtualCam2.Follow = null;
            virtualCam2.LookAt = null;
            flewAwayText.gameObject.SetActive(true);
            StartCoroutine(RestartTheGame());
        }
    }

    private IEnumerator RestartTheGame()
    {
        yield return new WaitForSeconds(3);
        SceneManager.instance.RestartGame();
    }

    public void Bet50Dollars()
    {
        if (bankMoney - betMoney >= 50 && canBet == true)
        {
            betMoney += 50;
        }
    }

    public void Bet100Dollars()
    {
        if (bankMoney - betMoney >= 100 && canBet == true)
        {
            betMoney += 100;
        }
    }

    public void Bet500Dollars()
    {
        if (bankMoney - betMoney >= 500 && canBet == true)
        {
            betMoney += 500;
        }
    }

    public void BetTotalBetMoney()
    {
        if (canBet == true)
        {
            bankMoney -= betMoney;
            bettedMoney = betMoney;
            SceneManager.instance.bankMoney = bankMoney;
        }
        canBet = false;
    }

    public void CashOut()
    {
        bankMoney += betMoney;
        betMoney = 0;
        bettedMoney = 0;
        SceneManager.instance.bankMoney = bankMoney;
    }    
}
