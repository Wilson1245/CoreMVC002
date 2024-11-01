using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreMVC002.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreMVC002.Controllers
{
    public class GameController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            // 初始化秘密數字
            string secretNumber = GenerateSecretNumber();

            // 在 Terminal 中 log 出 secretNumber
            Console.WriteLine("Generated Secret Number--> " + secretNumber);

            // 傳遞到 View 內部後再回到 Controller
            TempData["secretNumber"] = secretNumber;
            TempData["count"] = 0;
            TempData["guessHistory"] = new List<string>();
            // 創建猜測模型: 猜測數字+比對結果+比對邏輯
            var model = new XAXBEngine(secretNumber);

            // 使用強型別
            return View(model);
        }

        [HttpPost]
        public ActionResult Guess(XAXBEngine model)
        {
            
            // 從 TempData 中獲取 count，並初始化為 0 如果為 null
            int count = TempData["count"] as int? ?? 0;
            // 更新 count 並存回 model
            model.Count = count + 1;
            Console.WriteLine("Count: " + model.Count);
            // 更新 TempData["count"] 以保存新的值
            TempData["count"] = model.Count;

            // 檢查猜測結果
            model.Result = GetGuessResult(model.Guess);

            // 從 TempData 中獲取 GuessHistory，或初始化為空列表
            List<string> GuessHistory = model.GuessHistory;
            // 將當前猜測添加到歷史記錄中
            GuessHistory.Add($"Guess: {model.Guess}, Result: {model.Result}");
            model.GuessHistory = GuessHistory;
            // 將更新後的歷史記錄保存回 TempData
            TempData["guessHistory"] = model.GuessHistory;

            // 回傳到 Index View，傳入 model
            return View("Index", model);
        }

        // ------ 遊戲相關之邏輯 ------
        private string GenerateSecretNumber()
        {
            Random random = new Random();
            int secretNumber = random.Next(1000, 10000); // 生成介於 1000 到 9999 之間的隨機四位數
            return secretNumber.ToString();
        }

        private string GetGuessResult(string guess)
        {
            // 檢查猜測結果，並返回結果字符串
            string secretNumber = TempData["secretNumber"] as string ?? string.Empty;
            // 利用Keep(...) 方法, or 再次回存！
            // TempData["SecretNumber"] = secretNumber;
            TempData.Keep("SecretNumber");

            // 你可以根據遊戲規則自定義檢查邏輯
            if (secretNumber.Equals(guess))
                return "正確";
            else
                return "錯誤";
        }
    }
}

