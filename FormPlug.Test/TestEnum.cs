using FormPlug.Annotations;

namespace FormPlug.Test
{
    public enum TestEnum
    {
        Yes,
        [UsedImplicitly]
        No,
        [UsedImplicitly]
        Maybe
    }
}