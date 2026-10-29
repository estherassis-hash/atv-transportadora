
using System;
using System.Collections.Generic;

// CLASSE PAI
public class Veiculo
{
    private string placa;
    private double quilometragem;

    public string Placa
    {
        get { return placa; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Placa inválida!");

            placa = value;
        }
    }

    public double Quilometragem
    {
        get { return quilometragem; }
        private set
        {
            if (value < 0)
                throw new ArgumentException("Quilometragem inválida!");

            quilometragem = value;
        }
    }

    public Veiculo(string placa, double quilometragem)
    {
        Placa = placa;
        Quilometragem = quilometragem;
    }

    public virtual double CalcularCustoViagem(double distancia)
    {
        if (distancia <= 0)
            throw new ArgumentException("Distância inválida!");

        return distancia * 1.00;
    }

    public void RegistrarViagem(double distancia)
    {
        if (distancia <= 0)
            throw new ArgumentException("Distância inválida!");

        Quilometragem += distancia;
    }

    public virtual void ExibirInformacoes()
    {
        Console.WriteLine("Placa: " + Placa);
        Console.WriteLine("Quilometragem: " + Quilometragem + " km");
    }
}

// CLASSE FILHA CARRO
public class Carro : Veiculo
{
    public Carro(string placa, double quilometragem)
        : base(placa, quilometragem)
    {
    }

    public override double CalcularCustoViagem(double distancia)
    {
        base.CalcularCustoViagem(distancia);
        return distancia * 0.80;
    }

    public override void ExibirInformacoes()
    {
        Console.WriteLine("\n--- CARRO ---");
        base.ExibirInformacoes();
    }
}

// CLASSE FILHA MOTO
public class Moto : Veiculo
{
    public Moto(string placa, double quilometragem)
        : base(placa, quilometragem)
    {
    }

    public override double CalcularCustoViagem(double distancia)
    {
        base.CalcularCustoViagem(distancia);
        return distancia * 0.40;
    }

    public override void ExibirInformacoes()
    {
        Console.WriteLine("\n--- MOTO ---");
        base.ExibirInformacoes();
    }
}

// CLASSE FILHA CAMINHAO
public class Caminhao : Veiculo
{
    public Caminhao(string placa, double quilometragem)
        : base(placa, quilometragem)
    {
    }

    public override double CalcularCustoViagem(double distancia)
    {
        base.CalcularCustoViagem(distancia);
        return distancia * 2.50 + 50.00;
    }

    public override void ExibirInformacoes()
    {
        Console.WriteLine("\n--- CAMINHÃO ---");
        base.ExibirInformacoes();
    }
}

// PROGRAMA PRINCIPAL
public class Program
{
    public static void Main()
    {
        try
        {
            List<Veiculo> veiculos = new List<Veiculo>();

            veiculos.Add(new Carro("ABC1D23", 15000));
            veiculos.Add(new Moto("XYZ4E56", 8000));
            veiculos.Add(new Caminhao("JKL7F89", 50000));

            double distancia = 100;

            Console.WriteLine("SISTEMA DA TRANSPORTADORA");
            Console.WriteLine("=========================");

            foreach (Veiculo veiculo in veiculos)
            {
                veiculo.ExibirInformacoes();

                double custo = veiculo.CalcularCustoViagem(distancia);

                Console.WriteLine("Distância: " + distancia + " km");
                Console.WriteLine("Custo: " + custo.ToString("C2"));

                veiculo.RegistrarViagem(distancia);

                Console.WriteLine("Nova quilometragem: "
                    + veiculo.Quilometragem + " km");
            }

            Console.WriteLine("\nViagens registradas com sucesso!");
        }
        catch (ArgumentException erro)
        {
            Console.WriteLine("Erro: " + erro.Message);
        }
    }
}
