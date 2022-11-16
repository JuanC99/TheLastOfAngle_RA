using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : MonoBehaviour
{
    [SerializeField] private int maxRounds = 3;
    [SerializeField] private int itemsRemaining = 5;
    [SerializeField] float maxTimePerRound = 60f * 5f; // 5 minutos
    float timeToEnd;
    private int currentRound = 1;
    private int currentItemsRemaining = 0;

    private bool started = false;

    // Boton para empezar la partida
    public void StartGame()
    {
        started = true;
    }
    // Boton para terminar la partida
    public void FinishGame()
    {
        started = false;
    }
    // Añade un item recogido
    public void AddItemToInventory()
    {
        currentItemsRemaining = currentItemsRemaining + 1;
    }

    void Start()
    {
        timeToEnd = maxTimePerRound;
        currentItemsRemaining = 0;
    }

    void Update()
    {
        if (started)
        {
            RoundListener();
            Finish();
        }
    }
    void FixedUpdate()
    {
        if (started)
        {
            TimeLitener();
        }
    }
    // Escucha el timer
    void TimeLitener()
    {
        timeToEnd = timeToEnd - Time.time;
        if (timeToEnd <= 0)
        {
            GameLost();
        }
    }

    // Escucha las rondas
    private void RoundListener()
    {

        if (currentItemsRemaining == itemsRemaining)
        {
            ChangeRound();
        }
    }

    // Cambia la ronda
    private void ChangeRound()
    {
        ResetRound();
        currentRound = currentRound + 1;
    }

    // Resetea la ronda
    private void ResetRound()
    {
        timeToEnd = maxTimePerRound;
        currentItemsRemaining = itemsRemaining;
    }

    // termina la partida
    private void Finish()
    {
        if (currentRound > 3)
        {
            started = false;
            Debug.Log("GameCompleted");
        }
    }

    // Has perdido
    private void GameLost()
    {
        started = false;
        Debug.Log("GameCompleted");
    }


}
