using UnityEngine;

public class MyFacade : PureMVC.Patterns.Facade.Facade {
    public const string START_UP = "START_UP";
    public const string CREATE_BONUS_ITEMS = "CREATE_BONUS_ITEMS";
    public const string REFRESH_BONUS_ITEMS = "REFRESH_BONUS_ITEMS";
    public const string UPDATE_PLAYER_DATA = "UPDATE_PLAYER_DATA";
    public const string PLAY = "PLAY";
    public const string REFRESH_BONUS_UI = "REFRESH_BONUS_UI";
    public const string UPDATE_REWARD_TIP_VIEW = "UPDATE_REWARD_TIP_VIEW";
    public const string REWARD_TIP_VIEW = "REWARD_TIP_VIEW";

    static MyFacade () {
        instance = new MyFacade ();
    }

    public static MyFacade GetInstance () {
        return instance as MyFacade;
    }

    public void Launch () {
        Debug.Log ("Launch");

        SendNotification (MyFacade.START_UP);
    }

    protected override void InitializeController () {
        base.InitializeController ();

        RegisterCommand (START_UP, ()=>new StartUpCommand());
        RegisterCommand (REFRESH_BONUS_ITEMS, () => new RefreshRewardPoolCommand());
        RegisterCommand (PLAY, () => new PlayCommand());
        RegisterCommand (REWARD_TIP_VIEW, () => new RewardTipCommand());
    }
    
    protected override void InitializeModel () {
        base.InitializeModel ();
        
        RegisterProxy (new BonusProxy (BonusProxy.NAME));
        RegisterProxy (new PlayerDataProxy (PlayerDataProxy.NAME));
    }
    
}
