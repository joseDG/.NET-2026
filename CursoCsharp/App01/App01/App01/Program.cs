string[] canciones =
{
    "Imagge",
    "One",
    "Billie Jean",
    "Hey Ju",
    "God Save the queen",
    "Born to Run",
    "Creep",
    "Yestarday"
};


//creacndo un LikedList
LinkedList<string> cancionesLinkedList = new LinkedList<string>(canciones);

//Agregando elementos al inicio y al fianl de la lista
cancionesLinkedList.AddFirst("Mi primera Cancion");
cancionesLinkedList.AddLast("Mi ultima cancion");

//Imprimir los elemntos de la lista
foreach (string str in canciones)
{
    Console.WriteLine(str);
}

//Buscando el perime y ultimo elemetnos de la lista
LinkedListNode<string> primeraCancion = cancionesLinkedList.First!;
LinkedListNode<string> ultimaCancion = cancionesLinkedList.Last!;

Console.WriteLine($"La primera cancion : {primeraCancion}, ultima cancion: {ultimaCancion}");