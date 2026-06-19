using DecoratorApp.Common;

namespace DecoratorApp.HappyBirthday
{
    interface IPastel
    {
        string? Nombre { get; }
        Size GetDimensions(Size propaganda);
    }
}
