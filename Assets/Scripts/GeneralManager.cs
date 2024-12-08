using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralManager : MonoBehaviour
{
    public static GeneralManager instance;

    public GameObject KnifePrefab;

    public GameObject GameOverPanel;

    public GameObject GameWinPanel;

    private GameObject instantiatedKnife;

    private float TimeSpeed = 0f;

    private bool isKnifeSpawned = false; 


    void Start()
    {

        instance = this;
        if (KnifePrefab != null && !isKnifeSpawned)
        {
            instantiatedKnife = Instantiate(KnifePrefab, KnifePrefab.transform.position, KnifePrefab.transform.rotation);
            isKnifeSpawned = true;
        }
     
    }

    void Update()
    {
        if (PlayerMove.instance.stuck && isKnifeSpawned)
        {
            instantiatedKnife = Instantiate(KnifePrefab, KnifePrefab.transform.position, KnifePrefab.transform.rotation);

        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;

    }
    public  void  FailPopup()
    {
        GameOverPanel.SetActive(true);

          Invoke("FreezTime", 1f);

    }
    public void WinPopup()
    {
        GameWinPanel.SetActive(true);
          Invoke("FreezTime", 1f);
    }
    void FreezTime()
    {
        Time.timeScale = TimeSpeed;
    }

}

