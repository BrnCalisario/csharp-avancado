using System;

var teste = Singleton.Current;

var teste2 = Singleton.Current;

public class Singleton
{   
    private Singleton() {}

    private Singleton(string text)
        => this.Texto = text;

    private static Singleton crr = new Singleton();

    public static Singleton Current => crr;
    
    public string Texto { get; set; }
    public string OutroTexto { get; set; }

    public void Method()
        => Console.WriteLine($"{Texto} = {OutroTexto}");

    public static void New()
        => crr = new Singleton();
z
    public static void New(string text)
        => crr = new Singleton(text);
}