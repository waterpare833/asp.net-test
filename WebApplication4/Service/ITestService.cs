using MagicOnion;

namespace WebApplication3;

public interface ITestService : IService<ITestService>
{
    UnaryResult<int> Get_num();
}