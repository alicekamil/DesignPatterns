using UnityEngine;

namespace Builder
{
    public class BuilderSample : MonoBehaviour
    {
        void Start()
        {
            var builder = new MonsterBuilder()
                .WithColor(Color.red)
                .WithName("Bloodie")
                .WithShape(PrimitiveType.Cube)
                .WithWidth(5)
                .WithRandomPosition()
                .AsBoss()
                .SetNumberOfPhases(4);

            for (int i = 0; i < 10; i++)
            {
                builder.Construct();
            }
        }
    }
}