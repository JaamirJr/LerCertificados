using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace LerCertificados
{
	class Program
	{
		static void Main(string[] args)
		{
			X509Store store = new X509Store(StoreLocation.CurrentUser);
			store.Open(OpenFlags.OpenExistingOnly);

			X509Certificate2Collection certCollection = store.Certificates;

			foreach (X509Certificate2 c in certCollection)
			{
				try
				{
					Console.WriteLine($"Certificado: {c.Subject}");

					var keyInfo = (c.PrivateKey as RSACryptoServiceProvider).CspKeyContainerInfo;

					Console.WriteLine("Accessible property: " + keyInfo.Accessible);

					Console.WriteLine("Exportable property: " + keyInfo.Exportable);

					Console.WriteLine("HardwareDevice property: " + keyInfo.HardwareDevice);

					Console.WriteLine("KeyContainerName property: " + keyInfo.KeyContainerName);

					Console.WriteLine("KeyNumber property: " + keyInfo.KeyNumber);

					Console.WriteLine("MachineKeyStore property: " + keyInfo.MachineKeyStore);

					Console.WriteLine("Protected property: " + keyInfo.Protected);

					Console.WriteLine("ProviderName property: " + keyInfo.ProviderName);

					Console.WriteLine("ProviderType property: " + keyInfo.ProviderType);

					Console.WriteLine("RandomlyGenerated property: " + keyInfo.RandomlyGenerated);

					Console.WriteLine("Removable property: " + keyInfo.Removable);

					Console.WriteLine("UniqueKeyContainerName property: " + keyInfo.UniqueKeyContainerName);
				}
				catch 
				{
					Console.WriteLine("Erro ao ler dados");
				}
				finally
				{
					Console.WriteLine("----------------------------------------------------------------------------\n");
				}
			}
			store.Close();

			Console.ReadLine();
		}
	}
}
