using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Elimination : MonoBehaviour
{
    [SerializeField] int vite = 3;
    [SerializeField] TextMeshProUGUI TestoVite;
    [SerializeField] TextMeshProUGUI TestoPunteggio;
    [SerializeField] int punteggio = 0;
    [SerializeField] TextMeshProUGUI Besttime;
    int migliorpunteggio = 0;
    [SerializeField] GameObject gameoverPanel;
    bool gameover = false;

    void Start()
    {
        migliorpunteggio = PlayerPrefs.GetInt("MigliorPunteggio", 0);
        Besttime.text = "Miglior Punteggio: " + migliorpunteggio;
        gameoverPanel.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Eliminator"))
        {
            vite -= 1;
        }
    }

    void Update()
    {
        TestoVite.text = "Vite: " + vite;

        if (!gameover)
        {
            punteggio = Mathf.RoundToInt(-transform.position.y);
            TestoPunteggio.text = "Punteggio: " + punteggio;

            if (punteggio > migliorpunteggio)
            {
                migliorpunteggio = punteggio;
            }

            if (vite <= 0)
            {
                GameOver();
            }
        }
        Besttime.text = "Miglior Punteggio: " + migliorpunteggio;
    }
    void GameOver()
    {
        gameover = true;
        gameObject.SetActive(false);
        PlayerPrefs.SetInt("MigliorPunteggio", migliorpunteggio);
        PlayerPrefs.Save();
        gameoverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void exit()
    {
        Application.Quit();
    }
}