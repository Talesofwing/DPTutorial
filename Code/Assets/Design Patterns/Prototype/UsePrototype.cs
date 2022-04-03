using System.Runtime.InteropServices;
using UnityEngine;

public static class QueryPerformanceMethod {
    [DllImport (("kernel32.dll"))]
    public extern static short QueryPerformanceCounter (ref long x);
    
    [DllImport (("kernel32.dll"))]
    public extern static short QueryPerformanceFrequency (ref long x);
}

public class UsePrototype : MonoBehaviour {
    [SerializeField] private int m_CloneCount = 1000000;
    [SerializeField] private bool m_IsNew = true;
    [SerializeField] private Enemy m_Enemy;
    
    private void Start () {
        // TestShallowClone ();
        // TestDeepClone ();
        // TestUnityClone ();
    }

    private void Update () {
        if (Input.GetKeyDown (KeyCode.Space)) {
            long stopValue = 0;
            long startValue = 0;
            long freq = 0;

            QueryPerformanceMethod.QueryPerformanceFrequency (ref freq);
            QueryPerformanceMethod.QueryPerformanceCounter (ref startValue);
            TestCloneSpeedUp ();
            QueryPerformanceMethod.QueryPerformanceCounter (ref stopValue);
            double time = (double)(stopValue - startValue) / (double)freq;
            Debug.Log (time * 1000);
        }
    }

    private void TestShallowClone () {
        Dog dog = new Dog ();
        dog.Name = "L羅";
        dog.Age = 11;
        dog.Ears[0].Test = "abc";
        dog.Ears[1].Test = "def";
        // Debug.Log ("dog: " + dog);

        Dog dog2 = dog.ShallowClone ();
        dog.Name = "abc";
        // Debug.Log ("dog: " + dog);
        // Debug.Log ("dog2: " + dog2);

        // dog2的Ears[0]的Test也會被改成ffff
        
        dog.Ears[0].Test = "ffff";
        // Debug.Log ("dog: " + dog);
        // Debug.Log ("dog2: " + dog2);
    }

    private void TestDeepClone () {
        Dog dog = new Dog ();
        dog.Name = "L羅";
        dog.Age = 11;
        dog.Ears[0].Test = "abc";
        dog.Ears[1].Test = "def";
        Debug.Log ("dog: " + dog);

        // 用DeepClone()一樣可以
        Dog dog2 = dog.Clone () as Dog;
        dog.Name = "abc";
        Debug.Log ("dog: " + dog);
        Debug.Log ("dog2: " + dog2);

        // dog2的Ears[0]的Test也會被改成ffff
        // 
        dog.Ears[0].Test = "ffff";
        Debug.Log ("dog: " + dog);
        Debug.Log ("dog2: " + dog2);
    }

    private void TestUnityClone () {
        Debug.Log ("Old: " + m_Enemy);

        // Unity中的Instantiate 場景中的GameObject時，不會調用Start
        Enemy enemy = Instantiate (m_Enemy);
        Debug.Log ("New: " + enemy);

        m_Enemy.SetName ("fff");
        m_Enemy.TakeDamage(new AttackData() {
            Damage = 5,
            Type = AttackType.Normal
        });
        Debug.Log ("Old: " + m_Enemy);
        Debug.Log ("New: " + enemy);
    }

    private void TestCloneSpeedUp () {
        if (m_IsNew) {
            for (int i = 0; i < m_CloneCount; ++i) {
                Dog dog2 = new Dog ();
            }
        } else {
            Dog dog = new Dog ();
            
            for (int i = 0; i < m_CloneCount; ++i) {
                object dog2 = dog.Clone ();
            }
        }
    }
    
}
