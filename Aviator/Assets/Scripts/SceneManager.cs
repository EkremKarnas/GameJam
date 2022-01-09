using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManager : MonoBehaviour
{
    public static SceneManager instance;

    Scene scene;
    private int sceneNo;

    public float bankMoney;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        bankMoney = 1000f;
        sceneNo = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        if (sceneNo == 0)
        {
            StartCoroutine(LoadNextScene());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(5f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
