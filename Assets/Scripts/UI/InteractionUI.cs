using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionUI : MonoBehaviour
{
    [SerializeField] private GameController _gameController;
    [SerializeField] private ShopPanel _shopPanel;
    [SerializeField] private Button _reloadButton;
    [SerializeField] private Button _inventoryButton;
    [SerializeField] private Button _closeInventoryButton;

    private void OnEnable()
    {
        _gameController.GameOvered += TurnOnButtonReload;
        _inventoryButton.onClick.AddListener(() => PressButtonInventory(_shopPanel));
        _closeInventoryButton.onClick.AddListener(() => PressButtonInventory(_shopPanel));
        _reloadButton.onClick.AddListener(PressButtonReload);
    }

    private void OnDisable()
    {
        _gameController.GameOvered -= TurnOnButtonReload;
        _inventoryButton.onClick.RemoveListener(() => PressButtonInventory(_shopPanel));
        _closeInventoryButton.onClick.RemoveListener(() => PressButtonInventory(_shopPanel));
        _reloadButton.onClick.RemoveListener(PressButtonReload);
    }

    private void TurnOnButtonReload()
    {
        _reloadButton.gameObject.SetActive(true);
    }

    private void PressButtonInventory(ShopPanel inventory)
    {
        if (inventory.gameObject.activeSelf == false)
        {
            inventory.gameObject.SetActive(true);
            _gameController.PauseGame();
        }
        else
        {
            inventory.gameObject.SetActive(false);
            _gameController.TurnOffPause();
        }
    }

    private void PressButtonReload()
    {
        _gameController.ReloadGame();
    }
}
