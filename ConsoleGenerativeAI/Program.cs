using Microsoft.Extensions.AI;
using OpenAI;
using System.ClientModel;

OpenAIClientOptions options = new OpenAIClientOptions();
options.Endpoint = new Uri("https://api.groq.com/openai/v1");
IChatClient client =
    new OpenAIClient(new ApiKeyCredential(Environment.GetEnvironmentVariable("GROQ_API_KEY")), options)
        .AsChatClient("llama-3.2-1b-preview");

Console.OutputEncoding = System.Text.Encoding.UTF8;

while (true)
{
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Microsoft.Extensions.AI --> GROQ");
    Console.WriteLine("*********************************\n");

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("👨‍💻Question: ");
    var text = Console.ReadLine()!;

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\n🤖   Answer ▓ \n ");
    Console.WriteLine(await client.CompleteAsync(text));

    Console.ReadLine();
    Console.Clear();
}
