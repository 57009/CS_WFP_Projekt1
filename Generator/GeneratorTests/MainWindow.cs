using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeneratorTests
{
    [TestClass]
    public class MainWindow
    {
        [TestMethod]
        public void TestRandomString()
        {
           int range = 3;

           var chars = "abcdefghijklmnopqrstuwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                var random = new Random();
                var result = new string(
                    Enumerable.Repeat(chars, range)
                                .Select(s => s[random.Next(s.Length)])
                                .ToArray());

            int resultLength = result.Length; // ilość wygenerowanych znaków
            Assert.AreEqual(range, resultLength); //jeśli ilość wygenerownych znaków jest równa ilosci range, then OK
        }

        [TestMethod]
        public void TestGetUniqueKey()
        {
            int maxSize = 5;

            char[] chars = new char[62];
            chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetBytes(data);
            data = new byte[maxSize];
            crypto.GetBytes(data);
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }

            var res =  result.ToString();

            int resultLength = res.Length; // ilość wygenerowanych znaków
            Assert.AreEqual(maxSize, resultLength); //jeśli ilość wygenerownych znaków jest równa ilosci range, then OK
        }

        [TestMethod]
        public void GuidString()
        {
            int numOfCharsNeeded = 33;
            string result = "";

            if (numOfCharsNeeded <= 32)
                result = Guid.NewGuid().ToString("n").Substring(0, numOfCharsNeeded);
            else
            {
                int f = numOfCharsNeeded / 32 + 1;
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i <= f; i++)
                {
                    sb.Append(Guid.NewGuid().ToString("n"));
                }

                result = sb.ToString().Remove(numOfCharsNeeded);
            }
            Console.Write(result);
            int resultLength = result.Length; // ilość wygenerowanych znaków
            Assert.AreEqual(numOfCharsNeeded, resultLength); //jeśli ilość wygenerownych znaków jest równa ilosci range, then OK
        }




    }
}
