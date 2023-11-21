namespace Content.Shared.Mush;

public sealed class SporeCountUpdatedEvent : EntityEventArgs
{
    /// <summary>
    /// The SporeComponent that got updated
    /// </summary>
    public readonly SporeComponent Target;

    public SporeCountUpdatedEvent(SporeComponent target)
    {
        Target = target;
    }
};
