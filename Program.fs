open Spectre.Console.Cli
open Commands

[<EntryPoint>]
let main argv =

    let app = CommandApp()
    app.Configure(fun config ->
        config.AddCommand<Weather>("weather")
            .WithAlias("w")
            .WithDescription("Gets the weather in a given location")
            |> ignore
            
        config.AddCommand<Time>("time")
            .WithAlias("t")
            .WithDescription("Gets the time in a given location")
            |> ignore)

    app.Run(argv)