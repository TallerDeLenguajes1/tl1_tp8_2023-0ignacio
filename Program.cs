// See https://aka.ms/new-console-template for more information

using espacioTareas;
using System.IO;


List<tareas> TareasPendientes = new List<tareas>();
List<tareas> TareasRealizadas = new List<tareas>();
Random rnd = new Random();
int ntareas = rnd.Next(1, 4);
int duracion = 0;
string? desc;
int sel = 100;


for (int i = 0; i < ntareas; i++)
{
    Console.WriteLine("Tarea numero" + (i + 1));
    Console.WriteLine("Descripcion: ");
    desc = Console.ReadLine();
    duracion = rnd.Next(10, 101);
    tareas tarea = new tareas(i + 1, desc, duracion);
    TareasPendientes.Add(tarea);
}

void mostrarTareas(List<tareas> listaDeTareas)
{
    foreach (tareas tarea in listaDeTareas)
    {
        Console.WriteLine("Tarea ID: " + tarea.Id);
        Console.WriteLine("Descripcion: " + tarea.Desc);
        Console.WriteLine("Duracion: " + tarea.Duracion);
    }
}

void moverTarea()
{
    mostrarTareas(TareasPendientes);
    int aux;
    Console.WriteLine("Ingrese el id de la tarea que quiere mover: ");
    int.TryParse(Console.ReadLine(), out aux);

    tareas? tareaAux = TareasPendientes.Find(x => x.Id == aux);
    if (tareaAux != null)
    {
        TareasRealizadas.Add(tareaAux);
        TareasPendientes.Remove(tareaAux);

    }
}

void buscarDesc()
{
    string? aux;
    Console.WriteLine("Ingrese la descripcion de la tarea que quiere buscar: ");
    aux = Console.ReadLine();
    tareas? tareaAux = TareasPendientes.Find(x => x.Desc == aux);
    tareas? tareaAux2 = TareasRealizadas.Find(x => x.Desc == aux);

    if (tareaAux != null || tareaAux2 != null)
    {
        if (tareaAux != null)
        {
            Console.WriteLine("Tarea pendiente");
            Console.WriteLine("Tarea ID: " + tareaAux.Id);
            Console.WriteLine("Descripcion: " + tareaAux.Desc);
            Console.WriteLine("Duracion: " + tareaAux.Duracion);
        }else{
            Console.WriteLine("Tarea realizada");
            Console.WriteLine("Tarea ID: " + tareaAux2.Id);
            Console.WriteLine("Descripcion: " + tareaAux2.Desc);
            Console.WriteLine("Duracion: " + tareaAux2.Duracion);
        }
    }else{
        Console.WriteLine("No se encontro la tarea");
    }
}

while (sel != 0)
{
    Console.WriteLine("-- Menu --\n0- Salir\n1- Mostrar tareas pendientes\n2- Mostrar tareas realizadas\n3- Mover una tarea\n4- Buscar Tarea por descripcion");
    Console.WriteLine("Ingrese una opcion: ");
    int.TryParse(Console.ReadLine(), out sel);
    switch (sel)
    {
        case 1:
            mostrarTareas(TareasPendientes);
            break;
        case 2:
            mostrarTareas(TareasRealizadas);
            break;
        case 3:
            moverTarea();
            break;
        case 4:
            buscarDesc();
            break;
        default:
            break;
    }
}

StreamWriter sw = new StreamWriter("sumario.txt");
int auxHoras = 0;
foreach (tareas tarea in TareasRealizadas)
    {
        auxHoras += tarea.Duracion;
    }
sw.WriteLine("Horas trabajadas: "+ auxHoras);
sw.Close();