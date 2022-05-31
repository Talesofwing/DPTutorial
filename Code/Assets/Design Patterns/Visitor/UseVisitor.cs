using System.Collections.Generic;
using UnityEngine;

namespace VisitorExample {

    public class UseVisitor : MonoBehaviour {
        [SerializeField] private Enemy[] m_Enemies;
        
        private void Start () {
            // ShapeExample ();

            EnemyAmountVisitor visitor = new EnemyAmountVisitor ();
            for (int i = 0; i < m_Enemies.Length; i++) {
                m_Enemies[i].Visit (visitor);
            }
            Debug.Log ("Enemy Amount: " + visitor.Amount);
        }

        private void ShapeExample () {
            ShapeContainer container = new ShapeContainer ();

            Cube cube = new Cube ();
            Sphere sphere = new Sphere ();
            Cylinder cylinder = new Cylinder ();

            container.AddShape (cube);
            container.AddShape (sphere);
            container.AddShape (cylinder);

            ShapeAmountVisitor visitor = new ShapeAmountVisitor ();
            container.RunVisitor (visitor);
            Debug.Log ("All Amount: " + visitor.Amount);

            CubeAmountVisitor cVisitor = new CubeAmountVisitor ();
            container.RunVisitor (cVisitor);
            Debug.Log ("Cube Amount: " + cVisitor.Amount);
        }
        
    }

    /// <summary>
    /// 在不破壞ShapeContainer的情況下，新增了計算所有Shape數量和Cube數量的功能
    /// </summary>
    public class ShapeContainer {
        private List<IShape> m_Shapes = new List<IShape> ();

        public void AddShape (IShape shape) {
            m_Shapes.Add (shape);
        }

        public void RemoveShape (IShape shape) {
            m_Shapes.Remove (shape);
        }

        public void RunVisitor (IShapeVisitor visitor) {
            for (int i = 0; i < m_Shapes.Count; i++) {
                m_Shapes[i].RunVisitor (visitor);
            }
        }
        
    }

    public abstract class IShape {
        public abstract void RunVisitor (IShapeVisitor visitor);
    }

    public class Sphere : IShape {
        
        public override void RunVisitor (IShapeVisitor visitor) {
            visitor.Visit (this);
        }
        
    }

    public class Cylinder : IShape {
        
        public override void RunVisitor (IShapeVisitor visitor) {
            visitor.Visit (this);
        }
        
    }
    
    public class Cube : IShape {

        public override void RunVisitor (IShapeVisitor visitor) {
            visitor.Visit (this);
        }

    }

    /// <summary>
    /// visitor 作為算法，去訪問不同的Cube
    /// </summary>
    public abstract class IShapeVisitor {
        public abstract void Visit (Sphere sphere);
        public abstract void Visit (Cylinder cylinder);
        public abstract void Visit (Cube cube);
    }

    /// <summary>
    /// 通過創建新的Amount來統計Shape的總數
    /// 不需要修改Container中的代碼
    /// </summary>
    public class ShapeAmountVisitor : IShapeVisitor {
        public int Amount {
            get;
            private set;
        }
        
        public override void Visit (Sphere sphere) {
            Amount++;
        }

        public override void Visit (Cylinder cylinder) {
            Amount++;
        }

        public override void Visit (Cube cube) {
            Amount++;
        }
        
    }

    public class CubeAmountVisitor : IShapeVisitor {
        public int Amount {
            get;
            private set;
        }
        
        public override void Visit (Sphere sphere) {}

        public override void Visit (Cylinder cylinder) { }

        public override void Visit (Cube cube) {
            Amount++;
        }
    }
    
}