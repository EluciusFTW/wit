namespace Commands.Settings

open Spectre.Console.Cli

type LocationSettings() as self =
    inherit CommandSettings()

    [<CommandOption("--in")>]
    member val city = "Leipzig" with get, set

    override _.Validate() =
        match self.city.Length with
        | 1 -> Spectre.Console.ValidationResult.Error($"That's an awfully short name for a place, ain't it?")
        | _ -> Spectre.Console.ValidationResult.Success()