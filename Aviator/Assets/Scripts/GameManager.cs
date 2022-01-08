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

    public int betAmount = 0;
    private int roundCountDown;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI roundCountdownText;
    [SerializeField] private TextMeshProUGUI multiplierText;
     

    [Header("Buttons")]
    [SerializeField] private GameObject fiftyDollarsButton;
    [SerializeField] private GameObject hundredDollarsButton;
    [SerializeField] private GameObject fiveHundredDollarsButton;
    [SerializeField] private GameObject betButton;
    [SerializeField] private GameObject cashOutButton;

    [Header("Variables")]
    [SerializeField] private float multiplier = 1f;
    [SerializeField] private float sessionTime;
    [SerializeField] private float betMoney = 0f;
    [SerializeField] private float bankMoney = 10000f;

    //  [Header("Booleans")]

    [SerializeField]

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        Time.timeScale = 0f;
    }


    private void Start()
    {
        roundCountDown = 10;
        StartCoroutine(FirstCountDown());
    }

    IEnumerator FirstCountDown()
    {
        if (roundCountDown > 0)
        {
            roundCountDown--;
            yield return new WaitForSeconds(1);
        }

        if(roundCountDown == 0)
        {
            StopCoroutine(FirstCountDown());
            StartRound();
        }
    }

    private void Update()
    {
        Debug.Log(betMoney);
        Debug.Log(betAmount);
        Debug.Log(bankMoney);
    }

    private void StartRound()
    {
        Time.timeScale = 1;
        fiftyDollarsButton.GetComponent<Button>().enabled = false;
        hundredDollarsButton.GetComponent<Button>().enabled = false;
        fiveHundredDollarsButton.GetComponent<Button>().enabled = false;
        betButton.SetActive(false);
        cashOutButton.SetActive(true);
        StartMultiplier();

    }

    private void StartMultiplier()
    {
        multiplier += Time.deltaTime / 5;
        betMoney = betMoney * multiplier;
    }

    public void bet50Dollars()
    {
        if (bankMoney - betMoney >= 50)
        {
            betMoney += 50;
        }
    }

    public void bet100Dollars()
    {
        if (bankMoney - betMoney >= 100)
        {
            betMoney += 100;
        }
    }

    public void bet500Dollars()
    {
        if (bankMoney - betMoney >= 500)
        {
            betMoney += 500;
        }
    }

    public void betTotalBetMoney()
    {
        bankMoney -= betMoney;
    }
}
