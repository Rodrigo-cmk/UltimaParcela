using System;
using Humanizer;

namespace UltimaParcela
{
    class Program
    {
        static void Main(string[] args)
        {
            inicio();

            principal();            
        }

        static void inicio()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*** Exercício Última Parcela ***");
            Console.ResetColor();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("-->");
            Console.ResetColor();

            Console.Write(" Recepção do valor total a ser pago e a quantidade de parcelas mensais de um financiamento. ");
            Console.WriteLine("Exibição da data e o valor da última parcela.");
            Console.WriteLine();
        }

        static void principal()
        {
            try
            {


                decimal valorDoFinanciamento, parcelasMensais; ;
                int quantidadeDeParcelas;
                DateTime dataPrimeiroPagamento;

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("- Insira o valor total do financiamento: ");
                Console.ResetColor();
                valorDoFinanciamento = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine();

                if (valorDoFinanciamento <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Atenção!! Não é possível financiar números negativos.");
                    Console.ResetColor();
                    Environment.Exit(-1);
                }

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("- Insira a quantidade de parcelas mensais (Até 12x): ");
                Console.ResetColor();
                quantidadeDeParcelas = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                if (quantidadeDeParcelas <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Atenção!! Não existem parcelas negativas.");
                    Console.ResetColor();
                    Environment.Exit(-1);
                }

                if (quantidadeDeParcelas > 12)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Atenção!! Limite excedido.");
                    Console.ResetColor();
                    Environment.Exit(-1);
                }

                if (quantidadeDeParcelas == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("O pagamento não seria à vista?");
                    Console.ResetColor();
                    Environment.Exit(-1);
                }

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("- Insira a data do primeiro pagamento ");
                Console.ResetColor();
                Console.Write("(No formato: DD/MM/AAAA): ");
                dataPrimeiroPagamento = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine();

                Console.WriteLine(" _________________________________________________________");

                Console.Write("| Valor total do financiamento: ");
                Console.WriteLine($"{valorDoFinanciamento:C2}");

                Console.Write("| Quantidade de parcelas mensais: ");
                Console.WriteLine(quantidadeDeParcelas);

                Console.Write("| Data do primeiro pagamento: ");
                Console.WriteLine(dataPrimeiroPagamento);
                Console.WriteLine();

                parcelasMensais = valorDoFinanciamento / quantidadeDeParcelas;

                DateTime dataFinal = dataPrimeiroPagamento.AddMonths(quantidadeDeParcelas);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("==>");
                Console.ResetColor();


                Console.Write(" A data final do parcelamento será: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"{dataFinal}");
                Console.ResetColor();

                Console.Write($" e a última parcela será de: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"{parcelasMensais:C2} (Sem juros).");
                Console.ResetColor();

                Console.WriteLine();
            }

            catch (FormatException)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Atenção!! O valor de entrada está no formato incorreto.");
                Console.ResetColor();
                Environment.Exit(-1);


            }

            catch (Exception ex)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Atenção!! Erro genérico.");
                Console.ResetColor();
                Console.WriteLine($"Tipo: {ex.GetType()}.");
                Console.WriteLine($"Tipo: {ex.Message}.");
                Environment.Exit(-1);
            }
        }
    }
}
