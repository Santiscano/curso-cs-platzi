public class HelloWorldService: IHelloWorldService
{
    public string GetMessage()
    {
        return "Hello World!";
    }
}

public interface IHelloWorldService
{
    string GetMessage();
}