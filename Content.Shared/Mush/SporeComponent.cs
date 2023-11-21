namespace Content.Shared.Mush;

/// <summary>
/// This is used for...
/// </summary>
[RegisterComponent]
public sealed partial class SporeComponent : Component
{
    [ViewVariables(VVAccess.ReadWrite), DataField(tag: "sporeAmount")]
    public int SporeAmount;
}
