using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RandomXScript : MonoBehaviour
{
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
    }

    public void CurrentMoneyChooser100()
    {
        if (waitingForNextRound == false)
            return;

        if (add100Money == false)
        {
            currentMoney = 0;
        }
        currentMoney = currentMoney + 100;
        add100Money = true;
        add250Money = false;
        add500Money = false;
    }

    public void CurrentMoneyChooser250()
    {
        if (waitingForNextRound == false)
            return;

        if (add250Money == false)
        {
            currentMoney = 0;
        }
        currentMoney = currentMoney + 250;
        add100Money = false;
        add250Money = true;
        add500Money = false;
    }

    public void CurrentMoneyChooser500()
    {
        if (waitingForNextRound == false)
            return;

        if (add500Money == false)
        {
            currentMoney = 0;
        }
        currentMoney = currentMoney + 500;
        add100Money = false;
        add250Money = false;
        add500Money = true;
    }
}