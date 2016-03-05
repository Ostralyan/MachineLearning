// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

namespace MachineLearning

open FSharp.Charting
open System
open System.Drawing
open System.Windows
open MathNet.Numerics.LinearAlgebra
open MachineLearning.Data

module program =

    [<EntryPoint>]
    let main argv = 

        let loadWithPath = load "C:\Users\lukec\OneDrive\Documents\Visual Studio 2015\Projects\MachineLearning"
        let data = loadWithPath "ex1data1.txt"
        let matrixData = data |> matrix
        let chartData = data |> toChartTuple

        let X = matrixData.Column(0)
        let y = matrixData.Column(1)

        let f = (Chart.Point(chartData, Name="Population vs Profit").WithXAxis(Max=24.0, Min=4.0)).ShowChart()

        System.Windows.Forms.Application.Run(f)
        0 // return an integer exit code