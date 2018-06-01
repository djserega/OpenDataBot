using System;
using System.Text;
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
                                GetStatistic();
                                break;
                            case 2:
                                GetInfoFop();
                                break;
                            case 3:
                                GetInfoCompany();
                                break;
                            case 4:
                                GetInfoFullCompany();
                                break;
                            case 5:
                                GetInfoChanges();
                                break;
                            case 6:
                                GetPersonalInfo();
                                break;
                            default:
                                Console.Clear();
                                Console.WriteLine("Ошибка определения действия.");
                                break;
                        }

                        if (_openDataBot.Error
                            && action != null
                            && action != -1)
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
            Console.WriteLine("1 - статистика");
            Console.WriteLine("2 - данные ФОП");
            Console.WriteLine("3 - данные Компании");
            Console.WriteLine("4 - полная информация о Компании");
            Console.WriteLine("5 - изменения компании");
            Console.WriteLine("6 - персональная информацияю");
        }

        private static void GetStatistic()
        {
            _openDataBot.GetStatistic();
            if (!_openDataBot.Error)
                Console.WriteLine(_openDataBot.Fop.Full_name);
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
                    OpenDataBotAPI.Company company = _openDataBot.Company;
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

        private static void GetInfoChanges()
        {
            Console.WriteLine("Введите ЕДРПОУ:");
            _openDataBot.GetChanges(Console.ReadLine());
            if (!_openDataBot.Error)
                Console.WriteLine(_openDataBot.Changes.Code);
        }

        private static void GetPersonalInfo()
        {
            Console.WriteLine("Введите ФИО:");
            Console.InputEncoding = Encoding.Default;
            _openDataBot.GetPersonalInfo(Console.ReadLine());
        }
    }
}
