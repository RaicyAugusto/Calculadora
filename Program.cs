using System;

namespace Calculadora
{
    class Calculadora
    {
        // Propriedades para armazenar o primeiro número, o segundo número e o operador.
        public double NumberOne { get; set; }
        public double NumberTwo { get; set; }
        public string Operator { get; set; }

        // Construtor padrão para inicializar as propriedades.
        public Calculadora(double numberOne, double numberTwo, string op)
        {
            NumberOne = numberOne;
            NumberTwo = numberTwo;
            Operator = op;
        }

        // Método para realizar a operação matemática de acordo com o operador.
        public double PerformOperation()
        {
            switch (Operator)
            {
                case "+":
                    return NumberOne + NumberTwo;
                case "-":
                    return NumberOne - NumberTwo;
                case "*":
                    return NumberOne * NumberTwo;
                case "/":
                    if (NumberTwo == 0)
                    {
                        throw new DivideByZeroException("Não é possível dividir por zero.");
                    }
                    return NumberOne / NumberTwo;
                default:
                    throw new InvalidOperationException("Operador inválido, por favor insira um operador válido (+, -, *, /)");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Calculadora";

            Console.ForegroundColor = ConsoleColor.Green;
            //loop while para que o programa se execute
            while (true)
            {

                //Inicialização
                Console.WriteLine("Bem-Vindo a Calculadora");

                // Recebe o primeiro número.
                Console.Write("Insira o primeiro número: ");
                if (!double.TryParse(Console.ReadLine(), out double numberOne))
                {
                    Console.Write("Entrada inválida, insira um número válido. ");
                    Console.WriteLine("Digite 'limpar' para limpar a tela.");
                    string input = Console.ReadLine();
                    if (input.ToLower() == "limpar")
                    {
                        Console.Clear();
                    }
                }

                // Recebe o operador.
                Console.Write("Insira o operador (+, -, *, /): ");
                string op = Console.ReadLine();

                // Recebe o segundo número.
                Console.Write("Insira o segundo número: ");
                if (!double.TryParse(Console.ReadLine(), out double numberTwo))
                {
                    Console.Write("Entrada inválida, insira um número válido. ");
                    Console.WriteLine("Digite 'limpar' para limpar a tela.");
                    string input = Console.ReadLine();
                    if (input.ToLower() == "limpar")
                    {
                        Console.Clear();
                    }
                }

                // Cria um objeto da classe Calculator.
                Calculadora calculatora = new Calculadora(numberOne, numberTwo, op);

                try
                {
                    // Chama o método PerformOperation para realizar a operação matemática.
                    double result = calculatora.PerformOperation();
                    Console.WriteLine($"Resultado: {result}");
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

    }