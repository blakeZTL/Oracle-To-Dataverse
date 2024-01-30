using Microsoft.Xrm.Sdk;
using Dataverse;

namespace DataverseTests;
[TestFixture]
public class CreateEntityTests
{
    [Test]
    public void TestCreateEntity_ValidInput_CorrectEntityCreated()
    {
        // Arrange
        string locid = "test_locid";
        string yyyymmdd = "20220101";
        string total = "100";

        // Act
        Entity result = CenterDay.CreateEntity(locid, yyyymmdd, total);
        Assert.Multiple(() =>
        {
            // Assert
            Assert.That(result["crff9_locid"], Is.EqualTo(locid));
            Assert.That(result["crff9_yyyymmdd"], Is.EqualTo(yyyymmdd));
            Assert.That(result["crff9_total"], Is.EqualTo(total));
            Assert.That(result["crff9_date"], Is.EqualTo(new DateTime(2022, 1, 1)));
        });
    }


    [Test]
    public void TestCreateEntity_InvalidDate_ThrowsException()
    {
        // Arrange
        string locid = "test_locid";
        string yyyymmdd = "20221301"; // Invalid month
        string total = "100";

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => CenterDay.CreateEntity(locid, yyyymmdd, total));
    }
}