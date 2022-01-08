using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RandomXScript : MonoBehaviour
{
    [SerializeField]
    GameObject cancelButton;
    [SerializeField]
    GameObject betButton;
    [SerializeField]
    GameObject timer;
    [SerializeField]
    Timer timerScript;
    [SerializeField]
    TextMeshProUGUI Xtext; //multiplier numbers
    [SerializeField]
    TextMeshProUGUI totalMoneyText;

    [SerializeField]
    TextMeshProUGUI betMoneyText;
    private float deltaTime; // XTextte yazan sayi
    private float timeScale = 5;
    private bool getTheReward = false;
    private bool endOfSession = false;
    private bool add100Money;
    private bool add250Money;
    private bool add500Money;
    private bool waitingForNextRound;
    private bool isBetted = false;

    [SerializeField]
    float currentMoney;
    [SerializeField]
    float totalMoney;
    private float addMoney;
    private float randomNum;
    void Start()
    {
        StartCoroutine(WaitTenSecondsAtStart());
    }


    void Update()
    {
        Xtext.text = deltaTime.ToString("0.00") + "x";
        totalMoneyText.text = "Total Money : " + totalMoney.ToString();
        betMoneyText.text = "Bet Money : " + currentMoney.ToString();

        if (deltaTime <= randomNum)
        {
            deltaTime += Time.deltaTime / timeScale;
        }
        else
        {
            if (endOfSession == false)
            {
                endOfSession = true;
                StartCoroutine(WaitFiveSeconds());
                timer.SetActive(true);
                waitingForNextRound = true;
                isBetted = false;
                currentMoney = 0;
            }
        }
    }

    void RandomGenerator()
    {
        randomNum = Random.Range(1f, 5f);
    }

    public void GetTheReward()
    {
        if (waitingForNextRound == true)
            return;

        if (getTheReward == true)
            return;

        getTheReward = true;
        addMoney = currentMoney * deltaTime;
        totalMoney = totalMoney + addMoney;
    }

    IEnumerator WaitFiveSeconds()
    {
        yield return new WaitForSeconds(10);
        deltaTime = 1f;
        RandomGenerator();
        getTheReward = false;
        endOfSession = false;
        Debug.Log(randomNum);
        timer.SetActive(false);
        timerScript.currentTime = timerScript.startingTime;
        waitingForNextRound = false;
        isBetted = true;
                                                                // X'lerin artmaya basladigi yer
    }

    IEnumerator WaitTenSecondsAtStart()
    {
        yield return new WaitForSeconds(10);
                                                                // X'lerin artmaya basladigi yer sadece Startta 1 defa
    }

    public void CurrentMoneyChooser50() // 50$ ekleme butonu
    {
        if (waitingForNextRound == false || isBetted == true)
            return;

        if (currentMoney + 50 <= totalMoney)
        {
            currentMoney = currentMoney + 50;
        }
    }

    public void CurrentMoneyChooser100() // 100$ ekleme butonu
    {
        if (waitingForNextRound == false || isBetted == true)
            return;

        if (currentMoney + 100 <= totalMoney)
        {
            currentMoney = currentMoney + 100;
        }
    }

    public void CurrentMoneyChooser500() // 500$ ekleme butonu
    {
        if (waitingForNextRound == false || isBetted == true)
            return;

        if (currentMoney + 500 <= totalMoney)
        {
            currentMoney = currentMoney + 500;
        }
    }

    public void Bet()  // Bet Butonu
    {
        if (isBetted)
            return;

        totalMoney = totalMoney - currentMoney;
        isBetted = true;
    }
}