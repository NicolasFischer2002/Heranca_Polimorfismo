using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herança.Classes
{
    // Uma classe abstract é uma classe que não pode ser instanciada diretamente. Ela serve como um modelo para outras classes.
    // Ao marcar a classe Veiculo como abstract, você está indicando que ela não deve ser instanciada por si só.
    // Em vez disso, ela será usada como base para outras classes (como Carro, Motocicleta e Caminhão).
    public abstract class Veiculo
    {
        public string Marca { get; }
        public string NumeroChassi { get; }
        public DateOnly AnoFabricacao { get; }
        public bool Importado { get; }
        public float Valor { get; }

        public Veiculo(string marca, string numeroChassi, DateOnly anoFabricacao, bool importado, float valor)
        {
            if (string.IsNullOrEmpty(marca))
                throw new ArgumentNullException("A marca do veículo não pode ser nula ou vazia!");

            if (string.IsNullOrEmpty(numeroChassi) || numeroChassi.Length != 17)
                throw new Exception("Número do chassi inválido! Deve conter 17 caracteres.");

            if (valor <= 0)
                throw new Exception("O valor do veículo não pode ser zero ou negativo!");

            Marca = marca;
            NumeroChassi = numeroChassi;
            AnoFabricacao = anoFabricacao;
            Importado = importado;
            Valor = valor;
        }

        // O método será implementado nas classes que herdarem a Classe Base - Veiculo.
        // Ele pode ser reescrito ou não, com base nas necessidades; Por exemplo:
        // Suponhamos que exista a classe Motocicleta, que herda da Classe Base Veiculo.
        // Suponhamos também, que existam apenas motocicletas nacionais, nunca nenhuma será importada;
        // por consequência, o campo "Importado" perde o sentido. Neste caso, é possível
        // sobrescrever o método "Resumo" dentro da Classe Motocicleta sem que o item "Importado" seja exibido;
        // Tudo isso sem afetar o método "Resumo" herdado pela Classe Carro, que implementa o Método "Resumo"
        // em sua forma pura.
        public virtual void Resumo(Veiculo veiculo)
        {
            Console.WriteLine($"Marca: {veiculo.Marca}");
            Console.WriteLine($"Número Chassi: {veiculo.NumeroChassi}");
            Console.WriteLine($"Ano de fabricação: {veiculo.AnoFabricacao}");
            Console.WriteLine($"Importado: {veiculo.Importado}");
            Console.WriteLine($"Valor: {veiculo.Valor}");
            Console.WriteLine($"Custo total: {CalculaCustoTotal()}");
        }

        // Método virtual para calcular o custo total (incluindo IPVA)
        public virtual float CalculaCustoTotal()
        {
            float ipva = CalculaIPVA(); // Método específico para calcular IPVA
            return Valor + ipva;
        }

        // Método para calcular o IPVA (exemplo)
        protected virtual float CalculaIPVA()
        {
            // Implementação padrão (pode ser sobrescrita)
            float aliquota = 0.05f; // Suponhamos uma alíquota de 5%, padrão
            return Valor * aliquota;
        }
    }
}
