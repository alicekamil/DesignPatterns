using UnityEngine;

namespace DefaultNamespace
{
    
    
    
    // playerprefs
    // file write all text
    // json, xml, yaml, binary
    // backend
    // qr code
    public interface ISave
    {
        void Write(string key, float value);
        float Read(string key);
    }
    
    public abstract class RectangleBase : MonoBehaviour {
    
    }
    
    public class Rectangle : RectangleBase
    {
        private float _width;
        private float _height;

        public virtual void SetWidth(float value) => _width = value;
        public virtual void SetHeight(float value) => _height = value;
        public float GetWidth() => _width;
        public float GetHeight() => _height;

        
        public void SetDimension(float size)
        {
            
        }

        public void SetDimension(float width, float height)
        {
            
        }
    }
}