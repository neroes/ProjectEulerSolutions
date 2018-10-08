﻿module EulerProjectTools

open System.Collections.Generic
open System

let inline arrayProduct (a:seq<int>) = 
    let mutable product = 1L
    for i in a do
        product <- product * (i |> int64)
    product
let getNextPrime (primes:LinkedList<int64>) =
    let mutable dontbreak = true
    let mutable i = 2L
    if (primes.Count>0) then
        i <- primes.Last.Value
    else
        dontbreak <- false
    while (dontbreak) do
        let mutable isprime = true
        i <- i + 1L
        let mutable dontbreak2 = true
        let mutable enum = primes.GetEnumerator()
        enum.MoveNext() |> ignore
        while (dontbreak2) do
            if (i%enum.Current = 0L) then
                dontbreak2 <- false
                isprime <- false
            else 
                enum.MoveNext() |> ignore
            if (float(enum.Current)>sqrt(float(i))) then
                dontbreak2 <- false
        //for prime in primes do
          //  if (i%prime = 0L) then
            //    isprime <- false
        if isprime then
            dontbreak <- false
    i
let GetPrimeFactor (largenumber:int64) =
    let mutable remsum:int64 = largenumber
    let mutable primefactors:list<int64> = []
    let mutable dontbreak = true
    let mutable res = 0L
    let mutable primes:LinkedList<int64> = new LinkedList<int64>()
    while dontbreak do
        primes.AddLast(getNextPrime(primes)) |> ignore
        
        while (remsum%primes.Last.Value = 0L) do
            remsum <- remsum/primes.Last.Value
            primefactors <- [primes.Last.Value] @ primefactors
        if (remsum < primes.Last.Value) then dontbreak <- false
    primefactors

let rec FindMultiplicatesHelper (currentmulti:int64,primes,max:int64,combinations:LinkedList<int64>) = 
    let mutable combinations2 = combinations
    if (currentmulti < max) then
        combinations.AddLast(currentmulti) |> ignore
        for prime in primes do
            combinations2 <- FindMultiplicatesHelper(currentmulti*prime,primes,max,combinations2)
    combinations2
let FindMultiplicates (primes,max:int64) =
    let mutable currentmulti = 1L
    let mutable combinations:LinkedList<int64> = new LinkedList<int64>()
    FindMultiplicatesHelper(currentmulti,primes,max,combinations)