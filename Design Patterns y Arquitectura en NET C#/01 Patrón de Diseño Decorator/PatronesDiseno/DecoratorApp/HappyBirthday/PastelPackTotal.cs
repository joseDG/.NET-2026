using DecoratorApp.Common;

namespace DecoratorApp.HappyBirthday
{
    class PastelPackTotal : PastelDecorator
    {
        public PastelPackTotal(IPastel pastel): base(pastel)
        {
        }

        public override Size GetDimensions(Size propaganda) => base.GetDimensions(Size.Zero)
                                                               .ScaleHeight(2)
                                                               .AddToTop(propaganda);
        
    }
}
