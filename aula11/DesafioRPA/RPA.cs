using System;
using System.IO;
using System.Linq;
using DesafioRPA.Model;
using System.Threading.Tasks;
using System.Management.Automation;
using Microsoft.EntityFrameworkCore;

using static System.Console;

public class RPA
{
    API api = new API();
    public async Task Run()
    {
        while (true)
        {
            Clear();
            WriteLine("RPA - Controle de Repositórios");

            var comm = ReadLine();

            switch (comm.ToLower())
            {
                case "add watch":
                    await addWatch();
                    goto default;
                case "inspect":
                    await inspectInput();
                    goto default;
                // case "update all":
                //     await pull();
                //     goto default;
                default:
                    ReadKey(true);
                    break;
            }


        }
    }

    private async Task addWatch()
    {
        Write("Insira o caminho:");
        var path = ReadLine();

        Write("Insira a tag de identificação:");
        var tag = ReadLine();

        var wd = new WatchDirectory() { Dpath = path, Tag = tag };

        if (!Directory.Exists(path))
        {
            Write("Caminho inválido");
            return;
        }

        if (api.WatchDirectoryExists(wd))
        {
            Write("Caminho já cadastrado");
            return;
        }

        await api.CreateWatchDirectory(wd);
        WriteLine("Caminho adicionado com sucesso");

        await inspect(wd);
    }

    private async Task inspectInput()
    {
        Write("Digite a tag que deseja inspecionar: ");
        var tag = ReadLine();

        WatchDirectory wd = null;

        try
        {
            wd = await api.FindByTag(tag);
        }
        catch
        {
            Write("Tag não encontrada");
            return;
        }
        await inspect(wd);
    }

    private async Task inspect(WatchDirectory wd)
    {
        var ls = Directory.EnumerateDirectories(wd.Dpath);

        foreach (var dir in ls)
        {
            if (Directory.EnumerateFileSystemEntries(dir).Count(d => d.Contains(".git")) == 1)
            {

                GitDirectory gd = new GitDirectory();
                gd.Dpath = dir;
                gd.ParentDirectory = wd.Tag;

                if (await api.GitDirectoryExists(gd))
                    continue;

                await api.CreateGitDirectory(gd);
                WriteLine("Repositório encontrado e adicionado: " + dir);
            }
        }
    }

    private async Task updateRepositories()
    {
        Write("Digite a tag do diretório: ");
        var tag = ReadLine();

        WatchDirectory wd;
        try
        {
            wd = await api.FindByTag(tag);
        }
        catch
        {
            Write("Tag não encontrada");
            return;
        }

        //TODO Add Get childs from api and foreach -> pull
    }

    private async Task pull(GitDirectory gd)
    {
        using var ps = PowerShell.Create();

        ps
            .AddCommand("cd")
            .AddParameter(gd.Dpath)
            .Invoke();

        ps.Commands.Clear();

        var main = ps
            .AddCommand("git")
            .AddArgument("branch")
            .Invoke().First().ToString().Split(" ").Last();

        ps.Commands.Clear();

        var remote = ps
            .AddCommand("git")
            .AddArgument("remote")
            .Invoke().First().ToString();

        ps.Commands.Clear();

        var result = ps
            .AddCommand("git")
            .AddArgument("pull")
            .AddParameter(remote)
            .AddParameter(main)
            .Invoke();

        if (!result.Last().ToString().Contains("file changed"))
            return;

        await api.UpdateGitLastPull(gd.Id, DateTime.Now);
    }

}

public class API
{
    private RpaCsharpContext context = new RpaCsharpContext();

    public bool WatchDirectoryExists(WatchDirectory w)
        => context.WatchDirectories.Count(d => d.Dpath == w.Dpath || d.Tag == w.Tag) > 0;

    public async Task<bool> GitDirectoryExists(GitDirectory d)
    {
        var table = await context.GitDirectories.ToListAsync();
        return table.Count(gd => gd.Dpath == d.Dpath) > 0;
    }

    public async Task CreateWatchDirectory(WatchDirectory wd)
    {
        context.WatchDirectories.Add(wd);

        await context.SaveChangesAsync();
    }

    public async Task<WatchDirectory> FindByTag(string tag)
    {
        var query = await context.WatchDirectories.FindAsync(tag);

        if (query is null)
            throw new ArgumentException("Tag inexistente");

        return query;
    }

    public async Task CreateGitDirectory(GitDirectory gd)
    {
        context.GitDirectories.Add(gd);
        await context.SaveChangesAsync();
    }

    public async Task UpdateGitLastPull(int id, DateTime lastPull)
    {
        var updated = await context.GitDirectories.FindAsync(id);
        updated.LastPull = lastPull;
        await context.SaveChangesAsync();
    }

}