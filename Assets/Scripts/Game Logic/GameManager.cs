using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using vnc;
using vnc.Samples;

public class GameManager : MonoBehaviour
{
    private PlayerController Player;
    private RetroController RetroController;
    private MouseLook MouseLook;
    private bool isPaused;
    public GameEvent PauseTriggered;
    public GameEvent UnpauseTriggered;


    private void Awake()
    {
        Player = FindObjectOfType<PlayerController>();
        MouseLook = Player.GetComponent<InputManager>().mouseLook;
        RetroController = Player.GetComponent<RetroController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //if starting new game/episode run this
        InitialisePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForPause();
    }

    void InitialisePlayer() 
    {
        Player.CurrentHealth = Player.TotalHealth;
        Player.CurrentArmour = 0;
    }

    void CheckForPause() 
    {
        if (Player.GetComponent<InputManager>().Escape.triggered && !isPaused)
        {
            MouseLook.SetCursorLock(!MouseLook.lockCursor);
            RetroController.updateController = !RetroController.updateController;
            PauseTriggered.Raise();
            isPaused = true;
        }
        else if(Player.GetComponent<InputManager>().Escape.triggered && isPaused)
        {
            MouseLook.SetCursorLock(!MouseLook.lockCursor);
            RetroController.updateController = !RetroController.updateController;
            UnpauseTriggered.Raise();
            isPaused = false;
        }
    }
}
