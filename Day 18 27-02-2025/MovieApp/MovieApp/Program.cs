using System;
using MovieApp.Model;
using MovieApp.Services;

internal class Program
{   


    private static void Main(string[] args)
    {

       MovieStore store = new MovieStore();
        store.ShowMenu();


    }
}