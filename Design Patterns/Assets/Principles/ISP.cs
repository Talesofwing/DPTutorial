// IFly
public interface IFly {
    void Fly ();
}

// IAnimal
public interface IAnimal {
    void Speak ();

    // Fly 拆出來
    // void Fly ();
}

// Cat
public class Cat : IAnimal {
    
    public void Speak () { 
        // do something
    }

}

// Bird
public class Bird : IAnimal, IFly {
    
    public void Speak () { 
        // do something
    }

    public void Fly () {
        // do something
    }
    
}