using Content.Shared.Administration.Logs;
using Content.Shared.Database;
using Content.Shared.Inventory;
using Content.Shared.Item;
namespace Content.Shared.Mush;

/// <summary>
/// This handles...
/// </summary>
public sealed class SporeSystem : EntitySystem
{
    [Dependency] private   readonly InventorySystem _inventory = default!;
    [Dependency] private readonly ISharedAdminLogManager _adminLogger = default!;

    /// <inheritdoc/>
    public override void Initialize()
    {
        SubscribeLocalEvent<SporeComponent, AfterGettingPickedupEvent>(OnPickedUp);
    }

    private void OnPickedUp(EntityUid uid, SporeComponent component, AfterGettingPickedupEvent args)
    {
        if (args.Cancelled)
        {
            return;
        }

        if (component.SporeAmount <= 0)
        {
            return;
        }

        AddSpores(
            _inventory.TryGetSlotEntity(uid, "gloves", out var gloves)
                ? gloves.Value
                : args.User, 1);

        component.SporeAmount -= 1;
    }

    private void AddSpores(EntityUid uid, int sporeAmount)
    {
        SporeComponent? sporeComp;
        if (!TryComp(uid, out sporeComp))
        {
            sporeComp = AddComp<SporeComponent>(uid);
        }

        sporeComp.SporeAmount += sporeAmount;
        _adminLogger.Add(LogType.Pickup, LogImpact.Low, $"{sporeAmount} spores added to {ToPrettyString(uid)}");

        RaiseLocalEvent(uid, new SporeCountUpdatedEvent(sporeComp));
    }
}
