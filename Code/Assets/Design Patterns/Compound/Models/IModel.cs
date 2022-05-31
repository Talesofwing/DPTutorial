public interface IModel {
    void Initialize ();
    void RegisterObserver (IObserver observer);
    void UnregisterObserver (IObserver observer);
}
