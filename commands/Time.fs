namespace Commands

open Spectre.Console.Cli
open SpectreCoff

type Time() =
    inherit Command<Settings.LocationSettings>()
    interface ICommandLimiter<Settings.LocationSettings>

    override _.Execute(_context, settings) = 
        Many [
            C $"The time in {settings.city} is "; 
            P "still unknown."
        ] |> toConsole
        0