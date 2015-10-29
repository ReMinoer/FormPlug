using FormPlug.Annotations;

namespace FormPlug.TestHelper
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