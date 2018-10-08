module ProjectEuler001_100
open System.Collections.Generic
open EulerProjectTools

let Problem001 (max:int,multipliers:list<int>) = 
    let mutable rotationsize = 1;
    let mutable rotation = []
    for i in multipliers do
        rotationsize <- i * rotationsize
    for i = 1 to rotationsize do
        let mutable j = 0
        let mutable dontbreak = true
        while (dontbreak) do
            if (i%multipliers.[j] = 0) then 
                rotation <- rotation @ [i]
                dontbreak <- false
            else 
                j <- j+1 
            if (j >= multipliers.Length) then 
                dontbreak <- false
    let mutable i = 0
    let mutable j = 0
    let mutable sum = 0
    while (i+rotation.[j] < max) do
        sum <- sum + i+rotation.[j]
        j <- j+1
        if j>=rotation.Length then
            j <- 0
            i <- i + rotationsize
    sum |> int64
let Problem002 (modulus:int,max:int) =
    let mutable a = 1
    let mutable b = 1
    let mutable c = 2
    let mutable sum = 0
    while (c < max) do
        if (c%modulus = 0) then 
            sum <- sum + c
        a <- b
        b <- c
        c <- a + b
    sum |> int64
let Problem003 (largenumber:int64) =
    let primefactors = EulerProjectTools.GetPrimeFactor(largenumber)
    primefactors.Head
let Problem004 =
    let pal (a,b,c) =
        a*100000+b*10000+c*1000+c*100+b*10+a*1|>int64
    let mutable found = false
    let mutable combinations:LinkedList<int64> = null
    let mutable res = 0L
    seq {9..-1..1} |> Seq.tryFind (fun a ->
        seq {9..-1..0} |> Seq.tryFind (fun b ->
            seq {9..-1..0} |> Seq.tryFind (fun c ->
                let pal = pal(a,b,c)
                let primefactors = EulerProjectTools.GetPrimeFactor(pal)
                combinations <- FindMultiplicates(primefactors,1000L)
                for comb in combinations do
                    if (combinations.Contains(pal/comb)) then
                        found <- true
                        res <- pal
                found)|> ignore
            found)|> ignore
        found)|> ignore
    res
let Problem005 highestnum =
    let res = 0L
    res
let Problem006 highestnum =
    let sumsq = (Array.sum([|for i in 1..highestnum -> i |])|> float)**2.0
    let sqsum = Array.sum([|for i in 1.0..(highestnum|>float) -> i**2.0 |])
    let res = round(sumsq - sqsum)|>int
    res |> int64
let Problem007 primenum = 
    let mutable primes:LinkedList<int64> = new LinkedList<int64>()
    for i in 1..primenum do
        primes.AddLast(EulerProjectTools.getNextPrime(primes)) |> ignore
    primes.Last.Value
let Problem008 (numberlist:string,numofmulti:int) =
    let intlist = [| for i in 1 .. numberlist.Length-1 -> (numberlist.[i] |> int) - ('0' |> int) |]
    let mutable maxsum = 0L
    for i in 0 .. intlist.Length-numofmulti do 
        let tmpsum = intlist.[i..i+numofmulti-1] |> EulerProjectTools.arrayProduct
        if (tmpsum>maxsum) then 
            maxsum <- tmpsum
    maxsum
let Problem010 maxprimesize =
    let mutable primes:LinkedList<int64> = new LinkedList<int64>()
    let mutable nextPrime:int64 = 2L
    let mutable sum:int64 = 0L
    while nextPrime<maxprimesize do
        primes.AddLast(nextPrime) |> ignore
        sum <- sum + nextPrime
        nextPrime <- getNextPrime(primes)
    sum 
let Problem088 amount =
    let mutable amountfound = 0
    let mutable prodSumNum:list<int64> = []
    let mutable i = 2L
    while (amountfound < amount) do
        if (true) then// needs better statement
            prodSumNum <- [i] @ prodSumNum
            amountfound <- amountfound + 1
    i <- i + 1L
    let res = 0L
    res
let loadProblem001To100 (index:int) = 
    match index with
    | 1 -> Problem001(1000,[3;5])
    | 2 -> Problem002(2,4000000)
    | 3 -> Problem003(600851475143L)
    | 4 -> Problem004
    | 5 -> Problem005(20)
    | 6 -> Problem006(100)
    | 7 -> Problem007(10001)
    | 8 -> Problem008("7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450",13)
    | 10 -> Problem010(2000000L)
    | _ -> 0L