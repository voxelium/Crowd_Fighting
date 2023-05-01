using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Canvas_Game : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _currentVolume;
    [SerializeField] GameMode gameMode;

    private Canvas _gameCanvas;

    private void Start()
    {
        _gameCanvas = GetComponent<Canvas>();
        _gameCanvas.enabled = true; 
    }

    private void OnEnable()
    {
      //gameMode.EventCurrentVolumeUpdate += PrintVolume;
      //gameMode.EventGameOver += HideGameCanvas;
      //gameMode.EventGameWin += HideGameCanvas;
      
    }

    private void OnDisable()
    {
        //gameMode.EventCurrentVolumeUpdate -= PrintVolume;
        //gameMode.EventGameOver -= HideGameCanvas;
        //gameMode.EventGameWin -= HideGameCanvas;
    }

    private void PrintVolume(int volume)
    {
        _currentVolume.text = volume.ToString();
    }

    private void HideGameCanvas(int volume)
    {
        _gameCanvas.enabled = false;
    }

}
