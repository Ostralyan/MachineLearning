// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

namespace MachineLearning

open FSharp.Charting
open System
open System.Drawing
open System.Windows
open MathNet.Numerics.LinearAlgebra
open MachineLearning.Data
open MachineLearning.LinearRegression

module program =

    [<EntryPoint>]
    let main argv = 

        let loadWithPath = load "C:\Users\lukec\OneDrive\Documents\Visual Studio 2015\Projects\MachineLearning"
        let data = loadWithPath "ex1data1.txt"
        let matrixData = data |> matrix
        let chartData = data |> toChartTuple

        let y = matrixData.Column(1)
        let m = y.Count
        let X = addOnesColumn <| matrixData.Column(0).ToColumnMatrix()
        let theta = Vector<double>.Build.Dense(X.ColumnCount)

        let alpha = 0.01
        let num_iters = 1500

        let J = computeCost X y theta
        let new_theta, J_history = gradientDescent X y theta alpha num_iters
        //let hypothesis = [for i in X.Column(1) |> Vector.toList -> new_theta.[0] + new_theta.[1]*i]
        let hypothesis = [for i in 5.0 .. 25.0 -> (i,new_theta.[0] + new_theta.[1]*i)]


        let f = 
            Chart.Combine(
                [   Chart.Point(chartData, Name="Population vs Profit").WithXAxis(Max=24.0, Min=4.0)
                    Chart.Line(hypothesis)
                ]).ShowChart()
       
        let f = (Chart.Line(J_history)).ShowChart()

        System.Windows.Forms.Application.Run(f)
        0 // return an integer exit code