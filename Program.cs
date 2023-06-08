// See https://aka.ms/new-console-template for more information
using System.IO;

List<string> archivos = Directory.GetFiles(@"C:\tp8\tl1_tp8_2023-0ignacio").ToList();
int cont = 0;
StreamWriter sw = new StreamWriter("index.csv");
foreach (string archivo in archivos)
{
    cont++;
    string[] partes = archivo.Split('.');
    string[] partes2 = archivo.Split(@"\");
    sw.WriteLine(cont+","+partes2[3]+","+partes[1]);
}

sw.Close();