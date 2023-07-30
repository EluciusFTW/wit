namespace Commands

open Spectre.Console.Cli

type WeatherSettings() as self =
    inherit CommandSettings()

    [<CommandOption("--in")>]
    member val city = "Leipzig" with get, set

    override _.Validate() =
        match self.city.Length with
        | 1 -> Spectre.Console.ValidationResult.Error($"That's an awfully short name for a place, ain't it?")
        | _ -> Spectre.Console.ValidationResult.Success()

type Weather() =
    inherit Command<WeatherSettings>()
    interface ICommandLimiter<WeatherSettings>

    override _.Execute(_context, settings) = 
        0