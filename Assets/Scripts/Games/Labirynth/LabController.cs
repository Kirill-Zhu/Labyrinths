using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Zenject;

public class LabController : MonoBehaviour
{
    [SerializeField] private Lab.LabPlayerController _labPlayerController;
    [Header(" UI properites")]
    public Dialogue _dialogues;
    [SerializeField] private Chuvak _chuvak;
    [SerializeField] private TopText _topText;
    [Header("Pages")]
    [SerializeField] private List<GameObject> _pages;
    [SerializeField] private GameObject _game;
    [Header("Finish Properites")]
    [SerializeField] private TextMeshProUGUI _timerTextMEsh;
    
   
    [SerializeField] private MiniGameManager _miniagmeManager;
    public void GoToMiniGamesMenu()
    {
        _miniagmeManager.OpenGameManagerMenu();
        this.gameObject.SetActive(false);
    }
    public void OpenMainMenu()
    {
        foreach(var p in _pages)
        {
            if (p.activeInHierarchy)
                p.SetActive(false);
        }
        _pages[0].SetActive(true);

        EnableUI();
        _chuvak.ChangeText(_dialogues.Text[0]);           
    }
    [ContextMenu("Start game")]
    public void StartGame()
    {
        foreach (var p in _pages)
        {
            if (p.activeInHierarchy)
                p.SetActive(false);
        }
        _pages[1].SetActive(true);
        DisableUI();

        _labPlayerController.Restart();
    }
    [ContextMenu("Open finish menu")]
    public void FinishGame()
    {
        foreach (var p in _pages)
        {
            if (p.activeInHierarchy)
                p.SetActive(false);
        }
        _pages[2].SetActive(true);

        EnableUI();

        _chuvak.ChangeText(_dialogues.Text[1]);

        _timerTextMEsh.text = string.Format("Отлично! Вы прошли лабиринт за  {0} секунд!",(int)_labPlayerController.Timer);
    }

    private void EnableUI()
    {
        _chuvak.gameObject.SetActive(true);
        _topText.ChangeText("Лабиринты");
        _game.SetActive(false);
    }

    private void DisableUI()
    {
        _chuvak.gameObject.SetActive(false);
        _topText.ChangeText("");
        _game.SetActive(true);
    }

    private void OnEnable()
    {
        OpenMainMenu();
    }
}
