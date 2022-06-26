using System.Collections.Generic;
using PureMVC.Patterns.Proxy;
using UnityEngine;

public class BonusProxy : Proxy {
    public new static string NAME = "BONUS";
    
    private List<BonusModel> _bonusLists = new List<BonusModel> ();

    private static string[] REWARD_NAME = new string[] {"金创药", "薄荷叶", "橡木果", "圣灵药", "还魂丹", "解毒药"};
    private static int[] REWARD_PRICE = new int[] {100, 300, 500, 800, 1200};

    public int BonusCount {
        get => _bonusLists.Count;
    }

    public BonusModel[] BonusLists {
        get => _bonusLists.ToArray ();
    }
    
    public BonusProxy (string proxyName, object data = null) : base (proxyName, data) {}

    public void AddBonus (BonusModel bonus) {
        _bonusLists.Add (bonus);
    }

    public void Clear () {
        _bonusLists.Clear ();
    }

    public void CreateRewardPool (int count) {
        for (int i = 0; i < count; ++i) {
            string name = REWARD_NAME[Random.Range (0, REWARD_NAME.Length)];
            int price = REWARD_PRICE[Random.Range (0, REWARD_PRICE.Length)];
            BonusModel model = new BonusModel(i + 1, name, price);
            _bonusLists.Add (model);
        }
    }

    public override void OnRegister () {
        base.OnRegister ();
        Debug.Log ("BonusProxy OnRegister");
    }

    public override void OnRemove () {
        base.OnRemove ();
        Debug.Log ("BonusProxy OnRemove");
    }
    
}
