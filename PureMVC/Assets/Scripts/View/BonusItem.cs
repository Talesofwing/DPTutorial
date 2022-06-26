using UnityEngine;
using UnityEngine.UI;

public class BonusItem : MonoBehaviour {
    [SerializeField] private BonusModel _bonusData;
    [SerializeField] private Text _desc;
    [SerializeField] private Image _img;

    public void UpdateItem (BonusModel model) {
        RandomColor ();

        _bonusData = model;
        if (_bonusData != null) {
            _desc.text = _bonusData.Name + "\n" + _bonusData.Reward;
        }
    }

    private void RandomColor () {
        Color[] color = {Color.white, Color.yellow};
        int val = Random.Range (0, color.Length);
        _img.color = color[val];
    }
    
}
