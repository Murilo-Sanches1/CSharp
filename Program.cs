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
        Expressions();
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

        // + readonly struct System.Boolean Represents a Boolean (true or false) value.
        // * bool

        // + readonly struct System.Char Represents a character as a UTF-16 code unit.
        // ! 'c' Aspas simples criam um objeto char
        // * char

        // + readonly struct System.Byte Represents an 8-bit unsigned integer.
        // ! unsigned = não representa números negativos
        // ! 8-bit guarda um valor de 0 a 255
        // * byte

        // + readonly struct System.Int32 Represents a 32-bit signed integer.
        // ! signed = representa números negativos
        // ! 32-bit guarda 0 até 4294967295, ou de −2147483648 até 2147483647
        // * int

        // + readonly struct System.Int64 Represents a 64-bit signed integer.
        // ! 64-bit mano isso é absurdamente grande
        // * long

        // + readonly struct System.Single Represents a single-precision floating-point number.
        // ! números quebrados
        // * float

        // + readonly struct System.Double Represents a double-precision floating-point number.
        // ! números quebrados com duas vezes mais precisão do que o float
        // * double

        // + readonly struct System.Decimal Represents a decimal floating-point number.
        // ! muito mais preciso do que os outros. Sempre representar moedas usando esse tipo
        // * decimal

        // + class System.String Represents text as a sequence of UTF-16 code units.
        // ! "string" aspas duplas criam um objeto do tipo string
        // * string

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
        MemoryReferency<int> xis = new MemoryReferency<int>();
        xis.x = 100;
        // + yis.x é igual a xis (memory reference)
        MemoryReferency<int> yis = xis;
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

    public static void Expressions()
    {
        // + isso são expressions, ao contrario de statments, expressions retornam um resultado
        // * iniciei "a" do tipo byte vazia e criei uma variável "b" que é igual ao valor da expressão
        // * no caso b é igual a variável "a" que é igual a 10, podemos escrever desse jeito porque
        // * para iniciar uma variavel o compilador espera uma expressão e a = 10 é uma expressão e retorna 10 
        byte a;
        byte b = a = 10; // + operador de atribuição binário
        // * b sozinho é um statment e b++ é uma expression, então b é ao mesmo tempo os dois,
        // * métodos também são os dois ao mesmo tempo e atribuição simples que é o exemplo acima, b = a = 10
        b++; // + Operador de atribuição unário

        byte x = 1;
        int y;
        y = x == 1 ? 5 : 10; // + Operador ternário

        System.Console.WriteLine();
        // * System.Console - System é um namespace, namespace são uma forma de organizar o código de maneira lógica,
        // * a lógica é parecida com pastas, porém pastas são organizações físicas e namespaces de maneira lógica
        // * fogão e geladeira poderiam ser agrupadas lógicamente por uma namespace Cozinha por exemplo
        // + public static class Console - Console é uma clase static, então não é possível criar um objeto a partir dela,
        // + new Console() = Errado, como a classe é static, todos os seus membors tem que ser static também

        // * C# é orientado a objetos, em princípio, tudo são objetos e objetos são instâncias de uma classe
        // * quando escrevemos Console estamos acessando a classe e com o ponto acessamos os métodos dessa classe
        // * Console.WriteLine("expression");
        // + Como tudo são objetos, podemos ter métodos em strings por exemplo, porque toda string é um objeto
        Console.WriteLine("Tamanho da frase: " + "Objeto do tipo String e estou acessando o método length".Length);
        // * Quando fazemos "palavra".<Método> estamos tendo acesso aos métodos de instância da classe String
        // * mas classes não estáticas podem ter membros estáticos, por exemplo string.Create Z string.Equals
    }

    public static void Delegates()
    {
        // + Delegate
        // - It is a reference type.
        // - It is a function pointer or it holds a reference (pointer) to a function (method).
        // - It is type safe.
        // - Delegates are mainly used for the event handling and the callback methods.
    }
}

public class MemoryReferency<T>
{
    public T? x;
}

