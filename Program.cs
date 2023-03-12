internal class Program
{
    // * Main é o ponto de partida pro compilador do C#, Se não existir essa estrutura com class 
    // * e um método static com esse exato nome Main o compilador vai criar automaticamente
    // + como o Main é sempre executado pelo compilador, esse método pode receber um array de argumentos
    // + para executar o código e fazer o Main receber argumentos é só escrever dotnet run -- <word>
    private static void Main(string[] args)
    {
        // See https://aka.ms/new-console-template for more information
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Hello, World!");
        Console.Clear();

        Strings();
        Numbers();
        Types();
        TryCatch();
    }

    private static void Strings()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;

        var myNames = new List<string> { "Murilo", "Sanches" };
        myNames.ForEach(Console.WriteLine);

        string firstName = myNames[0];
        string lastName = myNames[1];
        Console.WriteLine(firstName.StartsWith("Muri") ? "Muri existe em \"Murilo\"" : "Muri não existe em \"Murilo\"");
        Console.WriteLine(lastName.StartsWith("San") ? "San existe em \"Sanches\"" : "San não existe em \"Sanches\"");
        Console.WriteLine(myNames[0].Contains("s"));
        Console.WriteLine(myNames[0].Contains("m"));
        Console.WriteLine(myNames[0].Contains("m", StringComparison.OrdinalIgnoreCase));
        Console.WriteLine($"{string.Join('-', myNames)}");

        string empty = " ";
        Console.WriteLine(string.IsNullOrEmpty(empty) ? "Váriavel vazia ou nula" : empty);
        Console.WriteLine(string.IsNullOrWhiteSpace(empty) ? "Váriavel nula ou com white space" : empty);

        // + case sensitive Murilo != murilo
        // * myNames[0] == "murilo" = false
        // + ignore case sensitive
        // * string.Equals(myNames[0], "murilo", StringComparison.OrdinalIgnoreCase) = true

        Console.WriteLine();
        Console.ResetColor();
    }

    private static void Numbers()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;

        Console.WriteLine(int.TryParse("11", out int x) ? x : $"Não é possível converter ${x} para int");
        Console.WriteLine(int.TryParse("c", out int y) ? y : $"Não é possível converter \"${y}\" para int");

        int integer = 10;
        long longI = 100;
        // + conversão implícita, o longI por causa do tipo consegue suportar qualquer int
        longI = integer;
        // + implícitamente não da para converter um long para um int
        // integer = longI;
        // + convertendo o long com o (int) pq é crtz que cabe em 32-bit (porque eu sei o valor)
        integer = (int)longI;
        Console.WriteLine(longI);
        // + se acontecer uma conversão explicita com um número que não cabe em um int, vai acontecer perda de dados
        longI = 12391237120312031;
        integer = (int)longI;
        Console.WriteLine(integer);

        Console.WriteLine();
        Console.ResetColor();
    }

    public static void Types()
    {
        Console.ForegroundColor = ConsoleColor.Red;

        if (typeof(char).IsPrimitive)
        {
            Console.WriteLine("Tipo char é primitivo");
        }
        if (!typeof(string).IsPrimitive)
        {
            Console.WriteLine("Tipo string não é primitivo");
        }
        if (typeof(byte).IsPrimitive)
        {
            Console.WriteLine("Tipo byte é primitivo");
        }
        if (typeof(sbyte).IsPrimitive)
        {
            Console.WriteLine("Tipo sbyte é primitivo");
        }
        if (typeof(int).IsPrimitive)
        {
            Console.WriteLine("Tipo int é primitivo");
        }
        if (typeof(long).IsPrimitive)
        {
            Console.WriteLine("Tipo long é primitivo");
        }
        if (typeof(float).IsPrimitive)
        {
            Console.WriteLine("Tipo float é primitivo");
        }
        if (typeof(double).IsPrimitive)
        {
            Console.WriteLine("Tipo double é primitivo");
        }
        if (!typeof(decimal).IsPrimitive)
        {
            Console.WriteLine("Tipo decimal não é primitivo");
        }
        Console.WriteLine();

        // ! acessando uma propriedade atráves de uma classe transforma em refêrencia de memória
        MemoryReferency xis = new MemoryReferency();
        xis.x = 100;
        // + yis.x é igual a xis (memory reference)
        MemoryReferency yis = xis;
        // + xis.x ainda tem o valor 100
        Console.WriteLine($"{xis.x} : {yis.x}");
        // + yis.x é igual a 1
        yis.x = 1;
        Console.WriteLine($"{xis.x} : {yis.x}");
        // + então xis.x também é 1 porque eles estão interligados
        Console.WriteLine();

        int? possibleNull = null;
        Console.WriteLine(possibleNull.GetValueOrDefault());
        Console.WriteLine(possibleNull.GetValueOrDefault(6969));
        Console.WriteLine(possibleNull.HasValue);
        Console.WriteLine(possibleNull == null);
        Console.WriteLine(possibleNull is null);
        Console.WriteLine(possibleNull is not null);
        possibleNull = 1;
        Console.WriteLine();
        Console.WriteLine(possibleNull.HasValue);
        Console.WriteLine(possibleNull == null);
        Console.WriteLine(possibleNull is null);
        Console.WriteLine(possibleNull is not null);

        Console.WriteLine();
        Console.ResetColor();
    }

    public static void TryCatch()
    {
        string stringNull = null;
        try
        {
            // Console.WriteLine(new List<int> { 1, 2, 3 }[5]); // ! Exception
            Console.WriteLine(stringNull.Length); // ! NullReferenceException
        }
        catch (System.NullReferenceException exception)
        {
            Console.WriteLine("NullReferenceException");
            Console.WriteLine(exception.StackTrace);
        }
        catch (System.Exception exception)
        {
            Console.WriteLine("Exception");
            Console.WriteLine(exception.StackTrace);
        }
    }
}

public class MemoryReferency
{
    public int x;
}

