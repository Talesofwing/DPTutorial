using UnityEngine;
using UnityEngine.UI;

public class RewardTipView : MonoBehaviour {
    [SerializeField] private Text _contextText;
    [SerializeField] private Button _backButton;

    public Button BackButton {
        get => _backButton;
    }
    
    public void SetText (string context) {
        _contextText.text = context;
    }

}
