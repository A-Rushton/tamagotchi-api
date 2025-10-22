using Tamagotchi.Domain.Entities;

namespace Tamagotchi.Game;

class Program
{
    private static Pet pet = new Pet();
    private static PeriodicTimer timer;
    
    static async Task Main(string[] args)
    {
        var cts = new CancellationTokenSource();
        var updaterTask = Task.Run(() => PeriodicUpdateAsync(TimeSpan.FromSeconds(1), cts.Token));
        var inputTask = Task.Run(() => ListenForInputAsync(cts));

        await Task.WhenAny(updaterTask, inputTask); // Exit when one task completes
        cts.Cancel(); // Ensure both stop
        await Task.WhenAll(Task.WhenAny(updaterTask, inputTask));

        Console.WriteLine("\nProgram stopped.");
        
        async Task PeriodicUpdateAsync(TimeSpan interval, CancellationToken token)
        {
            using var timer = new PeriodicTimer(interval);

            while (await timer.WaitForNextTickAsync(token))
            {
                // Example "state" — could be anything dynamic
                var state = $"[{DateTime.Now:HH:mm:ss}] Updating status...";
        
                // Save current cursor position to restore after writing status
                var left = Console.CursorLeft;
                var top = Console.CursorTop;

                // Move cursor to top of console (or a fixed line) to show the status
                Console.SetCursorPosition(0, 0);
                Console.Write($"\r{state,-40}");

                // Restore cursor to where user was typing
                Console.SetCursorPosition(left, top);
            }

            // Clear the line after stopping
            Console.WriteLine();
        }
        
        async Task ListenForInputAsync(CancellationTokenSource cts)
        {
            while (!cts.IsCancellationRequested)
            {
                Console.SetCursorPosition(0, 2); // Keep input below status line
                Console.Write("Enter command (type 'exit' to quit): ");
                var input = Console.ReadLine();

                if (input?.Equals("exit", StringComparison.OrdinalIgnoreCase) == true)
                {
                    cts.Cancel();
                    break;
                }
                else
                {
                    Console.WriteLine($"You entered: {input}");
                }
            }
        }
    }
}