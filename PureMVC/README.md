```tex
Unity version: 2020.3.14f1
```

# 前言
這個例子是對照[PureMVC框架在Unity中的應用例子](https://github.com/kenrivcn/PureMVC_Demo)開發的。

PureMVC框架是依照[Github - PureMVC](https://github.com/PureMVC/puremvc-csharp-standard-framework)來重新編寫了一遍。因為作者認為，跟著寫會加深印象以及理解(邊寫邊思考)。

另外MVC框架個人認為在游戲中的主要應用是在UI層面上的。Model中的數據可以通過Proxy來隔離，這樣在設計UI系統時也不會影響到原先的Model。

# 介紹
PureMVC是MVC框架的一種實現，它在MVC的基础上引入了4種設計模式
- Proxy
- Mediator
- Command
- Facade

來使結構達到解耦極限。

PureMVC的核心三大類分別是View、Controller、Model。他們分別對應各自的相當於是Manager類的責任，都有Register、Unregister、Retrieve等的操作。

PureMVC整體的交互是通過`Notification`進行的。每一個`Command`都與一個`Notification`對應。當需要執行某一個`Command`時，會先觸發通知，再由`Controller`來新成對應的`Command`執行操作。
另外每一個Mediator都會對某些`Notification`感興趣，也可以往View中注冊`Observer`來監聽對應的`Notification`。

PureMVC在Model層上再引入了Proxy層，在View層上再引入了Mediator層，在Controller層上引入了Command層。這些設計模式都相對於一個中間人，對用戶隱藏了與實際的類交互的細節。

## PureMVC的模塊
### Mediator & View
每一個Mediator對應一個UI頁面，而Mediator中會有一個ListNotifications，包含了這個Mediator所感興趣的Notification，在創建的時候就會自動地在View上注冊Observer。並且會有一個名為HandleNotification的方法作為callback。

由於Mediator會很頻繁訪問Proxy以及UI，所以Mediator會保留Proxy和UI的引用，方便使用。

### Command & Controller

所有對應的操作都是通過Command來實現的，例如刷新UI，啟動程序，顯示UI等等。

Command可以通過Facade訪問到Controller、View、Model。可以發送Notification或執行其它的Command。

### Proxy & Model

Proxy是封裝了對Model的一系列的操作的一個代理者。提供了訪問或操作Model的接口。

另外Proxy只會發送Notification，因為Proxy或者Model不會因為Mediator的改變而導致發生改變。

### Notifiacation
PureMVC中包含了Notifier、Observer以及Notification三個類來實現通知系統。

發送者通過Facade的SendNotification接口，發送對應的Notification，而View就會接受到通知，並且通知所有在監聽讓事件的Observers。如果是Command所對應的通知，那麼就會執行Controller中的`ExecuteCommand`。

### Facade
是Controller、View、Model的一個管理者，他提供了所有接口，除了Command會用到外，也方便外部的調用，例如在例子中的Application就調用了Facade中的Launch，來執行啟動的操作。

# 例子中的流程
- Application.cs 是整個App的入口。它會調用MyFacade中的Launch來啟動框架
    - Facade在創建時會自動初始化Controller、View、Model
- 在MyFacade中會注冊所需的Command以及Proxy，然後發送`START_UP`的Notification
- `START_UP`事件會執行StartUpCommand，注冊Mediator並顯示頁面，第一次調用時會發送
    - `REFRESH_REWARD_POOL` : 刷新獎品池
    - `REFRESH_PLAYE_DATA` :刷新用戶數據
    - `REFRESH_REWARD_UI` : 刷新獎品池UI
- 當點擊"隨機獲取"後，發送`PLAY`事件，執行PlayCommand，獲得隨機的獎品，並且發送
    - `REFRESH_REWARD_POOL` : 刷新獎品池
    - `REFRESH_REWARD_UI` : 刷新獎品池UI
    - `REWARD_TIP_UI` : 顯示提示UI
    - `REFRESH_PLAYER_DATA` : 刷新用戶數據

# 在學習過程中遇到的問題以及思考
Q. 為甚麼在Model層中的是Proxy? 而在View層中的是Mediator?

A. Proxy相當於Model，它與Model是同源的，是Model的一個代理人。Proxy與Model之間的交互不會有第三者的參與。而Mediator所封裝的是對象與對象之間的交互，它不是View的代理人，而是一個中介，對象的操作可能需要調用第三者的函數。

Q. 為甚麼Command也要在View中注冊Observer?

A. 個人認為是為了方便管理。Controller在接受到通知後，創建Command，並執行。因此，Controller也需要Observer來監聽事件。而監聽的責任已經全部交由View來處理，所以Controller中的監聽也放到View中管理。


# 參考資料
- [Github - PureMVC](https://github.com/PureMVC/puremvc-csharp-standard-framework)
- [Official - PureMVC](http://puremvc.org/)
- [PureMVC框架在Unity中的應用(一)](https://gameinstitute.qq.com/community/detail/127468)
- [PureMVC框架在Unity中的應用(二)](https://gameinstitute.qq.com/community/detail/127518)
- [PureMVC框架在Unity中的應用例子](https://github.com/kenrivcn/PureMVC_Demo)