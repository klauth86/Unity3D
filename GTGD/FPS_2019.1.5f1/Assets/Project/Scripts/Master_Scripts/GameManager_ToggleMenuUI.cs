﻿using UnityEngine;

namespace FPS.Master {
    public class GameManager_ToggleMenuUI : GameManager_Base {
        [SerializeField]private GameObject _menuUI;

        private void OnEnable() {
            Master.GameOverEvent += ToggleMenuUI;
            Master.InputKeyUpEvent += KeyToggleMenuUI;
        }

        private void OnDisable() {
            Master.GameOverEvent -= ToggleMenuUI;
            Master.InputKeyUpEvent -= KeyToggleMenuUI;
        }

        private void KeyToggleMenuUI(KeyCode key) {
            if (key == KeyCode.M && !Master.IsInventoryUIOn && !Master.IsGameOver)
                ToggleMenuUI();

        }

        private void ToggleMenuUI() {
            if (_menuUI) {
                _menuUI.SetActive(!_menuUI.activeSelf);
            }
            else {
                Debug.LogWarning("MenuUI is not set!");
            }
            Master.IsMenuUIOn = !Master.IsMenuUIOn;
            Master.CallToggleMenuUIEvent();
        }
    }
}