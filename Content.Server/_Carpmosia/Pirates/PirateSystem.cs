using Content.Server.Cargo.Systems;
using Content.Server.Pirates.Components;

namespace Content.Server.Pirates;

public sealed partial class PirateSystem : EntitySystem
{
    [Dependency] private readonly ILogManager _logManager = default!;

    private ISawmill _sawmill = default!;

    public override void Initialize()
    {
        base.Initialize();

        _sawmill = _logManager.GetSawmill("Pirates");
    }

    private void MarkPirateEquipment(EntityUid grid)
    {
        var xform = Transform(grid);
        var enumerator = xform.ChildEnumerator;
        var pirateEquipment = new PirateEquipmentComponent();
        while (enumerator.MoveNext(out var child))
        {
            EntityManager.AddComponent(child, pirateEquipment, true);
        }
    }
}
