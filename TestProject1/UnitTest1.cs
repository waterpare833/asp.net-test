using FluentAssertions;
using Grpc.Net.Client;
using MagicOnion.Client;
using Microsoft.AspNetCore.Mvc.Testing;
using WebApplication3;
using WebApplication3.Service;

namespace TestProject1;

public class UnitTest1 :  IClassFixture<WebApplicationFactory<TestService>>
{
    private readonly ITestService service;
    
    public UnitTest1(WebApplicationFactory<TestService> factory)
    {
        var http_client = factory.CreateDefaultClient();
        // var channel = GrpcChannel.ForAddress("http://localhost", new() { HttpClient = http_client });
        var channel = GrpcChannel.ForAddress("http://localhost:7289");
        
        this.service = MagicOnionClient.Create<ITestService>(channel);
    }
    
    [Fact]
    public async void Test1()
    {
        var result = await this.service.Get_num();

        result.Should().Be(1000);
    }
}