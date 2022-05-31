```tex
Unity version: 2020.3.14f1
```



# 介紹

- 範例以及說明都是作者個人見解，因為沒有大量的項目經驗，所以會有知識點的疏漏以及錯誤。

- 儘量提及每一個模式的`優劣點`以及`相似模式之間的區別`。且例子主要圍繞`游戲`進行思考並開發。

- 在最下方有`模式之間的區別`。

# 前言
- 為甚麼我們要使用`設計模式`? 
  - `模式`是一種`編程思想`，是一種以`OOP`思想解決問題的一種方案。
  - 它是一種在Programmer之間的`語言文法`。
- 大部分的`模式`都有一個共通的缺點，那就是會產生大量的小類，導致項目中存在大量的類。
- `抽象化`，在面向對象以及多人開發中是非常重要的一個觀念。只有抽象化做得好，分工以及互助才能更加順利地進行。
- OOP中的`模式`以及`原則`都是為了解決`多次出現的問題`的一種`標準答案`。且能有效地保持項目的: 
  - 重用性 (Reusability)
  - 靈活性 (Flexibility)
  - 擴展性 (Scalability)
- 要熟練掌握`設計模式`需要花費大量的時間，只有在不斷的探索中才能夠認識設計模式的美妙之處。
- OOP編程中的重要思維方式
  - 找出可能的變化之處，封裝起來，不要與不需要變化的代碼混在一起。
  - 針對接口編程
  - 多用組合，少用繼承;繼承愈多，系統愈複雜
  - 為了交互對象之間的松耦合設計而努力

# 參考資料
> 如果想查看UML圖，那麼在打開URL後，請點擊上方的`使用「diagrams.net」開啟`。

