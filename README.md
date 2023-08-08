# What is the ... ?
A typical start of a question. This CLI answers some basic ones, right from your console.

## What is the current time in Helsinki?
To find that out, type in 

```PS
wit time --in Helsinki
```

This command uses the time zones provided by the [IANA time zone database](https://en.wikipedia.org/wiki/Internet_Assigned_Numbers_Authority#Time_zone_database). In case the parameter passed in for the location is not part of that set, the user will be prompted to select an area/city directly.

The time is then obtained from [TimeAPI](https://timeapi.io/).

## What is the weather like in Toronto?

WIP connecting to the _openweatherapi_.


## Feedback and Contributing
All feedback welcome!
All contributions are welcome!
