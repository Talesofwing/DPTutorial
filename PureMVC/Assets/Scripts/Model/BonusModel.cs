public class BonusModel {
    public int ID { get; set; }
    public string Name { get; set; }
    public int Reward { get; set; }

    
    public BonusModel (int id, string name, int reward) {
        ID = id;
        Name = name;
        Reward = reward;
    }
    
}