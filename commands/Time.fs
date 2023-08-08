namespace Commands

open Spectre.Console.Cli
open SpectreCoff
open FSharp.Data

module Time = 
    [<Literal>]
    let sampleUrl = "https://timeapi.io/api/Time/current/zone?timeZone=Europe/Amsterdam"
    let baseUrl = "https://timeapi.io/api/Time/current/zone"

    [<Literal>]
    let zonesUrl = "https://timeapi.io/api/TimeZone/AvailableTimeZones"
    
    type TimeResponse = JsonProvider<sampleUrl>
    type ZonesResponse = JsonProvider<zonesUrl>

type Time() =
    inherit Command<Settings.LocationSettings>()
    interface ICommandLimiter<Settings.LocationSettings>

    override _.Execute(_context, settings) = 

        let pairs = 
            Time.ZonesResponse.Load(Time.zonesUrl) 
            |> Array.map (fun z -> z.Split('/'))
            |> Array.filter (fun p -> p.Length > 1) 

        let assemble area city = $"{area}/{city}"

        let zone = 
            match (pairs |> Array.tryFind (fun p -> p.[1] = settings.city)) with
            | Some pair -> assemble pair.[0] pair.[1]
            | None -> 
                let area = 
                    let areas = 
                        pairs 
                        |> Array.map (fun p -> p.[0])
                        |> Array.distinct 
                    "The location you specified is not known. Which location are you interested in?" |> chooseFrom areas
                       
                let city = 
                    let cities = 
                        pairs 
                        |> Array.filter (fun p -> p.[0] = area)
                        |> Array.map (fun p -> p.[1])
                        |> Array.distinct
                    "The location you specified is not known. Which location are you interested in?" |> chooseFrom cities
                        
                assemble area city
        
        try
            let zoneTime = Time.TimeResponse.Load($"{Time.baseUrl}?timeZone={zone}")
            Many [  
                C $"The time in {zone} is"
                P $"{zoneTime.DateTime}"
            ] |> toConsole
        with ex -> 
            Many [
                C $"Error: {ex.Message}" 
            ] |> toConsole
        0