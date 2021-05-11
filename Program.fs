open Spectre.Console

let items = [ 0.; 0.; 2.; 4.; 5.; 3.; 8.; 6.; 4. ]

let results =
    items
    |> List.windowed 3
    |> List.map (fun numbers -> Seq.last numbers, List.average numbers)

let table =
    Table()
        .AddColumns("Value", "Simple Moving Average")

for value, average in results do
    table.AddRow(value.ToString(), average.ToString "F2")
    |> ignore

AnsiConsole.Render table
