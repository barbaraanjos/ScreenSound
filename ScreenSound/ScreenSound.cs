// Screen Sound
string mensagemDeBoasVindas = "Boas vindas ao Screen Sound";
Dictionary<string, List<int>> registroDeBandas = new Dictionary<string, List<int>>();

void ExibirLogo()
{
	Console.WriteLine(@"
█▀ █▀▀ █▀█ █▀▀ █▀▀ █▄░█   █▀ █▀█ █░█ █▄░█ █▀▄
▄█ █▄▄ █▀▄ ██▄ ██▄ █░▀█   ▄█ █▄█ █▄█ █░▀█ █▄▀
");
	Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirTituloDaOpcao(string titulo)
{
	int quantidadeDeLetrasDoTitulo = titulo.Length;
	string asteriscos = string.Empty.PadLeft(quantidadeDeLetrasDoTitulo, '*');
	Console.WriteLine(asteriscos);
	Console.WriteLine(titulo);
	Console.WriteLine(asteriscos + "\n");
}

void ExibirOpcoesDoMenu()
{
	ExibirLogo();

	Console.WriteLine("\nDigite 1 para registrar uma banda");
	Console.WriteLine("Digite 2 para mostrar todas as bandas");
	Console.WriteLine("Digite 3 para avaliar uma banda");
	Console.WriteLine("Digite 4 para exibir a média de uma banda");
	Console.WriteLine("Digite -1 para sair");

	Console.Write("\nDigite a sua opção: ");
	string opcaoEscolhida = Console.ReadLine()!;
	int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

	switch (opcaoEscolhidaNumerica)
	{
		case 1:
			RegistrarBanda();
			break;
		case 2:
			ExibirBandasRegistradas();
			break;
		case 3:
			AvaliarBanda();
			break;
		case 4:
			ExibirNotaMediaDaBanda();
			break;
		case -1:
			Console.WriteLine("Até a próxima!");
			break;
		default:
			Console.WriteLine("Opção inválida");
			break;
	}
}

void RegistrarBanda()
{
	Console.Clear();
	ExibirTituloDaOpcao("Registro das bandas");
	Console.Write("Digite o nome da banda que deseja registrar: ");

	string nomeDaBanda = Console.ReadLine()!;
	registroDeBandas.Add(nomeDaBanda, new List<int>());
	Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso.");
	Thread.Sleep(2000);

	Console.Clear();
	ExibirOpcoesDoMenu();
}

void ExibirBandasRegistradas()
{
	Console.Clear();
	ExibirTituloDaOpcao("Exibindo todas as bandas registradas");

	foreach(string banda in registroDeBandas.Keys)
	{
		Console.WriteLine($"Banda: {banda}");
	}

	if (registroDeBandas.Count <= 0)
		Console.WriteLine("Não existem bandas registradas.");

	Console.WriteLine("\nPrecione qualquer tecla para voltar ao menu principal");
	Console.ReadKey();
	Console.Clear();
	ExibirOpcoesDoMenu();
}

void AvaliarBanda()
{
	Console.Clear();
	ExibirTituloDaOpcao("Avaliar banda");
	Console.Write("Digite o nome da banda que deseja avaliar: ");
	string nomeDaBanda = Console.ReadLine()!;

	if (registroDeBandas.ContainsKey(nomeDaBanda))
	{
		Console.Write($"Qual a sua nota para a banda {nomeDaBanda}? ");
		int nota = int.Parse(Console.ReadLine()!);
		registroDeBandas[nomeDaBanda].Add(nota);
		Console.WriteLine($"\nA nota {nota} para a banda {nomeDaBanda} foi registrada com sucesso.");
		Thread.Sleep(8000);
		Console.Clear();
		ExibirOpcoesDoMenu();
	}
	else
	{
		Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada.");
		Console.WriteLine("\nPrecione qualquer tecla para voltar ao menu principal"); 
		Console.ReadKey();
		Console.Clear();
		ExibirOpcoesDoMenu();
	}
}

void ExibirNotaMediaDaBanda()
{
	Console.Clear();
	ExibirTituloDaOpcao("Nota média da banda");
	Console.Write("Digite o nome da banda que deseja: ");
	string nomeDaBanda = Console.ReadLine()!;

	if (registroDeBandas.ContainsKey(nomeDaBanda))
	{
		List<int> notas = registroDeBandas[nomeDaBanda];
		Console.WriteLine($"\nA média da banda {nomeDaBanda} é {notas.Average()}.");
		Thread.Sleep(8000);
		Console.Clear();
		ExibirOpcoesDoMenu();
	}
	else
	{
		Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada.");
		Console.WriteLine("\nPrecione qualquer tecla para voltar ao menu principal");
		Console.ReadKey();
		Console.Clear();
		ExibirOpcoesDoMenu();
	}
}

ExibirOpcoesDoMenu();
