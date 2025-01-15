using Itmo.ObjectOrientedProgramming.Lab2;
using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Results;
using Xunit;

namespace Lab2.Tests;

public class ThirdTest
{
    [Fact]
    public void Scenario1()
    {
        var labBuilder = new LaboratoryWorkBuilder();
        LaboratoryWork lab2 = labBuilder
            .SetAuthor(new User(25, "John"))
            .SetDescription("fantastic")
            .SetPointCriteria("Automat 5")
            .SetPoints(80)
            .SetId(1001)
            .SetName("lab-2")
            .Build();

        var matBuilder = new LectureMaterialsBuilder();
        LectureMaterials lecMat1 = matBuilder
            .SetAuthor(new User(29, "Artem"))
            .SetDescription("fantastic")
            .SetContent("cool content")
            .SetName("Lecture material 1")
            .SetId(90)
            .Build();

        var checkPoints = new CheckValidPoints();

        var subjectBuilder = new SubjectBuilder();
        Subject sub1 = subjectBuilder
            .SetAuthor(new User(30, "Cool guy"))
            .SetId(25)
            .SetName("Linal")
            .SetTypeExam()
            .SetExamPoints(99)
            .SetLabWorks([lab2])
            .SetLectureMaterials([lecMat1])
            .Build();
        ICheckPointResult check = checkPoints.CheckPoints(sub1.LaboratoryWorks);

        Assert.False(check.Succes, check.GetResultMessage());
    }
}