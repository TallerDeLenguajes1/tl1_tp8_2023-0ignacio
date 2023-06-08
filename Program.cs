// See https://aka.ms/new-console-template for more information
using System.IO;

List<string> archivos = Directory.GetDirectories("C:\tp8\tl1_tp8_2023-0ignacio").ToList();

foreach (string archivo in archivos)
{
    string[] partes = archivo.Split('.');
}
