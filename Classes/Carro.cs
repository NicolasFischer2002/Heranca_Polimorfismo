using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herança.Classes
{
    public class Carro : Veiculo
    {
        public enum TiposCombustivel
        {
            Flex,
            Gasolina,
            Etanol,
            Eletricidade
        }
        public enum Tracoes
        {
            Dianteira,
            Traseira,
            QuatroPorQuatro
        }
        public enum Cores
        {
            Preto,
            Branco,
            Prata,
            Verde,
            Azul
        }

        private string TipoCombustivel { get; }
        private string Tracao { get; }
        private string Cor { get; }
        public int Cilindros { get; }
        public int NumeroPortas { get; }
        public int CavalosPotencia { get; }
        public float AutonomiaPorKM { get; }
        public string Placa { get; }
        public bool Utilitario { get; }

        public Carro(string marca, string numeroChassi, DateOnly anoFabricacao, bool importado, float valor, 
            TiposCombustivel tipoCombustivel, Tracoes tracao, Cores cor, int cilindros, int numeroPortas, int cavalosPotencia, float autonomiaPorKM, string placa, bool utilitario)
            : base(marca, numeroChassi, anoFabricacao, importado, valor)
        {
            if (cilindros <= 0)
                throw new Exception("Número de cilindros não pode ser menor igual a zero!");

            if (numeroPortas <= 0)
                throw new Exception("Número de portas não pode ser menor igual a zero!");

            if (cavalosPotencia <= 0)
                throw new Exception("Número de cavalos não pode ser menor igual a zero!");

            if (autonomiaPorKM <= 0)
                throw new Exception("Autonomia por KM não pode ser menor igual a zero!");

            if (string.IsNullOrEmpty(placa) || placa.Length < 7)

            TipoCombustivel = tipoCombustivel.ToString();
            Tracao = tracao.ToString();
            Cor = cor.ToString();
            NumeroPortas = numeroPortas;
            CavalosPotencia = cavalosPotencia;
            Placa = placa;
            Utilitario = utilitario;
            Cilindros = cilindros;
        }

        // Sobrescreve o método CalculaIPVA para carros
        protected override float CalculaIPVA()
        {
            float aliquotaCarro;

            if (!Utilitario)
                aliquotaCarro = 0.04f; // Alíquota específica para carros
            else
                aliquotaCarro = 0.02f; // Alíquota específica para carros utilitários

            return Valor * aliquotaCarro;
        }
    }
}
