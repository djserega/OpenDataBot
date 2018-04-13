using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenDataBotAPI;

namespace OpenDataBot
{
    class Program
    {

        private static API_20 _openDataBot = new API_20();

        static void Main(string[] args)
        {
            int? action = null;

            while (action != 0)
            {
                if (!_openDataBot.APIKeyIsSet)
                {
                    Console.WriteLine("Введите apikey:");
                    string apiKey = Console.ReadLine();
                    _openDataBot.APIKey = apiKey;
                    Console.Clear();
                }
                else
                {
                    WriteListAction();
                    try
                    {
                        action = int.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        action = null;
                    }

                    try
                    {
                        switch (action)
                        {
                            case -1:
                                _openDataBot.APIKey = string.Empty;
                                break;
                            case 1:
                                GetInfoFop();
                                break;
                            case 2:
                                GetInfoCompany();
                                break;
                            case 3:
                                GetInfoFullCompany();
                                break;
                            default:
                                Console.Clear();
                                Console.WriteLine("Ошибка определения действия.");
                                break;
                        }

                        if (_openDataBot.Error)
                            Console.WriteLine(_openDataBot.ErrorText);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка ввода/получения иформации.");
                        Console.WriteLine(ex.Message);
                    }
                }
            };

        }

        private static void WriteListAction()
        {
            Console.WriteLine("Доступные действия:");
            Console.WriteLine("-1 - ввести apikey");
            Console.WriteLine("0 - завершение работы");
            Console.WriteLine("1 - получить данные ФОП");
            Console.WriteLine("2 - получить данные Компании");
            Console.WriteLine("3 - получить полную информацию о Компании");
        }

        private static void GetInfoFop()
        {
            Console.WriteLine("Введите ИНН:");
            _openDataBot.GetFop(Console.ReadLine());
            if (!_openDataBot.Error)
                Console.WriteLine(_openDataBot.Fop.Full_name);
            Console.WriteLine();
        }

        private static void GetInfoCompany()
        {
            Console.WriteLine("Введите ЕДРПОУ:");
            _openDataBot.GetCompany(Console.ReadLine());

            if (!_openDataBot.Error)
                while (_openDataBot.NextCompany())
                {
                    Console.WriteLine(_openDataBot.Company.Full_name);
                    Company company = _openDataBot.Company;
                    while (company.NextBeneficiaries())
                        Console.WriteLine(company.CurrentBeneficiaries.Title);
                }
            Console.WriteLine();
        }

        private static void GetInfoFullCompany()
        {
            Console.WriteLine("Введите ЕДРПОУ:");
            _openDataBot.GetFullCompany(Console.ReadLine());
            if  (!_openDataBot.Error)
                Console.WriteLine(_openDataBot.FullCompany.Full_name);
        }
    }

}
