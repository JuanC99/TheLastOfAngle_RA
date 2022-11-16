using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundController : MonoBehaviour
{
    [Header("Round Settings")]
    [SerializeField] private int maxRounds = 3;
    [SerializeField] private int itemsRemaining = 5;
    [SerializeField] float maxTimePerRound = 60f * 5f; // 5 minutos


    [Header("Texts Settings")]
    [SerializeField] private Text textRounds;
    [SerializeField] private Text textTimer;
    [SerializeField] private Text textPieces;


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
    

    void Start()
    {
        timeToEnd = maxTimePerRound;
        currentItemsRemaining = 0;

        textRounds.text = "0 / " + maxRounds.ToString();
        textTimer.text = "00:00";
        textPieces.text = "0 / " + itemsRemaining.ToString();
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

    public void AddItemToInventory()
    {
        currentItemsRemaining = currentItemsRemaining + 1;
        textPieces.text = currentItemsRemaining.ToString() + " / " + itemsRemaining.ToString();
    }

    // Escucha el timer
    void TimeLitener()
    {
        timeToEnd = timeToEnd - Time.time;
        textTimer.text = timeToEnd.ToString();
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
        textRounds.text = currentRound.ToString() + " / " + maxRounds.ToString();
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
