using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundController : MonoBehaviour
{
    [SerializeField] private wormLogic wormLogic;
    [SerializeField] private spawner_controller spawner_Controller;
    [SerializeField] private GameObject gameObjectCoche;

    [Header("Round Settings")]
    [SerializeField] private int maxRounds = 3;
    [SerializeField] private int itemsRemaining = 5;
    [SerializeField] float maxTimePerRound = 60f * 5f; // 5 minutos
    [SerializeField] int numeroPiezasCrear = 3;
    [SerializeField] int numeroPiezasCrearEntreRondas = 3;

    [Header("Texts Settings")]
    [SerializeField] private Text textRounds;
    [SerializeField] private Text textTimer;
    [SerializeField] private Text textPieces;

    [Header("Pantallas Settings")]
    [SerializeField] private GameObject screenDeath;
    [SerializeField] private GameObject screenGameCompleted;


    float timeToEnd;
    private int currentRound = 1;
    private int currentItemsRemaining = 0;

    private bool started = false;
    private bool gameCompleted = false;
    private Vector3 origenCar;

    void Start()
    {
        origenCar = gameObjectCoche.transform.position;
        ResetGame();

    }
    private void ResetGame()
    {
        timeToEnd = maxTimePerRound;
        currentItemsRemaining = 0;
        currentRound = 0;
        gameCompleted = false;
        started = false;
        wormLogic.startedGame = false;
        textRounds.text = "Ronda 0 / " + maxRounds.ToString();
        textTimer.text = "00:00";
        textPieces.text = "0 / " + itemsRemaining.ToString() + " Piezas";
        gameObjectCoche.transform.position = origenCar;
        gameObjectCoche.GetComponent<ControlVehicle>().SetMovOrigen(origenCar);
        ResetPieces();
    }
    private void ResetPieces()
    {
        spawner_Controller.limpiarPiezas();
        spawner_Controller.generarPiezas(numeroPiezasCrear, 2, 15);
    }

    void Update()
    {
        if (started && !gameCompleted)
        {
            RoundListener();
            Finish();
        }
    }
    void FixedUpdate()
    {
        if (started && !gameCompleted)
        {
            TimeLitener();
        }
    }

    // Boton para empezar la partida
    public void StartGame()
    {
        ResetGame();
        started = true;
        wormLogic.startedGame = true;
    }
    // Boton para terminar la partida
    public void FinishGame()
    {
        started = false;
        wormLogic.startedGame = false;
    }

    public void AddItemToInventory()
    {
        currentItemsRemaining = currentItemsRemaining + 1;
        textPieces.text = currentItemsRemaining.ToString() + " / " + itemsRemaining.ToString() + " Piezas";
    }

    // Escucha el timer
    void TimeLitener()
    {
        timeToEnd = timeToEnd - Time.deltaTime;
        textTimer.text = timeToEnd.ToString();
        if (timeToEnd <= 0)
        {
            ResetGame();
            screenDeath.SetActive(true);
        }
    }

    // Escucha las rondas
    private void RoundListener()
    {

        if (currentItemsRemaining == itemsRemaining)
        {
            numeroPiezasCrear = +numeroPiezasCrearEntreRondas;
            ChangeRound();
            ResetRound();
           
        }
    }

    // Cambia la ronda
    private void ChangeRound()
    {
        currentRound = currentRound + 1;
        textRounds.text = "Ronda " + currentRound.ToString() + " / " + maxRounds.ToString();
    }

    // Resetea la ronda
    private void ResetRound()
    {
        timeToEnd = maxTimePerRound;
        currentItemsRemaining = 0;
        textPieces.text = "0 / " + itemsRemaining.ToString() + " Piezas";
        gameObjectCoche.transform.position = origenCar;
        gameObjectCoche.GetComponent<ControlVehicle>().SetMovOrigen(origenCar);
        ResetPieces();
    }

    // termina la partida
    private void Finish()
    {
        if (currentRound > 3)
        {
            started = false;
            wormLogic.startedGame = false;
            gameCompleted = true;
            screenGameCompleted.SetActive(true);
        }
    }

    public void GameLostByWorm()
    {
        ResetGame();
        screenDeath.SetActive(true);
    }

}
