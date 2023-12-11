using UnityEngine;

namespace Builder
{
    public class MonsterBuilder : IMonsterBuilder, IBossBuilder
    {
        private PrimitiveType _primitiveType = PrimitiveType.Capsule;
        private Color _color = Color.white;
        private string _name = "New Monster";
        private float _width = 1f;
        private bool _randomPosition;
        private bool _isBoss;
        private int _phases;

        public Monster Construct()
        {
            var gameObject = GameObject.CreatePrimitive(this._primitiveType);
            gameObject.GetComponent<Renderer>().material.color = _color;
            gameObject.name = _name;
            gameObject.transform.localScale = new Vector3(_width, 1, 1);
            if (_randomPosition)
            {
                gameObject.transform.position = Random.insideUnitSphere * 4;
            }
            return gameObject.AddComponent<Monster>();
        }

        public IMonsterBuilder WithShape(PrimitiveType shapeType)
        {
            _primitiveType = shapeType;
            return this;
        }

        public IMonsterBuilder WithColor(Color color)
        {
            _color = color;
            return this;
        }

        public IMonsterBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public IBossBuilder AsBoss()
        {
            _isBoss = true;
            return this;
        }

        public IMonsterBuilder WithRandomPosition()
        {
            _randomPosition = true;
            return this;
        }

        public IBossBuilder SetNumberOfPhases(int phases)
        {
            _phases = phases;
            return this;
        }

        public IMonsterBuilder WithWidth(float width)
        {
            _width = width;
            return this;
        }
    }
}