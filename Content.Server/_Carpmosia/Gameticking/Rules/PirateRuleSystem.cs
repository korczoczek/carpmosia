using Content.Server.Cargo.Systems;
using Content.Server.GameTicking.Rules.Components;

namespace Content.Server.Pirates;

public sealed partial class PirateSystem : EntitySystem
{
    [Dependency] private readonly ILogManager _logManager = default!;
    [Dependency] private readonly PricingSystem _pricing = default!;

    private ISawmill _sawmill = default!;

    public override void Initialize()
    {
        base.Initialize();

        _sawmill = _logManager.GetSawmill("Pirates");
    }

    private void GetInitialShipValue(EntityUid grid)
    {
        var val = _pricing.AppraiseGrid(grid, ent =>
        {
            return !HasComp<PirateEquipmentComponent>(ent);
        });
    }
}
