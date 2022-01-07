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
    [SerializeField] private GameObject oneDollarButton;
    [SerializeField] private GameObject twoDollarButton;
    [SerializeField] private GameObject fiveDollarButton;
    [SerializeField] private GameObject tenDollarButton;
    [SerializeField] private GameObject betButton;
    [SerializeField] private GameObject cashOutButton;


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
        roundCountDown = 15;
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

    private void StartRound()
    {
        Time.timeScale = 1;
        oneDollarButton.GetComponent<Button>().enabled = false;
        twoDollarButton.GetComponent<Button>().enabled = false;
        fiveDollarButton.GetComponent<Button>().enabled = false;
        tenDollarButton.GetComponent<Button>().enabled = false;
        betButton.SetActive(false);
        cashOutButton.SetActive(true);
        //StartMultiplier();

    }

    public void AddMoney()
    {

    }
}
