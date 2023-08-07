namespace Commands

open Spectre.Console.Cli
open SpectreCoff
open FSharp.Data

module Time = 
    [<Literal>]
    let locationUrl = "http://worldtimeapi.org/api/timezone/Europe/Stockholm"
    [<Literal>]
    let baseUrl = "http://worldtimeapi.org/api/timezone"

    type LocationResponse = JsonProvider<baseUrl>
    type TimeResponse = JsonProvider<locationUrl>

type Time() =
    inherit Command<Settings.LocationSettings>()
    interface ICommandLimiter<Settings.LocationSettings>

    override _.Execute(_context, settings) = 

        let zones = Time.LocationResponse.Load(Time.baseUrl)
        let zone = 
            "Which location are you interested in?" 
            |> chooseFrom zones 
        
        let zoneTime = Time.TimeResponse.Load($"{Time.baseUrl}/{zone})")
        Many [  
            C $"The time in {zone} is "; 
            P $"{zoneTime.Unixtime}"
        ] |> toConsole
        0