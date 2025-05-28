using exercicio05;
using System;
using System.Text.Json;
using System.IO;
class Exercicio5
{
    static List<Cliente> clientes;
    static List<Hospital> hospitais;
    static List<Atendimento> atendimentos;
    static void Main(string[] args)
    {
        CarregarDados();
        //clientes = new List<Cliente>();
        hospitais = new List<Hospital>();
        atendimentos = new List<Atendimento>();

        int opcao;
        do
        {
            Console.Clear();
            ExibirMenu();

            opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
            {
                CadastrarCliente();
            }
            else if (opcao == 2)
            {
                ListarClientes();
            }
            else if (opcao == 3)
            {
                CadastrarHospital();
            }
            else if (opcao == 4)
            {
                ListarHospital();
            }
            else if (opcao == 5)
            {
                AtenderCliente();
            }
            else if (opcao == 6)
            {
                ListarAtendimentos();
            }

            SalvarDados();

            Console.WriteLine("Digite qualquer tecla para continuar...");
            Console.ReadKey();

        } while (opcao != 0);

    }

    private static void CarregarDados()
    {
        JsonSerializerOptions options = new JsonSerializerOptions();
        options.WriteIndented = true;
        options.IncludeFields = true;

        string clientesJson = File.ReadAllText("C:\\teste\\Curso\\clientes.json");

        clientes = JsonSerializer.Deserialize<List<Cliente>>(clientesJson, options);
    }

    private static void SalvarDados()
    {
        JsonSerializerOptions options = new JsonSerializerOptions();
        options.WriteIndented = true;
        options.IncludeFields = true;

        var clientesJson = JsonSerializer.Serialize(clientes, options);
        File.WriteAllText("C:\\teste\\Curso\\clientes.json", clientesJson);
    }

    private static void ListarAtendimentos()
    {
        for (int i = 0; i < atendimentos.Count; i++)
        {
            Atendimento atendimento = atendimentos[i];

            Console.WriteLine($"Atendimento Nº ({i + 1})");
            Console.WriteLine($"Nome do Cliente: {atendimento.cliente.nome}");
            Console.WriteLine($"Nome do Hospital: {atendimento.hospital.nome}");
            Console.WriteLine($"Data de Atendimento: {atendimento.dataAtendimento}");
            Console.WriteLine($"-----------------------------------");


        }
    }

    private static void AtenderCliente()
    {
        Console.WriteLine("Digite o código do cliente:");
        int codigoCliente = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o código do hospital:");
        int codigoHospital = int.Parse(Console.ReadLine());

        Cliente cliente = clientes[codigoCliente - 1];
        Hospital hospital = hospitais[codigoHospital - 1];

        Atendimento atendimento = hospital.Atender(cliente);

        atendimentos.Add(atendimento);
    }

    static void CadastrarHospital()
    {

        Console.WriteLine("Digite o nome do hospital: ");
        string nome = Console.ReadLine();

        Console.WriteLine("Digite o endereco do hospital: ");
        string endereco = Console.ReadLine();

        Console.WriteLine("Digite o telefone do hospital: ");
        string telefone = Console.ReadLine();

        Hospital hospital = new Hospital(nome, telefone);
        hospital.endereco = endereco;

        hospitais.Add(hospital);
    }
    static void ListarHospital()
    {
        for (int i = 0; i < hospitais.Count; i++)
        {
            Hospital hospital = hospitais[i];

            Console.WriteLine($"Hospital Nº ({i + 1})");
            Console.WriteLine($"Nome: {hospital.nome}");
            Console.WriteLine($"Telefone: {hospital.telefone}");
            Console.WriteLine($"Endereço: {hospital.endereco}");
            Console.WriteLine($"-----------------------------------");


        }
    }
    static void ExibirMenu()
    {
        Console.WriteLine("Escolha um dos menus abaixo: ");
        Console.WriteLine("1 - Cadastrar Cliente");
        Console.WriteLine("2 - Listar Clientes");
        Console.WriteLine("3 - Cadastrar Hospital");
        Console.WriteLine("4 - Listar Hospital");
        Console.WriteLine("5 - Atender CLiente");
        Console.WriteLine("0 - Sair");
    }

    static void ListarClientes()
    {
        for (int i = 0; i < clientes.Count; i++)
        {
            Cliente cliente = clientes[i];

            Console.WriteLine($"Cliente Nº ({i + 1})");
            Console.WriteLine($"Nome: {cliente.nome}");
            Console.WriteLine($"Telefone: {cliente.telefone}");
            Console.WriteLine($"Rg: {cliente.rg}");
            Console.WriteLine($"Endereço: {cliente.endereco}");
            string possui = cliente.possuiPlanoDeSaude ? "Sim" : "Não";
            Console.WriteLine($"Possui Plano?: {possui}");
            Console.WriteLine($"-----------------------------------");
        }
    }

    static void CadastrarCliente()
    {
        Console.WriteLine("Digite o nome do cliente: ");
        string nome = Console.ReadLine();

        Console.WriteLine("Digite o rg do cliente: ");
        string rg = Console.ReadLine();

        Console.WriteLine("Digite o cpf do cliente: ");
        string cpf = Console.ReadLine();

        Console.WriteLine("Digite o telefone do cliente: ");
        string telefone = Console.ReadLine();

        Console.WriteLine("Digite o endereço do cliente: ");
        string endereco = Console.ReadLine();

        Console.WriteLine("Cliente possui plano de saúde?(s/n): ");
        string possuiPlano = Console.ReadLine();
        bool possuiPlanoSaude = false;

        if (possuiPlano == "s")
        {
            possuiPlanoSaude = true;
        }

        Cliente cliente = new Cliente(nome, cpf, possuiPlanoSaude);

        cliente.rg = rg;
        cliente.telefone = telefone;
        cliente.endereco = endereco;

        clientes.Add(cliente);
    }
}

