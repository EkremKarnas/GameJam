using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float currentTime;
    public float startingTime = 5f;

    [SerializeField]
    TextMeshProUGUI countdownText;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime <= 0)
            return;

        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");
    }
}
