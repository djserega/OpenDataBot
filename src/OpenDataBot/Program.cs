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
                                Console.WriteLine("Введите ИНН:");
                                _openDataBot.GetFop(Console.ReadLine());
                                Console.WriteLine();
                                WriteListAction();
                                break;
                            case 2:
                                Console.WriteLine("Введите ЕДРПОУ:");
                                _openDataBot.GetCompany(Console.ReadLine());
                                Console.WriteLine();
                                WriteListAction();
                                break;
                            default:
                                Console.Clear();
                                Console.WriteLine("Ошибка определения действия.");
                                WriteListAction();
                                break;
                        }

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
        }

    }
}
