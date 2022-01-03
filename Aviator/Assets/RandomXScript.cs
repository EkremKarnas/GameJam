using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RandomXScript : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI Xtext;
    [SerializeField]
    TextMeshProUGUI totalMoneyText;

    [SerializeField]
    TextMeshProUGUI betMoneyText;
    private float deltaTime;
    private float timeScale = 5;
    private bool getTheReward = false;
    private bool endOfSession = false;

    [SerializeField]
    float currentMoney;
    [SerializeField]
    float totalMoney;
    private float addMoney;
    private float randomNum;
    void Start()
    {
        RandomGenerator();
        Debug.Log(randomNum);
        deltaTime = 1f;
    }


    void Update()
    {
        // Debug.Log("Total Money : " + totalMoney);
        // Debug.Log("Current Money : " + currentMoney);

        Xtext.text = deltaTime.ToString("0.00") + "x";
        totalMoneyText.text = "Total Money : " + totalMoney.ToString();
        betMoneyText.text ="Bet Money : " + currentMoney.ToString();

        if (deltaTime <= randomNum)
        {
            deltaTime += Time.deltaTime / timeScale;
        }
        else
        {
            if (endOfSession == false)
            {
                // currentMoney = 0f;
                // getTheReward = true;
                if (getTheReward == false)
                {
                    totalMoney = totalMoney - currentMoney;
                }
                endOfSession = true;
                StartCoroutine(WaitFiveSeconds());
            }
        }
    }

    void RandomGenerator()
    {
        randomNum = Random.Range(1f, 5f);
    }

    public void GetTheReward()
    {
        if (getTheReward == true)
            return;

        getTheReward = true;
        addMoney = currentMoney * deltaTime;
        totalMoney = totalMoney + addMoney;
        // currentMoney = 0;
    }

    IEnumerator WaitFiveSeconds()
    {
        yield return new WaitForSeconds(5);
        deltaTime = 1f;
        RandomGenerator();
        getTheReward = false;
        endOfSession = false;
        Debug.Log(randomNum);
        // currentMoney = 0;
    }

    public void CurrentMoneyChooser100()
    {
        currentMoney = 100;
    }

    public void CurrentMoneyChooser250()
    {
        currentMoney = 250;
    }

    public void CurrentMoneyChooser500()
    {
        currentMoney = 500;
    }
}