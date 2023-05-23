using static System.Console;

Invoker app = new Invoker();
Clear();

while(true)
{
    WriteLine(app.Text);
    string command = ReadLine();
    app.UseCommand(command);
    Clear();
}