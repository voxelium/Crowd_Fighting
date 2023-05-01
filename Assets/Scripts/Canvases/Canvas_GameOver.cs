using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Canvas_GameOver : MonoBehaviour
{
    [SerializeField] KillArea killArea;

    private Canvas _canvasGameOver;

    private void OnEnable()
    {
        killArea.EventGameOver += ShowCanvasGameOver;
    }

    private void Awake()
    {
       _canvasGameOver = GetComponent<Canvas>();
       _canvasGameOver.enabled = false;
    }

    private void OnDisable()
    {
        killArea.EventGameOver -= ShowCanvasGameOver;
    }

    private void ShowCanvasGameOver()
    {
        _canvasGameOver.enabled = true;
    }

    public void PlayButtonPressed()
    {
        SceneManager.LoadScene("GameScene");
        //Debug.Log("кнопка нажата");
    }

}
