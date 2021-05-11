open Spectre.Console
open Argu

type Arguments =
    | [<Mandatory>] Inputs of float list
    | K of int
    interface IArgParserTemplate with
        member this.Usage =
            match this with
            | Inputs _ -> "input set of data."
            | K _ -> "size of the window."

[<EntryPoint>]
let main argv =
    let items, k =
        let results =
            ArgumentParser
                .Create<Arguments>()
                .ParseCommandLine argv

        results.GetResult Inputs, results.GetResult(K, 3)

    let results =
        items
        |> List.windowed k
        |> List.map (fun numbers -> Seq.last numbers, List.average numbers)

    let table =
        Table()
            .AddColumns("Value", "Simple Moving Average")

    for value, average in results do
        table.AddRow(value.ToString(), average.ToString "F2")
        |> ignore

    AnsiConsole.Render table |> ignore

    0
