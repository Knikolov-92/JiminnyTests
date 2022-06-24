namespace Jiminny.UITests.TestInfrastructure.Pages
{
    public class BaseValidator<TElementMap> where TElementMap : BaseElements, new()
    {
        protected TElementMap Elements => new();
    }
}
