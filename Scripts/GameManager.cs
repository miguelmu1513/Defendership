using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public AudioSource SonidoDeFondo;
    public TextMeshProUGUI StarShip;
    public TextMeshProUGUI Enemy;
    public GameObject Lose;  // Prefab para el texto "Game Over"
    public GameObject Winner;    // Prefab para el texto "Winner"
    public Transform canvasTransform;      // Transform del Canvas para mostrar los mensajes
    public int score = 0;
    public int missed = 0;

    void Start()
    {
        ActualizarScore();
        ActualizarMissed();
    }

    public void IncrementarScore(int cantidad)
    {
        score += cantidad;
        ActualizarScore();

        if (score >= 100)
        {
            MostrarWinner();
        }
    }

    public void IncrementarMissed(int cantidad)
    {
        missed += cantidad;
        ActualizarMissed();

        if (missed >= 10)
        {
            MostrarGameOver();
        }
    }

    void ActualizarScore()
    {
        if (StarShip != null)
        {
            StarShip.text = "StarShip: " + score.ToString();
        }
        else
        {
            Debug.LogError("Score Text no está asignado en el Inspector.");
        }
    }

    void ActualizarMissed()
    {
        if (Enemy != null)
        {
            Enemy.text = "FlyShip: " + missed.ToString();
        }
        else
        {
            Debug.LogError("Missed Text no está asignado en el Inspector.");
        }
    }

    void MostrarGameOver()
    {
        Debug.Log("¡Juego Terminado! Has perdido.");
        Time.timeScale = 0; // Pausa el juego

        if (SonidoDeFondo != null)
        {
            SonidoDeFondo.Stop(); // Detiene la música de fondo
        }

        if (Lose != null && canvasTransform != null)
        {
            Instantiate(Lose, canvasTransform);
        }
    }

    void MostrarWinner()
    {
        Debug.Log("¡Felicidades! Has ganado.");
        Time.timeScale = 0; // Pausa el juego

        if (SonidoDeFondo != null)
        {
            SonidoDeFondo.Stop(); // Detiene la música de fondo
        }

        if (Winner != null && canvasTransform != null)
        {
            Instantiate(Winner, canvasTransform);
        }
    }

    public void DispararProyectil()
    {
        NaveDefensora naveDefensora = FindObjectOfType<NaveDefensora>();
        if (naveDefensora != null)
        {
            naveDefensora.Disparar();
        }
    }
}