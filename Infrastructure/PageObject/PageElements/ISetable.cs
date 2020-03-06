namespace Infrastructure.PageObject.PageElements.Interfaces
{
      public interface ISetable{
        void Set(string value);
        string Value { get; }
    }
}