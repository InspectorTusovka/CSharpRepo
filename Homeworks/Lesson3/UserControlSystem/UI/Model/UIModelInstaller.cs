using Code.Abstraction;
using Code.UserControlSystem.CommandRealization;
using Code.UserControlSystem.UI.Model.CommandCreators;
using Code.Utilities;
using UnityEngine;
using Zenject;

namespace Code.UserControlSystem.UI.Model
{
    public class UIModelInstaller : MonoInstaller
    {
        [SerializeField] private AssetsContext _legacyContext;
        [SerializeField] private Vector3Value _vector3Value;
        [SerializeField] private AttackableValue _attackableValue;

        public override void InstallBindings()
        {
            Container
                .Bind<AssetsContext>()
                .FromInstance(_legacyContext);
            Container
                .Bind<Vector3Value>()
                .FromInstance(_vector3Value);
            Container
                .Bind<AttackableValue>()
                .FromInstance(_attackableValue);
            
            Container
                .Bind<CommandCreator<IProduceUnitCommand>>()
                .To<ProduceUnitCommandCommandCreator>()
                .AsTransient();
            Container
                .Bind<CommandCreator<IMoveCommand>>()
                .To<MoveCommandCommandCreator>()
                .AsTransient();
            Container.Bind<CommandCreator<IAttackCommand>>()
                .To<AttackCommandCommandCreator>()
                .AsTransient();
            Container
                .Bind<CommandCreator<IHoldCommand>>()
                .To<HoldCommandCommandCreator>()
                .AsTransient();
            Container
                .Bind<CommandCreator<IPatrolCommand>>()
                .To<PatrolCommandCommandCreator>()
                .AsTransient();

            Container
                .Bind<CommandButtonsModel>()
                .AsTransient();
        }
    }
}