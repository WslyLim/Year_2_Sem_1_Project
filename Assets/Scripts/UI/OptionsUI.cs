using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour{
	
	public static OptionsUI Instance {  get; private set; }
	
	[SerializeField] private Button soundEffectsButton;
	[SerializeField] private Button musicButton;
	[SerializeField] private Button closeButton;
	[SerializeField] private TextMeshProUGUI soundEffectsText;
	[SerializeField] private TextMeshProUGUI musicText;

	
	
	private void Awake() {
		Instance = this;
		soundEffectsButton.onClick.AddListener(() => {
			SoundManager.Instance.ChangeVolume();
			UpdateVisual();
		});
		musicButton.onClick.AddListener(() => {
			MusicManager.Instance.ChangeVolume();
			UpdateVisual();
		});
        closeButton.onClick.AddListener(() => {
            Hide();
        });
		
    }
	
	private void Start() {
		UpdateVisual();

		Hide();
	}
	
	private void GameManager_OnGameUnpaused(object sender, System.EventArgs e) {
		Hide();
	}
	
	private void UpdateVisual() {
		soundEffectsText.text = "Sound Effects: " + Mathf.Round(SoundManager.Instance.GetVolume() * 10f);
		musicText.text = "Music: " + Mathf.Round(MusicManager.Instance.GetVolume() * 10f);

    }
	public void Show() {
		gameObject.SetActive(true);
	}

	private void Hide() {
		gameObject.SetActive(false);
	}

}
