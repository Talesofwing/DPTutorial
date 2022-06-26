// 每一種服務器的登入、數據格式可能都不同
// 所以沒有必要做成class，而是用interface
public interface IServer {
    void Login (string name, string password);
    void Quit ();
    
    void LoginTime ();
    void QuitTime ();
}
