let items = [ 0.; 0.; 2.; 4.; 5.; 3.; 8.; 6.; 4. ]

let results =
    items |> List.windowed 3 |> List.map List.average

for result in results do
    System.Console.WriteLine $"The next value is {result}"
