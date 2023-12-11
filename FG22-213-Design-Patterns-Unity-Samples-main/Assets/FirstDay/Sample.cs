using UnityEngine;

namespace DefaultNamespace
{
    public class Sample : MonoBehaviour
    {
        public void Start()
        {
        }

        void Example(Rectangle rectangle)
        {
            rectangle.SetWidth(4);
            rectangle.SetHeight(3);
            
            Debug.Log(rectangle.GetWidth());
            Debug.Log(rectangle.GetHeight());
        }
    }
}