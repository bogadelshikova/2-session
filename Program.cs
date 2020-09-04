using System.IO;
using System.Text;

class Program
{
  static void Main(string[] args)
  {
    string text = "hello world";
    using (FileStream fstream = new FileStream(@"D:\note.dat", FileMode.OpenOrCreate))
    {
      byte[] input = Encoding.Default.GetBytes(text);
      fstream.Write(input, 0, input.Length);
      Console.WriteLine("Текст записан в файл");
      fstream.Seek(-5, SeekOrigin.End); 
      byte[] output = new byte[4];
      fstream.Read(output, 0, output.Length);
      string textFromFile = Encoding.Default.GetString(output);
      Console.WriteLine($"Текст из файла: {textFromFile}"); 
      string replaceText = "house";
      fstream.Seek(-5, SeekOrigin.End); 
      input = Encoding.Default.GetBytes(replaceText);
      fstream.Write(input, 0, input.Length);
      fstream.Seek(0, SeekOrigin.Begin);
      output = new byte[fstream.Length];
      fstream.Read(output, 0, output.Length);
      textFromFile = Encoding.Default.GetString(output);
      Console.WriteLine($"Текст из файла: {textFromFile}");
    }
    Console.Read();
  }
}