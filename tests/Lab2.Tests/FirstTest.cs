using Itmo.ObjectOrientedProgramming.Lab2;
using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Results;
using Itmo.ObjectOrientedProgramming.Lab2.Update;
using Xunit;

namespace Lab2.Tests;

public class FirstTest
{
        [Fact]
        public void Scenario1()
        {
            var author1 = new User(1, "User 1");
            var author2 = new User(2, "User 2");

            var labBuilder = new LaboratoryWorkBuilder();
            LaboratoryWork lab1 = labBuilder
                .SetId(1)
                .SetName("Lab 1")
                .SetAuthor(author1)
                .SetPoints(100)
                .SetDescription("cool lab")
                .SetPointCriteria("all 5")
                .Build();

            LaboratoryWork lab2 = lab1.Clone();

            var labUpdater = new UpdateLaboratoryWork(lab2);
            IChangeResult check = labUpdater.CanUpdate(author2);
            labUpdater.UpdateName("lab-2", check);

            Assert.True(lab2.Name == lab1.Name);
            Assert.False(check.IsValid, check.GetResultMessage());
        }

        [Fact]
        public void Scenario2()
        {
            var author1 = new User(1, "User 1");
            var author2 = new User(2, "User 2");

            var matBuilder = new LectureMaterialsBuilder();
            LectureMaterials material1 = matBuilder
                .SetId(10)
                .SetName("mat-1")
                .SetDescription("Cool material")
                .SetAuthor(author1)
                .SetContent("Incrediable content")
                .Build();

            LectureMaterials material2 = material1.Clone();

            var materialUpdater = new UpdateLectureMaterials(material2);

            IChangeResult check = materialUpdater.CanUpdate(author2);

            materialUpdater.UpdateDescription("New incredible content", check);

            Assert.True(material1.Description == material2.Description);
            Assert.False(check.IsValid, check.GetResultMessage());
        }

        [Fact]

        public void Scenario3()
        {
            var author1 = new User(1, "User 1");
            var author2 = new User(2, "User 2");

            var labBuilder = new LaboratoryWorkBuilder();
            LaboratoryWork lab1 = labBuilder
                .SetId(90)
                .SetName("lab-1")
                .SetDescription("interesting")
                .SetAuthor(author2)
                .SetPointCriteria("COOL")
                .SetPoints(100)
                .Build();

            var matBuilder = new LectureMaterialsBuilder();
            LectureMaterials material1 = matBuilder
                .SetId(10)
                .SetName("mat-1")
                .SetDescription("Cool material")
                .SetAuthor(author1)
                .SetContent("Incrediable content")
                .Build();

            var subjectBuilder = new SubjectBuilder();
            Subject sub1 = subjectBuilder
                .SetId(100)
                .SetName("OOP")
                .SetTypeExam()
                .SetExamPoints(80)
                .SetAuthor(author1)
                .SetLabWorks(new List<LaboratoryWork> { lab1 })
                .SetLectureMaterials(new List<LectureMaterials> { material1 })
                .Build();

            Subject sub2 = sub1.Clone();

            var subjectUpdater = new UpdateSubject(sub1);
            IChangeResult check = subjectUpdater.CanUpdate(author2);
            subjectUpdater.AddLecureMaterials(material1, check);

            Assert.True(sub1.Name == sub2.Name);
            Assert.False(check.IsValid, check.GetResultMessage());
        }
}