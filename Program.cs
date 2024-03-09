
using Herança.Classes;

try
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Hello, World!\n");

    Carro carro = new Carro("Hyundai", "9BG116GW04C400001", DateOnly.FromDateTime(new DateTime(2011,1,1)), 
        true, 35000, Carro.TiposCombustivel.Gasolina, Carro.Tracoes.Dianteira, Carro.Cores.Preto, 6, 4, 265, 7, "ABC6458", false);

    carro.Resumo(carro);
}
catch (Exception Erro)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Erro inesperado: {Erro.Message}");
}
finally
{
	Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("\nAplicação finalizada");
}
