using UnityEngine;
using UnityEngine.UI;

public class MainPanelView : MonoBehaviour {
    [SerializeField] private Button _getButton;
    [SerializeField] private GameObject _bonusItemTemplate;
    [SerializeField] private Text _countText;
    [SerializeField] private Text _rewardAmountText;
    [SerializeField] private RectTransform _itemsRoot;

    public Button GetButton {
        get => _getButton;
    }
    
    public GameObject BonusItemTemplate {
        get => _bonusItemTemplate;
    }

    public RectTransform ItemsRoot {
        get => _itemsRoot;
    }
    
    public void UpdateGamePlayCount (int val) {
        _countText.text = val.ToString ();
    }

    public void UpdateRewardTotal (int val) {
        _rewardAmountText.text = val.ToString ();
    }
    
}
