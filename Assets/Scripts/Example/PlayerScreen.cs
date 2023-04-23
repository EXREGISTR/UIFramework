﻿using TMPro;
using UIFramevork;
using UnityEngine;
using UnityEngine.UI;

namespace Example {
	public class PlayerScreen : Screen<PlayerViewHandler> {
		[SerializeField] private Button playButton;
		[SerializeField] private Button changeNameButton;
		[SerializeField] private Button addMoneyButton;
		[SerializeField] private TMP_Text moneyAmountText;
		
		protected override void OnHandlerBinded() {
			playButton.onClick.AddListener(handler.OnPlayClicked);
			addMoneyButton.onClick.AddListener(handler.OnAddMoneyClicked);
			changeNameButton.onClick.AddListener(handler.OnSetupNameClicked);
		}

		public override void Dispose() {
			playButton.onClick.RemoveAllListeners();
			addMoneyButton.onClick.RemoveAllListeners();
			changeNameButton.onClick.RemoveAllListeners();
		}

		public void UpdateMoneyAmount(int value) {
			moneyAmountText.text = $"Money: {value}";
		}

		public void ChangeNameVisibility(bool value) {
			changeNameButton.gameObject.SetActive(value);
		}
	}
}