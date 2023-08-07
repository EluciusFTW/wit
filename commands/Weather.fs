namespace Commands

open Spectre.Console.Cli
open SpectreCoff

type Weather() =
    inherit Command<Settings.LocationSettings>()
    interface ICommandLimiter<Settings.LocationSettings>

    override _.Execute(_context, settings) = 
        Many [
            C $"The weather in {settings.city} is "
            P "still unknown."
        ] |> toConsole
        0