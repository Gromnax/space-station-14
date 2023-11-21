namespace Content.Shared.Item;

/// <summary>
///     Raised on a mob after it successfully picked up an objet in its hands
/// </summary>
public sealed class AfterPickupEvent : BasePickupAttemptEvent
{
    public AfterPickupEvent(EntityUid user, EntityUid item) : base(user, item) { }
}

/// <summary>
///     Raised on an entity when it has successfully been picked up by an entity
/// </summary>
public sealed class AfterGettingPickedupEvent : BasePickupAttemptEvent
{
    public AfterGettingPickedupEvent(EntityUid user, EntityUid item) : base(user, item) { }
}

