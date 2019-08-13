using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace greenmoney_test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Task1()
        {
            List<String> result_list = new List<String>();
            for (int index = 0; index < 127; index++) {
                String result = String.Format("{0}", index);

                if (index % 3 == 0) {
                    result = "Green";
                }
                if (index % 5 == 0) {
                    result = "Money";
                }
                if (index % 15 == 0) {
                    result = "GreenMoney";
                }
                if (index == 0) {
                    result = "0";
                }

                result_list.Add(result);
            }

            ViewBag.result_list = result_list;

            return View();
        }

        public ActionResult Task2()
        {
            // Количество цифр после запятой.
            const int digit_after_point = 100;
            // Верхнее значение для случайного числа.
            const double max_value = 0.6;

            List<String> number_list = new List<String>();
            Random random = new Random();

            // Случайное число, большее нуля и меньшее заданного верхнего предела.
            int rnd = random.Next(1, (int)(digit_after_point * max_value));
            number_list.Add(String.Format("{0}", rnd / (double)digit_after_point));

            int sum = rnd;
            while (sum != digit_after_point) {
                // Верхнее значение для случайного числа = 1 - сумма чисел ряда, но не бошьше заданного верхнего предела.
                int max = Math.Min((int)(digit_after_point * max_value), digit_after_point - sum);

                rnd = random.Next(1, max);
                number_list.Add(String.Format("{0}", rnd / (double)digit_after_point));

                sum += rnd;
            }

            ViewBag.number_list = number_list;
            return View();
        }

        public ActionResult Task3()
        {
            ViewBag.Data = "";

            return View();
        }

        [HttpPost]
        public ActionResult Task3(String input_data_string) {
            // Массив букв английского алфавита.
            char[] english_alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            // Получение массива входных данных, преобразованных в нижний регистр.
            char[] input_data = input_data_string.ToLower().ToCharArray();

            // Проверка длины массива входящих данных.
            if (input_data.Length == 0) {
                ViewBag.Data = "Массив входящих данных пуст";
                return View();
            }

            // Проверка массива входящих данных на наличие символов, не относящиеся к буквам английского алфавита.
            for (int index = 0; index < input_data.Length; index++) {
                if (Array.IndexOf(english_alphabet, input_data[index]) == -1) {
                    ViewBag.Data = "В массиве входящих данных присутствуют символы, не относящиеся к буквам английского алфавита";
                    return View();
                }
            }

            // Проверка длины массива входящих данных.
            if (input_data.Length == 0) {
                ViewBag.Data = "Массив входящих данных пуст";
                return View();
            }

            // Сортировка входящего массива.
            Array.Sort(input_data);

            // Перебор алфавита.
            String result = "";
            int alphabet_index = Array.IndexOf(english_alphabet, input_data[0]) + 1;
            int data_index = 1;
            char prev_value = input_data[0];
            for (int index = alphabet_index; index < english_alphabet.Length; index++) {
                // Если массив входящих данных закончился.
                if (data_index == input_data.Length) {
                    break;
                }
                // Проверка на дубликаты.
                if (input_data[data_index] == prev_value) {
                    ViewBag.Data = "В массиве входящих данных присутствуют дубликаты символв";
                    return View();
                }

                // Если сравниваемые символы идентичны.
                if (english_alphabet[index] == input_data[data_index]) {
                    prev_value = input_data[data_index];
                    data_index++;
                } else {
                    result += english_alphabet[index];
                }
            }

            ViewBag.Data = String.Format("Пропущенные буквы в массиве входящих данных: '{0}'", result);
            return View();
        }

        public ActionResult Task4() {
            int[] array_a = new int[5] { 1, 2, 3, 4, 5 };
            int[] array_b = new int[5] { 5, 6, 2, 8, 9 };

            var query_result = from x in array_a.Intersect(array_b)
                               let square = x * x
                               select new { x, square };

            string result = "";
            foreach (var item in query_result) {
                result += String.Format("{0}", item);
            }

            ViewBag.Data = result;
            return View();
        }
    }
}