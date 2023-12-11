using JetBrains.Annotations;

namespace DefaultNamespace.State
{
    public interface IState
    {
        [CanBeNull] IState Execute();
    }
    
    public enum StateEnum
    {
        Standing,
        Jumping,
        Idling,
        Swimming,
    }

    public class StandingState : IState
    {
        public IState Execute()
        {
            throw new System.NotImplementedException();
        }
    }

    public class Player
    {
        private StateEnum state;

        void Update()
        {
            switch (state)
            {
                case StateEnum.Idling:
                    break;
                case StateEnum.Jumping:
                    break;
                case StateEnum.Standing:
                    break;
                case StateEnum.Swimming:
                    break;
            }
        }
    }
}