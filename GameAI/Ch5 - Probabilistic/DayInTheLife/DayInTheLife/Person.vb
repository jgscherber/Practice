Imports DayInTheLife

Public MustInherit Class Person ' must inherit ensures that this is alway an abstract class (can't be instantiated by itself)
    Public Function Pick(Cash As Double, Occupations As Collection) As Job ' picks a job and then returns which one it did
        Dim bestJob As Job = CType(Occupations(1), Job)
        Dim bestValue As Double = Me.Evaluate(bestJob, Cash)

        Dim otherJob As Job
        Dim otherValue As Double
        For Each otherJob In Occupations
            If 2.0 * otherJob.Cost <= Cash Then
                otherValue = Me.Evaluate(otherJob, Cash)
                If otherValue > bestValue Then
                    bestJob = otherJob
                    bestValue = otherValue
                End If
            End If
        Next
        Return bestJob
    End Function

    Public MustOverride Function Evaluate(Task As Job, Cash As Double) As Double

End Class

Public Class Eddy ' not good to subclass these, would be better to type them and instatiate them as names (e.g. Eddy is of the BalancePerson type)
    Inherits Person

    Public Overrides Function Evaluate(Task As Job, Cash As Double) As Double
        Return Task.PSuccess * Task.PSuccess * Task.Gain _
            - (1 - Task.PSuccess) * Task.Loss
    End Function
End Class

Public Class Gary ' PotentialOnlyPerson
    Inherits Person

    Public Overrides Function Evaluate(Task As Job, Cash As Double) As Double
        Return Task.Gain
    End Function
End Class

Public Class Mike ' CostWorriesPerson
    Inherits Person

    Public Overrides Function Evaluate(Task As Job, Cash As Double) As Double
        Return -Task.Cost
    End Function
End Class

Public Class Carl ' EasyMoneyPerson
    Inherits Person

    Public Overrides Function Evaluate(Task As Job, Cash As Double) As Double
        Return Task.PSuccess * Task.Gain
    End Function
End Class

Public Class Larry ' BigTimePerson
    Inherits Person

    Public Overrides Function Evaluate(Task As Job, Cash As Double) As Double
        Return Task.PSuccess * Task.Gain - (1 - Task.PSuccess) * Task.Loss
    End Function
End Class

Public Class Barry ' BolderBalancePerson
    Inherits Person

    Public Overrides Function Evaluate(Task As Job, Cash As Double) As Double
        Return Task.PSuccess * Task.PSuccess * Task.Gain - (1 - Task.PSuccess) _
            * (1 - Task.PSuccess) * Task.Loss
    End Function
End Class














