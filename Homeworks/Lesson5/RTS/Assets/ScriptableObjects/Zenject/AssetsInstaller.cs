using System;
using Code.Abstraction;
using Code.UserControlSystem.UI.Model;
using Code.Utilities;
using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName = "Installers/AssetsInstaller", fileName = "AssetsInstaller", order = 0)]
public sealed class AssetsInstaller : ScriptableObjectInstaller<AssetsInstaller>
{
    [SerializeField] private AssetsContext _legacyContext;
    [SerializeField] private Vector3Value _groundClickRMB;
    [SerializeField] private AttackableValue _attackClickRMB;
    [SerializeField] private SelectableValue _selectable;

    public override void InstallBindings()
    {
        Container
            .Bind<AttackableValue>()
            .FromInstance(_attackClickRMB);
        Container
            .Bind<SelectableValue>()
            .FromInstance(_selectable);
        Container
            .Bind<Vector3Value>()
            .FromInstance(_groundClickRMB);
        
        Container
            .Bind<IAwaitable<IAttackable>>()
            .FromInstance(_attackClickRMB);
        Container
            .Bind<IAwaitable<Vector3>>()
            .FromInstance(_groundClickRMB);
        Container
            .BindInstances(_legacyContext, _selectable);

        Container
            .Bind<IObservable<ISelectable>>()
            .FromInstance(_selectable);
    }
        
}