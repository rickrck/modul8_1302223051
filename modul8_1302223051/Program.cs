using System.Text.Json;
using modul8_1302223051;

internal class Program
{
    private static void Main()
    {
        BankTransferConfig config = new BankTransferConfig();
        int total = 0;
        if (config.config.lang == "en")
        {
            Console.Write("Please insert the amount of money to transfer: ");
        } else if (config.config.lang == "id")
        {
            Console.Write("Masukkan jumlah uang yang akan di-transfer: ");
        }

        int nominal_transfer = int.Parse(Console.ReadLine());

        if (nominal_transfer <= config.config.transfer.threshold)
        {
            if (config.config.lang == "en")
            {
                Console.WriteLine("Transfer fee : " + config.config.transfer.low_fee);
                Console.WriteLine("Total amount : " + (nominal_transfer + config.config.transfer.low_fee));
            } else if (config.config.lang == "id")
            {
                Console.WriteLine("Biaya transfer : " + config.config.transfer.low_fee);
                Console.WriteLine("Total: " + (nominal_transfer + config.config.transfer.low_fee));
            }
        }
        else
        {
            if (config.config.lang == "en")
            {
                Console.WriteLine("Transfer fee : " + config.config.transfer.high_fee);
                Console.WriteLine("Total amount : " + (nominal_transfer + config.config.transfer.high_fee));
            }
            else if (config.config.lang == "id")
            {
                Console.WriteLine("Biaya transfer : " + config.config.transfer.high_fee);
                Console.WriteLine("Total: " + (nominal_transfer + config.config.transfer.high_fee));
            }
        }

        if (config.config.lang == "en")
        {
            Console.WriteLine("Select transfer method : ");
        }
        else if (config.config.lang == "id")
        {
            Console.WriteLine("Pilih metode transfer : ");
        }

        for (int i = 0; i < config.config.methods.Length; i++)
        {
            Console.WriteLine(i + 1 + ". " + config.config.methods[i]);
        }

        Console.ReadLine();

        String confirm;
        if (config.config.lang == "en")
        {
            Console.WriteLine("Please type " + config.config.confirmation.en + " to confirm the transaction: ");
        }
        else if (config.config.lang == "id")
        {
            Console.WriteLine("Ketik " + config.config.confirmation.en + " untuk mengkonfirmasi transaksi: ");
        }

        confirm = Console.ReadLine();

        if (config.config.lang == "en")
        {
            if (confirm == config.config.confirmation.en)
            {
                Console.WriteLine("The transfer is completed");
            }
            else
            {
                Console.WriteLine("Transfer is cancelled");
            }
        }
        else if (config.config.lang == "id")
        {
            if (confirm == config.config.confirmation.id)
            {
                Console.WriteLine("Proses transfer berhasil");
            }
            else
            {
                Console.WriteLine("Transfer dibatalkan");
            }
        }
    }
}