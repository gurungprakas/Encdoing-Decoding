using System;
using System.Linq;
using Conversion.Models;

namespace Conversion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your full name: ");
            string name = Console.ReadLine();
            int[] cipher = new[] { 1, 1, 2, 3, 5, 8, 13 }; //Fibonacci Sequence
            string cipherasString = String.Join(",", cipher.Select(x => x.ToString())); //FOr display

            int encryptionDepth = 20;

            //binary conversion
            BinaryConverter binaryConverter = new BinaryConverter();
            string binaryValue = binaryConverter.ConvertTo(name);
            Console.WriteLine($"{name} as Binary: {binaryValue}");
            Console.WriteLine("Enter Binary Version of your Name: ");
            string binaryName = Console.ReadLine();
            Console.WriteLine($"{binaryName} from Binary to ASCII: {binaryConverter.ConvertBinaryToString(binaryValue)}");

            //hex conversion
            HexadecimalConverter hexadecimalConverter = new HexadecimalConverter();
            string hexadecimalValue = hexadecimalConverter.ConvertTo(name);
            Console.WriteLine($"{name} as Hexadecimal: {hexadecimalValue}");
            Console.WriteLine($"{name} from Hexadecimal to ASCII: {hexadecimalConverter.ConveryFromHexToASCII(hexadecimalValue)}");

            //base64 conversion
            Base64Converter base64Converter = new Base64Converter();
            string nameBase64Encoded = base64Converter.StringToBase64(name);
            Console.WriteLine($"{name} as Base64: {nameBase64Encoded}");

            //Output the decoded Base64 string

            string nameBase64Decoded = base64Converter.Base64ToString(nameBase64Encoded);
            Console.WriteLine($"{name} from Base64 to ASCIII: {nameBase64Decoded}");

            //ciphering
            Encrypter encrypter = new Encrypter(name, cipher, encryptionDepth);

            //Single Level Encrytion
            string nameEncryptWithCipher = Encrypter.EncryptWithCipher(name, cipher);
            Console.WriteLine($"Encrypted once using the cipher {{{cipherasString}}} {nameEncryptWithCipher}");

            string nameDecryptWithCipher = Encrypter.DecryptWithCipher(nameEncryptWithCipher, cipher);
            Console.WriteLine($"Decrypted once using the cipher {{{cipherasString}}} {nameDecryptWithCipher}");

            //Deep Encrytion
            string nameDeepEncryptWithCipher = Encrypter.DeepEncryptWithCipher(name, cipher, encryptionDepth);
            Console.WriteLine($"Deep Encrypted {encryptionDepth} times using the cipher {{{cipherasString}}} {nameDeepEncryptWithCipher}");

            string nameDeepDecryptWithCipher = Encrypter.DeepDecryptWithCipher(nameDeepEncryptWithCipher, cipher, encryptionDepth);
            Console.WriteLine($"Deep Decrypted {encryptionDepth} times using the cipher {{{cipherasString}}} {nameDeepDecryptWithCipher}");

            //Base64 Encoded
            Console.WriteLine($"Base64 encoded {name} {encrypter.Base64}");

            string base64toPlainText = Encrypter.Base64ToString(encrypter.Base64);
            Console.WriteLine($"Base64 decoded {encrypter.Base64} {base64toPlainText}");
        }
    }
}
