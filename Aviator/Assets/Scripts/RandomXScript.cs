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
    private float deltaTime; // XTextte yazan sayı
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
        // RandomGenerator();
        // Debug.Log(randomNum);
        // deltaTime = 1f;
        StartCoroutine(WaitFiveSeconds());
    }


    void Update()
    {
        Xtext.text = deltaTime.ToString("0.00") + "x";
        totalMoneyText.text = "Total Money : " + totalMoney.ToString();
        betMoneyText.text = "Bet Money : " + currentMoney.ToString();

        if (deltaTime <= randomNum)
        {
            deltaTime += Time.deltaTime / timeScale;
            // cancelButton.SetActive(false); //Last Added
            // betButton.SetActive(true); //Last Added
        }
        else
        {
            if (endOfSession == false)
            {
                if (getTheReward == false)
                {
                    totalMoney = totalMoney - currentMoney;
                }
                endOfSession = true;
                StartCoroutine(WaitFiveSeconds());
                timer.SetActive(true);
                waitingForNextRound = true;
                isBetted = false;
                currentMoney = 0; // Last Added
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
    }

    public void CurrentMoneyChooser50()
    {
        if (waitingForNextRound == false || isBetted == true)
            return;

        // if (add100Money == false)
        // {
        //     currentMoney = 0;
        // }
        if (currentMoney + 50 <= totalMoney)
        {
            currentMoney = currentMoney + 50;
        }
        // add100Money = true;
        // add250Money = false;
        // add500Money = false;
    }

    public void CurrentMoneyChooser100()
    {
        if (waitingForNextRound == false || isBetted == true)
            return;

        // if (add250Money == false)
        // {
        //     currentMoney = 0;
        // }
        if (currentMoney + 100 <= totalMoney)
        {
            currentMoney = currentMoney + 100;
        }
        // add100Money = false;
        // add250Money = true;
        // add500Money = false;
    }

    public void CurrentMoneyChooser500()
    {
        if (waitingForNextRound == false || isBetted == true)
            return;

        // if (add500Money == false)
        // {
        //     currentMoney = 0;
        // }
        if (currentMoney + 500 <= totalMoney)
        {
            currentMoney = currentMoney + 500;
        }
        // add100Money = false;
        // add250Money = false;
        // add500Money = true;
    }

    public void Bet()
    {
        if (isBetted)
            return;

        totalMoney = totalMoney - currentMoney;
        isBetted = true;
        // cancelButton.SetActive(true);
        // betButton.SetActive(false);

    }

    // public void CancelBet()
    // {
    //     isBetted = false;
    //     cancelButton.SetActive(false);
    //     betButton.SetActive(true);
    //     totalMoney = totalMoney + currentMoney;
    //     currentMoney = 0;
    // }
}