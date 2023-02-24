using MagicOnion;
using MagicOnion.Server;

namespace WebApplication3.Service;

public class TestService : ServiceBase<ITestService>, ITestService
{
    public async UnaryResult<int> Get_num() => 1000;
}