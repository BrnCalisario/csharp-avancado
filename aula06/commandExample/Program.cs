using static System.Console;

using Example.Invoke;


Invoker app = new Invoker();
Clear();

while(true)
{
    WriteLine(app.Text);
    string command = ReadLine();
    app.UseCommand(command);
    Clear();
}