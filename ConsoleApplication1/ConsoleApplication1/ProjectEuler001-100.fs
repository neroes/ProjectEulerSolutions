module ProjectEuler001_100
open System.Collections.Generic
open EulerProjectTools
open ProjectEulerHelperClasses
open System


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
let Problem004 = // needs to be made recursive to be modifiable for different sizes
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
    let primefactorcounts = [| for i in 1..highestnum -> 0|]
    for i in 1..highestnum do
        let primefactors = GetPrimeFactor(i|>int64)
        let count = CountNumbers(primefactors,i)
        for j in 0..i-1 do
            if (primefactorcounts.[j] < count.[j]) then
                primefactorcounts.[j] <- count.[j]
    let mutable res = 1L
    for i in 0..highestnum-1 do
        for j in 1..primefactorcounts.[i] do
            res <- res*(i+1|>int64)
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
let Problem009 (fullnumber:int) =
    let mutable found = false
    let mutable res = 0L
    seq {fullnumber/3..-1..1} |> Seq.tryFind (fun a ->
        let b = fullnumber*(a-fullnumber/2)/(a-fullnumber)
        let c = sqrt((pown(a) 2+pown(b) 2)|>double)|>int
        if ((a+b+c)=fullnumber) then
            found <- true
            res <- (a*b*c)|>int64
        found)|>ignore
    res
let Problem010 maxprimesize =
    let mutable primes:LinkedList<int64> = new LinkedList<int64>()
    let mutable nextPrime:int64 = 2L
    let mutable sum:int64 = 0L
    while nextPrime<maxprimesize do
        primes.AddLast(nextPrime) |> ignore
        sum <- sum + nextPrime
        nextPrime <- getNextPrime(primes)
    sum 
let Problem011 (numberset:int list list, numbers) =
    let mutable res = 0L
    for i in 0..numberset.[0].Length - 1 do //rows
        for j in 0.. numberset.Length - numbers - 1 do
            let prod = arrayProduct(numberset.[i].[j..j+numbers])
            if (prod>res) then
                res <- prod|>int64
    for j in 0..numberset.Length - 1 do //collums
        for i in 0..numberset.[0].Length - numbers - 1 do
            let prod = arrayProduct(numberset.[i..i+numbers].[j])
            if (prod>res) then
                res <- prod|>int64
    //for i in 0..numberset.[0].Length - 1 do //diagonal part1
        //let row = seq {0..numberset.Length-1-i} |> Seq.collect (fun a -> numberset.[a].[a])
        //for j in 0..row.Length - numbers - 1 do
            //let prod = arrayProduct(row.[j..j+numbers])
            //if (prod>res) then
                //res <- prod|>int64
    //for i in 1..numberset.Length - 1 do //diagonal part2
        
    res
let Problem088 amount = // make it only look at prime numbers instead of brute forcing
    let mutable target = 2L
    let mutable lasttarget = 2L
    let mutable res = 0L
    let mutable i = 2L
    while (i < amount) do
        while (not (Problem88Helper([],target, i, 1L))) do
            target <- target + 1L
        if (target <> lasttarget) then
            res <- res + target
        let tmpi = (ProductSumNumber.lookup.[target].Expander().Count |>int64) + 1L
        if (tmpi > i) then
            i <- tmpi
        else
            i <- i + 1L
        lasttarget <- target
    res
let loadProblem001To100 (index:int) = 
    let grid = [[ 08; 02; 22; 97; 38; 15; 00; 40; 00; 75; 04; 05; 07; 78; 52; 12; 50; 77; 91; 08 ];
                [ 49; 49; 99; 40; 17; 81; 18; 57; 60; 87; 17; 40; 98; 43; 69; 48; 04; 56; 62; 00 ];
                [ 81; 49; 31; 73; 55; 79; 14; 29; 93; 71; 40; 67; 53; 88; 30; 03; 49; 13; 36; 65 ];
                [ 52; 70; 95; 23; 04; 60; 11; 42; 69; 24; 68; 56; 01; 32; 56; 71; 37; 02; 36; 91 ];
                [ 22; 31; 16; 71; 51; 67; 63; 89; 41; 92; 36; 54; 22; 40; 40; 28; 66; 33; 13; 80 ];
                [ 24; 47; 32; 60; 99; 03; 45; 02; 44; 75; 33; 53; 78; 36; 84; 20; 35; 17; 12; 50 ];
                [ 32; 98; 81; 28; 64; 23; 67; 10; 26; 38; 40; 67; 59; 54; 70; 66; 18; 38; 64; 70 ];
                [ 67; 26; 20; 68; 02; 62; 12; 20; 95; 63; 94; 39; 63; 08; 40; 91; 66; 49; 94; 21 ];
                [ 24; 55; 58; 05; 66; 73; 99; 26; 97; 17; 78; 78; 96; 83; 14; 88; 34; 89; 63; 72 ];
                [ 21; 36; 23; 09; 75; 00; 76; 44; 20; 45; 35; 14; 00; 61; 33; 97; 34; 31; 33; 95 ];
                [ 78; 17; 53; 28; 22; 75; 31; 67; 15; 94; 03; 80; 04; 62; 16; 14; 09; 53; 56; 92 ];
                [ 16; 39; 05; 42; 96; 35; 31; 47; 55; 58; 88; 24; 00; 17; 54; 24; 36; 29; 85; 57 ];
                [ 86; 56; 00; 48; 35; 71; 89; 07; 05; 44; 44; 37; 44; 60; 21; 58; 51; 54; 17; 58 ];
                [ 19; 80; 81; 68; 05; 94; 47; 69; 28; 73; 92; 13; 86; 52; 17; 77; 04; 89; 55; 40 ];
                [ 04; 52; 08; 83; 97; 35; 99; 16; 07; 97; 57; 32; 16; 26; 26; 79; 33; 27; 98; 66 ];
                [ 88; 36; 68; 87; 57; 62; 20; 72; 03; 46; 33; 67; 46; 55; 12; 32; 63; 93; 53; 69 ];
                [ 04; 42; 16; 73; 38; 25; 39; 11; 24; 94; 72; 18; 08; 46; 29; 32; 40; 62; 76; 36 ];
                [ 20; 69; 36; 41; 72; 30; 23; 88; 34; 62; 99; 69; 82; 67; 59; 85; 74; 04; 36; 16 ];
                [ 20; 73; 35; 29; 78; 31; 90; 01; 74; 31; 49; 71; 48; 86; 81; 16; 23; 57; 05; 54 ];
                [ 01; 70; 54; 71; 83; 51; 54; 69; 16; 92; 33; 48; 61; 43; 52; 01; 89; 19; 67; 48 ]]
    match index with
    | 1 -> Problem001(1000,[3;5])
    | 2 -> Problem002(2,4000000)
    | 3 -> Problem003(600851475143L)
    | 4 -> Problem004
    | 5 -> Problem005(20)
    | 6 -> Problem006(100)
    | 7 -> Problem007(10001)
    | 8 -> Problem008("7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450",13)
    | 9 -> Problem009(1000)
    | 10 -> Problem010(2000000L)
    | 11 -> Problem011(grid,4)
    | 88 -> Problem088(12000L)
    | _ -> 0L