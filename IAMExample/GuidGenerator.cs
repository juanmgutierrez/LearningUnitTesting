namespace IAMExample;

public class GuidGenerator : IDisposable
{
    public Guid FixedGuid { get; } = Guid.NewGuid();

    public void Dispose() => Console.WriteLine($"Fin de GuidGenerator con Guid = {FixedGuid}");
}
