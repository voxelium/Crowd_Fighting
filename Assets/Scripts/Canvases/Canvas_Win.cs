using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Canvas_Win : MonoBehaviour
{
    //[SerializeField] TextMeshProUGUI _winVolume;
    [SerializeField] private GameMode gameMode;

    private Canvas _canvasWin;

    private void OnEnable()
    {
      gameMode.EventGameWin += ShowWinCanvas;
    }

    private void Awake()
    {
       _canvasWin = GetComponent<Canvas>();
       _canvasWin.enabled = false;
    }

    private void OnDisable()
    {
       gameMode.EventGameWin -= ShowWinCanvas;
    }

    private void ShowWinCanvas()
    {
        _canvasWin.enabled = true;
        //_winVolume.text = volume.ToString();
    }

    public void PlayButtonPressed()
    {
        SceneManager.LoadScene("GameScene");
        //Debug.Log("кнопка нажата");
    }

}
