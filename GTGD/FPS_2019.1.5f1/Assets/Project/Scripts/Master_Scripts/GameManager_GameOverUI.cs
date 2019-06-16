﻿using UnityEngine;

namespace FPS.Master {
    public class GameManager_GameOverUI : GameManager_Base {
        [SerializeField]private GameObject _gameOverUI;

        private void OnEnable() {
            Master.GameOverEvent += ToggleGameOver;
        }

        private void OnDisable() {
            Master.GameOverEvent -= ToggleGameOver;
        }

        private void ToggleGameOver() {
            if (_gameOverUI) {
                _gameOverUI.SetActive(!_gameOverUI.activeSelf);
            }
            else {
                Debug.LogWarning("GameOverUI is not set!");
            }
        }
    }
}