- [各例子 - UML圖](https://drive.google.com/file/d/1CqL6Sq6a-bgfTyaOKfM-8fHHSPiz7__c/view?usp=sharing)
- [各模式 - UML圖](https://drive.google.com/file/d/1D7yD7JGq0hg27aaI119C5fkF-1OxQUXH/view?usp=sharing)
- [UML圖基础](https://drive.google.com/file/d/1BifQQ95Nwhx1cPpAIjn40Tq1Wa2-H9ss/view?usp=sharing)
- [PureMVC](https://github.com/PureMVC/puremvc-csharp-standard-framework)
- Book - 设计模式与游戏完美开发
- Book - Head First Design Patterns
- Book - 大话设计模式
- Video - https://www.sikiedu.com/course/54 (這個教程是基於「设计模式与游戏完美开发」的，建議直接啃書，因為視頻教得很爛...)

建議先看Head First Design Patterns。

# 原則 (Principles)

- **SRP (Single Responsibility Principle, 單一責任原則) :** 一個類應該只有一個改變的理由。
- **DIP (Dependency Inversion Principle, 依賴倒轉原則) :**  不要依賴實現，要依賴接口。
  - **(Hollywood Principle, 好萊塢原則) :** **上層模塊**儘量不要輪詢**下層模塊**。而是使用通知的形式。
- **OCP (Open-Closed Principle, 開放關閉原則) :**  對擴展開放，對修改關閉。
- **CARP (Composition/Aggregate Reuse Principle, 合成/聚合複用原則):** 少用繼承，多用組合。
- **LKP/LOD (Least Knowledge Principle/Law of Demeter, 最少知識原則/迪米特原則) :** 只和自己直接有關系的"朋友"交談。
- **ISP (Interface Segregation Principle, 接口隔離原則) :** 要求儘量將臃腫龐大的接口拆分成更小的和更具體的接口，讓接口中只包含客戶感興趣的方法。
- **LSP (Liskov Substitution Principle, 里氏替換原則) :** 定義了繼承的原則。通俗來講，子類可以擴展父類的功能，但不能改變父類原有的功能。
  1. 子類可以實現父類的抽象方法，但不能覆蓋父類的非抽象方法。
  2. 子類可以擴展自己的方法。
  3. 子類的前置條件不能被加強: 參數不能超過父類的可控範圍
  4. 子類的後置條件不能被削弱: 輸出範圍不能小於父類的輸出



# 設計模式 (Design Patterns)

## 工廠模式 (Factory)

> 簡單工廠 (Simple Factory) : 有時候不被算作一種模式。將對象創建封裝，供多個用戶使用。
>
> 工廠方法 (Factory Method) : 提供一個接口，用於創建相關或依賴對象的家族，而不需要明確指定具體類。
>
> 抽象工廠 (Abstract Factory) : 定義了一個建對象的接口，但由子類來決定要實列化的類是哪一個。工廠方法只讓類把實例化推遲到子類。

**簡單工廠**: 利用`switch`方式來選擇要創建的對象。在C#或Java中可以利用Reflection機制，實現更靈活的工廠。

**工廠方法**: 將`簡單工廠`中會變化的地方抽象化，具體的創建對象算法交由子類實現，而基類只提供接口供用戶使用。

**抽象工廠**: 簡單來說就是`工廠方法`的集合。

- 需要注意的是容易造成工廠子類爆量的問題。

### 相似模式
1. 建造者模式

## 單例模式 (Singleton)

> 確保一個類只有一個實例，並提供一個全局訪問點。

單例模式很容易被濫用，即俗稱的`單例癖`。

### 單例類 vs. 靜態類

單例類實實在在的是一個"實例"，可以作為參數傳遞。"實例"是在OOP中操作的重要的對象之一，它遵守OOP思想。也就是說，單例類可以「繼承」，有「多態」的特性，能夠「封裝」起來。

### 單例類的創建方式

- 直接在變量中初始化
- 延遲加載 (Lazy Loading)
- 加鎖解決延遲加載的多線程的重覆創建問題
  - 單鎖
  - 多重檢測鎖 (double checked locking)
- 靜態內部類
- .NET Framework 4+中的Lazy<T>，可以實現延遲加載，並且解決多線程的重覆創建問題

### 優點
1. 限制對象的產生數量
2. 方便獲取唯一對象

### 缺點
1. 容易造成設計思考不周，過度使用


## 策略模式 (Strategy)

> 定義了算法族，分別封裝起來，使它們之間可以相互替換，此模式使算法的變化獨立於使用算法的用戶。

通過**聚合**的形式，將會變化的「算法」分別封裝，成為新的算法蔟。這樣的好處是將變化從用戶中分離，達到算法的變化獨立於用戶的效果。並且同一個算法蔟之間，算法可以相互替換。

### 相似模式
1. 橋接模式

### 優點
1. 使變化集中起來統一管理
2. 不必再針對特定的類型編寫代碼，因為可以使用相同的策略
3. 要切換算法時變得很方便。

### 缺點
1. 外部傳進來的參數如何配置是一個難題


## 裝飾者模式 (Decorate)
> 動態地將責任附加到對象上。若要擴展功能，裝飾者提供了比繼承更彈性的替代方案。

將功能一層一層地包裝起來，執行時再一層一層地剝開。可以在不修改原有對象的情況下，為其增加功能。

### 優點
1. 擴展性好，容易添加新功能

### 缺點
1. 裝飾類容易過多

## 觀察者模式 (Observer)
> 定義了對象之間的一對多依頼，這樣一來，當一個對象改變狀態時，它的所有依賴者都會收到通知並且自動更新。

相當於網頁的訂閱系統。訂閱者會自動獲得被訂閱的網站的資訊。

參數的傳遞方式分為
1. 推 (push): 將變動的內容主動"推"給觀察者
2. 拉 (pull): 由觀察者向主題"拉"數據

一般會使用推的形式，如果參數太多的時候，可以使用`struct`來放置所有需要的參數。

### 優點
1. 當發生變動時，會自動向所有觀察者發出通知

### 缺點
1. 參數傳遞方式是一個難點

### 事件與委託 (event & delegate)
> 是觀察者模式的別種。

觀察者模式中主題保存的是觀察者類，而事件與委託則是保存回調函數。


## 模板模式 (Template)

> 在一個方式中定義一個算法的骨架，而將一些步驟延遲到了子類中。模板方式使得子類可以在不改變算法結構的情況下，重新定義算法中的某些步驟。

繼承的其中一種用法。將一套算法中的具體實現延遲到子類中，這樣做的好處是可以使一套算法可以有多種不同的版本。

在渲染過程中的各種Shader，也會提供給程序員去編寫，這其實也相當於是模板模式。同一種流程可以有多個不同的版本。

### 優點
1. 算法流程只會被編寫一次，需要變化的部分則由子類來負責。

## 外觀模式 (Facade)

> 提供了一個統一的接口，用來訪問子系統中的一群接口。外觀定義了一個高層接口，讓子系統更容易使用。

為一些常用的功能創建一個接口(例如: 游戲開始時會創建關卡時的播放音樂、初始化各種系統等)。這樣一來，用戶就不需要與多個系統交互，而是交給外觀類處理，達到解耦的目的。但是，外觀類中的接口，有時候會變得異常龐大，使得維護難度提升。因此，這種模式應該只用於"常用"的功能中，而非一些只在一個地方使用的功能。

### 相似模式
1. 中介者模式
2. 代理模式

### 優點
1. 將責任分離且提供一個統一的接口集合。類似於`GameStart`功能，會與多個系統交互(AudioSystem、LevelSystem...)，利用外觀模式，將這些系統全部封裝起來統一管理，會更方便。
2. 隔離了用戶和子系統的接觸。有一些系統可能需要按照設計好的順序來使用，不然就會出錯。這種設計不應該由用戶來實現，用戶主要的目的就是`使用`。

### 缺點
1. 由於所有子系統都集中在Facade類中，最終會導致Facade類過於龐大且難以維護。


## 適配器模式 (Adapter)

> 將一個類的接口，轉換成客戶的期望的另一個接口。適配器讓原本接口不兼容的類可以合作無間。

相當於多了一個中間件，這一個中間件以"適配器"的身份，負責做兩邊的通信員。與**代理模式**類似。



## 命令模式 (Command)

> 將”請求”封裝成對象，以便使用不同的請求，隊列或者日志來參數化變化對象。命令模式支持可撤銷的操作。

將某些行為(命令)抽象成類群，使行為(命令)的變化獨立於調用者以及接收者，達到解耦的效果。

如果請求並不需要暫存(即立刻執行)，可以不使用命令模式。

### 優點
1. 每一條命令相當於中間者，並保存所需參數，調用者和執行者相互解耦
2. 可以延遲執行 (即緩存)

### 缺點
1. 命令類可能會過多

## 代理模式 (Proxy)

> 為另一個對象提供一個替身或占位符以控制對這個對象的認知。

與**適配器模式**一樣，也是作為一個中間件運作，但是他並不是只負責單一的對象，而是負責多個對象的中間件。能夠自由地切換到任意能代理的對象，令「使用者」與「具體對象」之間解除耦合。

## 橋接模式 (Bridge)

> 將抽象部分與它的實現部分分離，使它們都可以獨立地變化。

將使用者與被使用者之間的關係抽象化成組合關係，使其不會與具體的類相互依賴，達到解耦效果。

### 相似模式
1. 策略模式

### 優點
1. 使兩個群組之間的耦合降低
2. 減少了繼承所帶來的複雜度

## 迭代器模式 (Iterator)

> 提供一種方法順序訪問一個聚合對象中的各個元素，而不暴露其內部的表示。

迭代器可以遍歷訪問容器中的物件，即能對一個**數組(Aggregate)**進行遍歷。

迭代器的屬性一般有:

1. First () : 獲得首元素
2. Next () : 移動到下一個元素
3. IsDone () : 是否已經到達最後的元素
4. Current () : 取得當前的元素

在C#中，提供了`IEnumerator`和`IEnumerable`實現**迭代器模式**。且在C#2.0以上的版本中，在`IEnumerable`加入了`yield return`關鍵字，可以由編譯器自動創建`IEnumerator`的實現，無需手動創建。

## 組合模式 (Composite)

> 允許你將對象組合成樹形結構來表現”整體/部分”層次結構。組合能讓客戶以一致的方式處理個別對象以及對象組合。

**組合模式**中的Leaf與Composite的操作是一致的。在使用者看來，操作一個Leaf與操作一個Composite是沒有分別的。但是在Composite的內部實現中，實際上會調用他的所有**子節點**的方法。

此外，**組合模式**經常與**迭代器模式**一起使用。利用**迭代器**遍歷樹形結構。

Unity下的場景GameObject的管理以及文件管理系統就是很典型的組合模式。

### 安全方法 vs 透明方法

在組合模式中的節點繼承基類方法有兩種形式，一種稱為**安全方法**，另一種稱為**透明方法**。

如果基類有add和remove方法的話，那麼在Leaf中也會持有這兩個方法，但實際上Leaf的add和remove都是沒有用的，這是為了使用者的使用一致性，而不需要判斷節點是Leaf還是Composite。這種繼承方式稱為**透明方法**。**安全方法**則是相反。

## 中介者/調停者模式 (Mediator)

> 用一個中介對象來封裝一系列的對象交互。中介者使各對象不需要顯示地相互引用，從而使其耦合松散，而且可以獨立地改變他們之間的交互。

中介者是負責子系統之間的聯系，減少子系統之間的耦合度。簡單地來說，類似於中央管理的概念。

例如最常見的鍛造系統，背包、鍛造以及配方系統之間的關系會變得很緊密，這時候就可以利用中介者來封裝子系統之間的關係。

### 相似模式
1. 外觀模式
2. 代理模式

### 優點
1. 使每一個子系統對外的依賴縮小到只有一個中介者
2. 每一個子系統被依賴的程度也被縮小到只有一個中介者

### 缺點
1. 由於所有子系統之間的關聯都集中在中介者中，最終會導致中介者過於龐大且難以維護。

## 原型模式 (Prototype)

> 用原型實例指定創建對象的種類，並且通過拷貝這些原型創建新的對象。

簡單地來說，就是對象的Clone。因為`clone`()不會調用`constructor`，所以當類的`constructor`異常複雜時，使用`clone()`會比`new()`更快。

Clone類型:

1. Deep Clone
2. Shallow Clone


## 備忘錄模式 (Memento)

> 在不破壞封裝性的前提下，捕獲一個對象的內部狀態，並在該對象之外保存這狀態。這樣以後就可將該對象恢復到原先保存的狀態。

相當於對象的備份，可以恢復到上一個狀態。例如: Photoshop裏的撤銷功能，時空幻境中時光倒流功能等等，都可以利用**備忘錄模式**。

### 優點
1. 將需要保存的數據抽象成一個類，易於保存和管理
2. 可以存儲多份備份，隨時回檔

## 狀態模式 (State)

> 允許對象在內部狀態改變時改變它的行為，對象看起來好像修改了它的類。

將對象的`狀態`封裝成新的類族，使`改變`從使用者上分離(解耦)，並根據條件`自動`切換狀態。

### 相似模式
1. 策略模式

### 優點
1. 在大部分的"切換"代碼中，`switch`是必不可少的。利用狀態模式，可以在不應用`switch`的情況下完成切換功能，從而減少在新增狀態時所導致的重覆工作以及忘記在`switch`上增加判斷條件的遺漏。
2. 因為每一個狀態相關的對象及操作都被放到一個狀態類下，所以對於Programmer來說，這樣可以更清晰地了解每一個狀態類的功能。
3. 在需要新增一個狀態時，只需要創建一個新的狀態子類並繼承(實現)`IState`便能使用，不需要修改`switch`。

### 缺點
1. 若狀態過多，會產生過多的狀態類的情況。

### 應用
1. Finite State Machine (有限狀態機)


## 解釋器模式 (Interpreter)
> 給定一個語言定義它的文法的一種表示，並定義一個解釋器，這個解釋器使用該表示來解釋語言中句子。

相當於"編譯器"，解釋特定的語言。


## 蠅量/享元模式 (Flyweight)
> 運用共享技術有效地支持大量細粒度的對象。

無論是應用還是游戲，有一些對象的屬性，是不會改變的，當這些對象大量存在於場景中時，這些不變的屬性會造成內存浪費。將這些相同不變的屬性提取出來，使屬性在場景中只存在**一份**，就是Flyweight模式在做的事情。

可以想像游戲中的一個場景有大量的相同的怪物，怪物們的屬性(血量、攻擊力...)不會發生改變，如果每一個怪物都自持一份這些不變的屬性，那麼整個場景就會存在大量沒用的數據，這時候就應該使用享元模式，將這些屬性提取出來。

### 相似應用
1. 對象池(pool)

### 優點
1. 因為只會產生一份，所以減少了內存的負擔

### 缺點
1. 因應不同的設計，可能會導致訪問次數過多，反而導致性能下降。


## 責任/職責鏈模式 (Chain of Responsibility)
> 使多個對象都有機會處理請求，從而避免請求的發送者和接受者之間的耦合關係，將這個對象連成一條鏈，並沿着這條鏈傳递請求，直到有一個對象處理它為止。

負責處理請求方會形成一條單向鏈，如果當前層級沒有能力處理請求，那麼就會往上提交，直到請求被處理完畢。

### 相似模式
1. 命令模式

### 優點
1. 請求方只需要提交請求，處理方就能自動地不斷地往上提交直到處理完畢並返回，可以減少耦合度


## 建造者/生成器模式 (Builder)
> 將一個複雜對象的構建與它的表示分離，使得同樣過程可以創建不同的表示。

將對象的部件，按順序創建並裝戴，最終返回對象的一種模式。例如我們在創建一個角色的時候，會先創建角色整體(model)，然後再創建角色使用的武器或者其它飾品(可以利用工廠模式創建角色以及武器等)，最終將其相互關聯，並返回對象。這種流程還需要一個"指導者"從旁管理。

### 相似模式
1. 工廠模式

### 優點
1. 能將複雜對象的"生成流程"與"功能實現"拆分
2. 生成與功能拆分成兩個模塊，互不干擾。


## 訪問者模式 (Visitor)

> 表示一個作用於某對象結構中的各元素的操作。它使你可以在不改變各元素的類的前提下定義作用於這些元素的新操作。

與`裝飾模式`的作用相同，可以在不改變元素的前提下，增加元素的功能。


### 優點
1. 在不修改對象結構中的元素的情況下，為對象結構中的元素添加新的功能。
2. 通過訪問者來定義整個結構通用的功能。

### 缺點
2. 違反了依賴倒轉原則，因為依賴於具體的類

---

## 模式分類
### 生成模式 (Creational)
產生對象的過程及方式。

1. 工廠模式 (Factory)
2. 單例模式 (Singleton)
3. 建造者模式 (Builder)
4. 原型模式 (Prototype)

### 結構型模式 (Structural)
類或對象之間組合的方式。

1. 適配器模式 (Adapter)
2. 裝飾品模式 (Decorator)
3. 代理模式 (Proxy)
4. 外觀模式 (Facade)
5. 橋接模式 (Bridge)
6. 組合模式 (Composite)
7. 享元模式 (Flyweight)

### 行為模式 (Behavioral)
類或對象之間互動或責任分配的方式。

1. 策略模式 (Strategy)
2. 模板模式 (Template)
3. 觀察者模式 (Observer)
4. 迭代器模式 (Iterator)
5. 責任鏈模式 (Chain of Responsibility)
6. 命令模式 (Command)
7. 備忘錄模式 (Memento)
8. 狀態模式 (State)
9. 訪問者模式 (Visitor)
10. 中介者模式 (Mediator)
11. 解釋器模式 (Interpreter)

---

## 模式之間的區別

### 中介者(Mediator) vs 外觀(Facade) vs 代理(Proxy)

**外觀(Facade):** 系統的接口的集合，這些系統之間沒有任何關聯。例如「打開電視」與「打開音響」兩個動作之間是完全沒有關係的。實際上系統與系統之間並沒有耦合。

**中介者(Mediator):** 是將系統與系統之間的"關聯"封裝起來，使系統與系統之間的耦合降低。此外，當發生改變時，用戶也只需要關心Mediator類。

**代理(Proxy):** 代理與實際的類是同源的，具有相同的成員變量和方法。實際類能做的，代理類也能做。是降低用戶與系統之間的耦合的模式。

### 狀態(State) vs 策略(Strategy)

**狀態(State):** 通過內部的條件判斷`自動地`切換成不同的狀態。

**策略(Strategy):** 有意圖地，由外部控制對象使用哪一種策略。

### 工廠(Factory) vs 建造者(Builder)

**工廠(Factory):** 關注的是產品(product)整體，無須關心產品的各部件(part)是如何創出來的。

**建造者(Builder):** 生產產品(product)是依賴於各個部件(part)的生產以及裝配順序。

在具體的應用中，如果不需要關心產品(product)的部件(part)的創建，那麼就可以用工廠，否則用建造者。

### 策略(Strategy) vs 橋接(Bridge)

**策略(Strategy):** 將變化抽象化成新的族群，使用者不需要關心使用的是哪一種"算法"。

**橋接(Bridge):** 在策略模式的基础上，使用者也會發生變化。A族使用B族，A與B族都會發生變化，A與B也是組合關係。

### 享元(Flyweight) vs 對象池(pool)

兩者都是在保存對象，提供使用。

**享元(Flyweight):** 享元中的對象是共享的，提供給多個對象使用。

**對象池(pool):** 池中的對象一般只提供給單個對象使用。

### 職責(Chain of Responsibility) vs 命令(Command)

**職責(Chain of Responsibility:** 請求的處理是由鏈組成的。

**命令(Command):** 每一條命令都是獨立的。