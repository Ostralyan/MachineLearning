namespace MachineLearning

open MathNet.Numerics.LinearAlgebra

module LinearRegression =
    
    let computeCost (X : Matrix<double>) (y : Vector<double>) (theta : Vector<double>) =
        let m = y.Count |> double
        let J = (1.0/(2.0*m)) * (((X*theta - y) |> Vector.map (fun x -> x*x)) |> Vector.sum)
        J
