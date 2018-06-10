#pragma warning disable CS1572, CS1573, CS1591
namespace Huntwords.Common.Services
{
    public interface IGenerator<out T>
    {
        T Generate(params object[] options);
    }
}
