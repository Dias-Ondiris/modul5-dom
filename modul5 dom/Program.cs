using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace modul5_dom
{
    internal class Program
    {
        static void CallMethod()
        {
            Call2Method();
        }

        static void Call2Method()
        {
            throw new Exception("Ошибка в Call2Method");
        }
        static void InvokeMethod()
        {
            AnotherMethod();
        }

        static void AnotherMethod()
        {
            throw new Exception("Ошибка в AnotherMethod");
        }
        static async Task<string> HTTpGetStringAsync(string url)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(url);
            return response;
        }
        static void Main(string[] args)
        {
            ///1
            string url = "https://glaucoma_iict.com"; 
            try
            {
                
                Console.WriteLine(HTTpGetStringAsync(url));
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Ошибка при запросе: {e.Message}");
            }

            ///2
            int[] array = new int[5] { 1, 2, 3, 4, 5 };

            try
            {
                Console.WriteLine(array[10]); 
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine($"Ошибка индексации: {e.Message}");
            }
            finally
            {
                Console.WriteLine("Завершение обработки массива.");
            }
            ///3
            try
            {
                CallMethod();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка в методе Main: {e.Message}");
            }
            ///4
            try
            {
                InvokeMethod();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка в методе Main: {e.Message}");
            }
            Console.ReadKey();
        }
    }
}
