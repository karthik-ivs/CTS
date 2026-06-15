// Exercise11 - Access Modifiers
// public is available everywhere, protected is available in derived classes, private stays inside the class.

DerivedAccount derived = new();
derived.ShowAccessFromDerived();

AccountViewer viewer = new();
viewer.ShowAccessFromNonDerived(new BaseAccount());

internal class BaseAccount
{
    public string PublicName = "Public account name";
    protected string ProtectedCode = "Protected code";
    private readonly string _privatePin = "Private PIN";

    public string RevealPrivatePinSafely() => _privatePin;
}

internal sealed class DerivedAccount : BaseAccount
{
    public void ShowAccessFromDerived()
    {
        Console.WriteLine($"Derived can read public: {PublicName}");
        Console.WriteLine($"Derived can read protected: {ProtectedCode}");
        Console.WriteLine($"Private is only available through a public method: {RevealPrivatePinSafely()}");
    }
}

internal sealed class AccountViewer
{
    public void ShowAccessFromNonDerived(BaseAccount account)
    {
        Console.WriteLine($"\nNon-derived can read public: {account.PublicName}");
        Console.WriteLine($"Non-derived uses public method for private data: {account.RevealPrivatePinSafely()}");
    }
}
