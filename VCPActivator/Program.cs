using System;
using System.Text;
using System.Management;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic;
using System.Security.Cryptography;
using System.IO;

namespace VCPActivator
{
    class Program
    {
        static void Main(string[] args)
        {
            Activator act = new Activator();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Title = "Program4Pc Video Converter Pro Activator";
            const string title = @"
                ╦ ╦╦═╗╔═╗╔╦╗
                ║ ║╠╦╝║╣  ║ 
                ╚═╝╩╚═╚═╝ ╩ 
------------------------------------------------
 Program4Pc Video Converter Pro 9.8.6 Activator
 RCE by vikram
------------------------------------------------
 ";
            Console.Write(title);
            act.Activate();
            Console.WriteLine(" Congrats! Activated your copy.\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Block the app in firewall.\n");
            System.Threading.Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(" Enter any key to exit.");
            Console.ReadKey();
        }

    }

    class Activator
    {

        public void Activate()
        {

            string ActivationCode = "X0C5555";
            //Console.WriteLine(" Using Key {0} ", ActivationCode);
            //System.Threading.Thread.Sleep(1000);
            string text = GetDriveSerialNumber();
            Console.WriteLine(" Retriving system configuration.");
            if (Operators.CompareString(text, "", false) == 0)
            {
                text = "GEN-" + Strings.UCase(RandomHDDSerial(15));
            }
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine(" Generating Activation data.");
            SetValue("HKEY_CURRENT_USER\\Software\\Program4Pc\\Video Converter Pro\\", "Data", GetEncryptedString(ActivationCode + "," + text, "Can not read the file!"));
            System.Threading.Thread.Sleep(1500);
        }



        private void SetValue(string keyName, string valueName, object value)
        {
            Microsoft.Win32.Registry.SetValue(keyName, valueName, value);
        }

        private static string RandomHDDSerial(int length)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string[] array = new string[]
            {
        "a",
        "b",
        "c",
        "d",
        "e",
        "f",
        "g",
        "h",
        "i",
        "j",
        "k",
        "l",
        "m",
        "n",
        "o",
        "p",
        "q",
        "r",
        "s",
        "t",
        "u",
        "v",
        "w",
        "x",
        "y",
        "z",
        "A",
        "B",
        "C",
        "D",
        "E",
        "F",
        "G",
        "H",
        "I",
        "J",
        "K",
        "L",
        "M",
        "N",
        "O",
        "P",
        "Q",
        "R",
        "S",
        "T",
        "U",
        "V",
        "W",
        "X",
        "Y",
        "X",
        "1",
        "2",
        "3",
        "4",
        "5",
        "6",
        "7",
        "8",
        "9",
        "0"
            };
            int num = Information.UBound(array, 1);
            VBMath.Randomize();
            checked
            {
                for (int i = 1; i <= length; i++)
                {
                    stringBuilder.Append(array[(int)Conversion.Int(unchecked(VBMath.Rnd() * (float)num))]);
                }
                return stringBuilder.ToString();
            }
        }

        private static string GetDriveSerialNumber()
        {
            string result;
            try
            {
                ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("select * from Win32_DiskDrive");
                string text = "";
                try
                {
                    foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
                    {
                        ManagementObject managementObject = (ManagementObject)managementBaseObject;
                        if (Operators.CompareString(Strings.Trim(managementObject["SerialNumber"].ToString()), "", false) != 0 & Strings.Len(managementObject["SerialNumber"].ToString()) > 5)
                        {
                            text = Strings.Trim(managementObject["SerialNumber"].ToString());
                            break;
                        }
                    }
                }
                finally
                {
                    //ManagementObjectCollection.ManagementObjectEnumerator enumerator; 
                    //if (enumerator != null)
                    //{
                    //    ((IDisposable)enumerator).Dispose();
                    //}
                }
                result = text;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = "";
            }
            return result;
        }

        public static string GetEncryptedString(string Text, string Key)
        {
            string result;
            try
            {
                result = new Simple3Des(Key).EncryptData(Text);
            }
            catch (Exception ex)
            {

                Console.WriteLine(string.Concat(new string[]
                {
            ex.Message,
            "\\Activate\\GetEncryptedString\\",
            Text,
            "-",
            Key,
            "\\"
                }));
                result = "";
            }
            return result;
        }
    }

    public class Simple3Des : IDisposable
    {
        private TripleDESCryptoServiceProvider TripleDes;

        private bool disposedValue;

        private byte[] TruncateHash(string key, int length)
        {
            byte[] result;
            try
            {
                HashAlgorithm hashAlgorithm = new SHA1CryptoServiceProvider();
                byte[] bytes = Encoding.Unicode.GetBytes(key);
                result = (byte[])Utils.CopyArray(hashAlgorithm.ComputeHash(bytes), new byte[checked(length - 1 + 1)]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = null;
            }
            return result;
        }

        public Simple3Des(string key)
        {
            this.TripleDes = new TripleDESCryptoServiceProvider();
            this.TripleDes.Key = this.TruncateHash(key, this.TripleDes.KeySize / 8);
            this.TripleDes.IV = this.TruncateHash("", this.TripleDes.BlockSize / 8);
        }

        public string EncryptData(string plaintext)
        {
            string result;
            try
            {
                byte[] bytes = Encoding.Unicode.GetBytes(plaintext);
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, this.TripleDes.CreateEncryptor(), CryptoStreamMode.Write);
                cryptoStream.Write(bytes, 0, bytes.Length);
                cryptoStream.FlushFinalBlock();
                result = Convert.ToBase64String(memoryStream.ToArray());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\\EnDecrypt\\EncryptData\\" + plaintext + "\\");
                result = "";
            }
            return result;
        }

        public string DecryptData(string encryptedtext)
        {
            string result;
            try
            {
                byte[] array = Convert.FromBase64String(encryptedtext);
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, this.TripleDes.CreateDecryptor(), CryptoStreamMode.Write);
                cryptoStream.Write(array, 0, array.Length);
                cryptoStream.FlushFinalBlock();
                result = Encoding.Unicode.GetString(memoryStream.ToArray());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\\EnDecrypt\\DecryptData\\" + encryptedtext + "\\");
                result = "";
            }
            return result;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue && disposing)
            {
                this.TripleDes.Dispose();
            }
            this.disposedValue = true;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
