using UnityEngine;

namespace Builder
{
    public interface IBossBuilder : IMonsterBuilder
    {
        public IBossBuilder SetNumberOfPhases(int phases);
    }
    
    public interface IMonsterBuilder
    {
        Monster Construct();
        IMonsterBuilder WithShape(PrimitiveType shapeType);
        IMonsterBuilder WithColor(Color color);
        IMonsterBuilder WithName(string name);
        IMonsterBuilder WithWidth(float width);
        IBossBuilder AsBoss();
        IMonsterBuilder WithRandomPosition();
    }
}