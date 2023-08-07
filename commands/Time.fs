namespace Commands

open Spectre.Console.Cli

type TimeSettings() as self =
    inherit CommandSettings()

    [<CommandOption("--in")>]
    member val city = "Leipzig" with get, set

    override _.Validate() =
        match self.city.Length with
        | 1 -> Spectre.Console.ValidationResult.Error($"That's an awfully short name for a place, ain't it?")
        | _ -> Spectre.Console.ValidationResult.Success()

open SpectreCoff
type Time() =
    inherit Command<TimeSettings>()
    interface ICommandLimiter<TimeSettings>

    override _.Execute(_context, settings) = 
        Many [
            C $"The time in {settings.city} is "; P "still unknown."
        ] |> toConsole
        0