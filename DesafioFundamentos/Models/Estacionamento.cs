using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial;
        private decimal precoPorHora;
        private List<string> veiculos;

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
            this.veiculos = new List<string>();
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = LerString();
            veiculos.Add(placa);
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = LerString();

            if (VeiculoEstacionado(placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = LerInteiro();

                decimal valorTotal = CalcularValorTotal(horas);

                RemoverVeiculoDaLista(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (string placa in veiculos)
                {
                    Console.WriteLine(placa);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        // Função para ler uma string do console
        private string LerString()
        {
            string input = Console.ReadLine();
            while (string.IsNullOrEmpty(input)) // Verifica se a entrada é nula ou vazia
            {
                Console.WriteLine("Por favor, digite um valor válido. Não deixe em branco.");
                input = Console.ReadLine();
            }
            return input;
        }

        // Função para ler um número inteiro do console
        private int LerInteiro()
        {
            int numero;
            while (!int.TryParse(Console.ReadLine(), out numero))
            {
                Console.WriteLine("Por favor, digite um número válido.");
            }
            return numero;
        }

        // Função para verificar se um veículo está estacionado
        private bool VeiculoEstacionado(string placa)
        {
            return veiculos.Any(x => x.Equals(placa, StringComparison.OrdinalIgnoreCase));
        }

        // Função para calcular o valor total com base nas horas
        private decimal CalcularValorTotal(int horas)
        {
            return precoInicial + precoPorHora * horas;
        }

        // Função para remover um veículo da lista
        private void RemoverVeiculoDaLista(string placa)
        {
            veiculos.Remove(placa);
        }
    }
}
