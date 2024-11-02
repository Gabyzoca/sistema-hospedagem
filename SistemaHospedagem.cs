using System;

namespace SistemaHospedagem
{
    // Classe que representa uma pessoa (hóspede)
    public class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }

        public Pessoa(string nome, int idade)
        {
            Nome = nome;
            Idade = idade;
        }
    }

    // Classe que representa uma suíte
    public class Suite
    {
        public string Tipo { get; set; }
        public decimal ValorDiaria { get; set; }

        public Suite(string tipo, decimal valorDiaria)
        {
            Tipo = tipo;
            ValorDiaria = valorDiaria;
        }
    }

    // Classe que representa uma reserva
    public class Reserva
    {
        public Pessoa Hóspede { get; set; }
        public Suite SuiteReservada { get; set; }
        public int Dias { get; set; }

        public Reserva(Pessoa hóspede, Suite suiteReservada, int dias)
        {
            Hóspede = hóspede;
            SuiteReservada = suiteReservada;
            Dias = dias;
        }

        // Método para calcular o valor total da reserva
        public decimal CalcularValorTotal()
        {
            decimal valorTotal = SuiteReservada.ValorDiaria * Dias;

            // Aplicar desconto de 10% se a reserva for para mais de 10 dias
            if (Dias > 10)
            {
                valorTotal *= 0.90m; // 10% de desconto
            }

            return valorTotal;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Criando um hóspede
            Pessoa hospede = new Pessoa("Gabriella", 20);

            // Criando uma suíte
            Suite suite = new Suite("Luxo", 200.00m);

            // Criando uma reserva
            Reserva reserva = new Reserva(hospede, suite, 12);

            // Exibindo o valor total da reserva
            Console.WriteLine($"Hóspede: {hospede.Nome}");
            Console.WriteLine($"Tipo de Suíte: {suite.Tipo}");
            Console.WriteLine($"Diárias: {reserva.Dias}");
            Console.WriteLine($"Valor Total: R$ {reserva.CalcularValorTotal():F2}");
        }
    }
}

