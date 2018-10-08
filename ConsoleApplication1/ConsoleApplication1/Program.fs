// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
module mainmodule
[<EntryPoint>]
let main argv = 
    printf("Type problem number to run\n")
    let problem = System.Console.ReadLine() |> int
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    let ans = ProjectEuler001_100.loadProblem001To100(problem)
    stopWatch.Stop()
    printfn "%f" stopWatch.Elapsed.TotalMilliseconds
    printfn "%i" ans
    printf("Press Any Key to Continue\n")
    System.Console.ReadKey() |> ignore
    0 // return an integer exit code