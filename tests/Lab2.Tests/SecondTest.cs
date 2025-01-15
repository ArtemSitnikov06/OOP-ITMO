using Itmo.ObjectOrientedProgramming.Lab2;
using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entity;

using Xunit;

namespace Lab2.Tests;

public class SecondTest
{
    [Fact]

    public void Scenario1()
    {
        var author = new User(20, "Artem");
        var labBuilder = new LaboratoryWorkBuilder();
        LaboratoryWork lab1 = labBuilder
            .SetAuthor(author)
            .SetDescription("Nice lab")
            .SetName("lab-1")
            .SetPointCriteria("Top criteria")
            .SetId(29)
            .SetPoints(100)
            .Build();

        LaboratoryWork lab2 = lab1.Clone();
        Assert.True(lab1.Id == lab2.BaseLabWorkID);
    }

    [Fact]
    public void Scenario2()
    {
        var author = new User(22, "Artem");
        var matBuilder = new LectureMaterialsBuilder();
        LectureMaterials mat1 = matBuilder
            .SetAuthor(author)
            .SetDescription("Nice material")
            .SetName("mat-1")
            .SetId(29)
            .SetContent("Top Content")
            .Build();

        LectureMaterials mat2 = mat1.Clone();
        Assert.True(mat1.Id == mat2.BaseLectureMaterialId);
    }

    [Fact]
    public void Scenario3()
    {
        var author = new User(20, "Artem");
        var labBuilder = new LaboratoryWorkBuilder();
        LaboratoryWork lab1 = labBuilder
            .SetAuthor(author)
            .SetDescription("Nice lab")
            .SetName("lab-1")
            .SetPointCriteria("Top criteria")
            .SetId(29)
            .SetPoints(100)
            .Build();

        var matBuilder = new LectureMaterialsBuilder();
        LectureMaterials mat1 = matBuilder
            .SetAuthor(author)
            .SetDescription("Nice material")
            .SetName("mat-1")
            .SetId(26)
            .SetContent("Top Content")
            .Build();

        var subjectBuider = new SubjectBuilder();
        Subject sub1 = subjectBuider
            .SetAuthor(author)
            .SetName("Math")
            .SetTypePassFail()
            .SetPassFailPoints(20)
            .SetId(30)
            .SetLabWorks(new List<LaboratoryWork> { lab1 })
            .SetLectureMaterials(new List<LectureMaterials> { mat1 })
            .Build();

        Subject sub2 = sub1.Clone();

        Assert.True(sub1.Id == sub2.BaseSubjectId);
    }
}