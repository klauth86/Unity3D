using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FPS.Player {
    public class Player_Inventory : Subscriber_Base<Player_Master> {
        [SerializeField] private Transform _inventoryPlayerParent;
        [SerializeField] private Transform _inventoryUIParent;
        [SerializeField] private GameObject _uiButton;

        [SerializeField] private Transform _itemHeldInHands;
        [SerializeField] private float _timeToPlaceInHands = 0.1f;
        [SerializeField] private int counter;

        private List<Transform> _inventoryItems = new List<Transform>();

        private void OnEnable() {
            Master.ChangeInventoryEvent += UpdateInventoryItemsAndUI;
            Master.ChangeInventoryEvent += CheckNothingInHands;
            Master.EmptyHandsEvent += ClearHands;
        }

        private void OnDisable() {
            Master.ChangeInventoryEvent -= UpdateInventoryItemsAndUI;
            Master.ChangeInventoryEvent -= CheckNothingInHands;
            Master.EmptyHandsEvent -= ClearHands;
        }

        private void UpdateInventoryItemsAndUI() {
            counter = 0;
            _inventoryItems.Clear();
            _inventoryItems.TrimExcess();

            ClearInventoryUI();

            foreach (Transform item in _inventoryPlayerParent) {
                if (item.CompareTag("Item")) {
                    _inventoryItems.Add(item);
                    var go = Instantiate(_uiButton);
                    go.GetComponentInChildren<Text>().text = item.name;
                    var index = counter;
                    go.GetComponent<Button>().onClick.AddListener(() => { ActivateInventoryItemByIndex(index); });
                    go.GetComponent<Button>().onClick.AddListener(() => { Master.Manager_ToggleInventoryUI.ToggleInventoryUI(); });
                    go.transform.SetParent(_inventoryUIParent, false);
                    counter++;
                }
            }
        }

        private void CheckNothingInHands() {
            if (_itemHeldInHands == null && _inventoryItems.Count > 0) {
                StartCoroutine(PlaceInHandsRoutine(_inventoryItems[_inventoryItems.Count - 1]));
            }
        }

        private void ClearHands() {
            _itemHeldInHands = null;
        }

        void ClearInventoryUI() {
            foreach (Transform item in _inventoryUIParent) {
                Destroy(item.gameObject);
            }
        }

        void ActivateInventoryItemByIndex(int index) {
            DeactivateAllInventoryItems();
            StartCoroutine(PlaceInHandsRoutine(_inventoryItems[index]));
        }

        void DeactivateAllInventoryItems() {
            foreach (Transform item in _inventoryPlayerParent) {
                if (item.CompareTag("Item")) {
                    item.gameObject.SetActive(false);
                }
            }
        }

        IEnumerator PlaceInHandsRoutine(Transform item) {
            yield return new WaitForSeconds(_timeToPlaceInHands);
            _itemHeldInHands = item;
            item.gameObject.SetActive(true);
        }
    }
}