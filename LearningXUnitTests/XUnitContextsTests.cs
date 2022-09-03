using IAMExample;
using Xunit.Abstractions;

namespace UsersExampleTests
{

    // Constructor Setup + Dispose

    public class XUnitContextsTests_CtorSetup : IDisposable
    {
        private readonly GuidGenerator _guidGenerator;
        private readonly ITestOutputHelper _output;

        public XUnitContextsTests_CtorSetup(ITestOutputHelper output)
        {
            _guidGenerator = new GuidGenerator();
            _output = output;
        }

        [Fact]
        public void GuidGenerator_Test1()
        {
            var guid = _guidGenerator.FixedGuid;
            _output.WriteLine($"Guid = {guid}");
        }

        [Fact]
        public void GuidGenerator_Test2()
        {
            var guid = _guidGenerator.FixedGuid;
            _output.WriteLine($"Guid = {guid}");
        }

        public void Dispose()
        {
            _output.WriteLine("Disposing...");
            _guidGenerator.Dispose();
            _output.WriteLine("Disposed!");
        }
    }



    // Class Fixture

    public class XUnitContextsTests_ClassFixture1 : IClassFixture<GuidGenerator>
    {
        private readonly GuidGenerator _guidGenerator;
        private readonly ITestOutputHelper _output;

        public XUnitContextsTests_ClassFixture1(ITestOutputHelper output, GuidGenerator guidGenerator)
        {
            _output = output;
            _guidGenerator = guidGenerator;
        }

        [Fact]
        public void GuidGenerator_Test1()
        {
            var guid = _guidGenerator.FixedGuid;
            _output.WriteLine($"Guid = {guid}");
        }

        [Fact]
        public void GuidGenerator_Test2()
        {
            var guid = _guidGenerator.FixedGuid;
            _output.WriteLine($"Guid = {guid}");
        }
    }

    public class XUnitContextsTests_ClassFixture2 : IClassFixture<GuidGenerator>
    {
        private readonly GuidGenerator _guidGenerator;
        private readonly ITestOutputHelper _output;

        public XUnitContextsTests_ClassFixture2(ITestOutputHelper output, GuidGenerator guidGenerator)
        {
            _output = output;
            _guidGenerator = guidGenerator;
        }

        [Fact]
        public void GuidGenerator_Test1()
        {
            var guid = _guidGenerator.FixedGuid;
            _output.WriteLine($"Guid = {guid}");
        }

        [Fact]
        public void GuidGenerator_Test2()
        {
            var guid = _guidGenerator.FixedGuid;
            _output.WriteLine($"Guid = {guid}");
        }
    }



    // Collections


    [CollectionDefinition(nameof(GuidGeneratorCollectionDefinition))]
    public class GuidGeneratorCollectionDefinition : ICollectionFixture<GuidGenerator>
    {
    }

    [Collection(nameof(GuidGeneratorCollectionDefinition))]
    public class XUnitContextsTests_Collection1
    {
        private readonly GuidGenerator _guidGenerator;
        private readonly ITestOutputHelper _output;

        public XUnitContextsTests_Collection1(ITestOutputHelper output, GuidGenerator guidGenerator)
        {
            _output = output;
            _guidGenerator = guidGenerator;
        }

        [Fact]
        public void GuidGenerator_Test1()
        {
            var guid = _guidGenerator.FixedGuid;
            _output.WriteLine($"Guid = {guid}");
        }

        [Fact]
        public void GuidGenerator_Test2()
        {
            var guid = _guidGenerator.FixedGuid;
            _output.WriteLine($"Guid = {guid}");
        }
    }

    [Collection(nameof(GuidGeneratorCollectionDefinitiion))]
    public class XUnitContextsTests_Collection2
    {
        private readonly GuidGenerator _guidGenerator;
        private readonly ITestOutputHelper _output;

        public XUnitContextsTests_Collection2(ITestOutputHelper output, GuidGenerator guidGenerator)
        {
            _output = output;
            _guidGenerator = guidGenerator;
        }

        [Fact]
        public void GuidGenerator_Test1()
        {
            var guid = _guidGenerator.FixedGuid;
            _output.WriteLine($"Guid = {guid}");
        }

        [Fact]
        public void GuidGenerator_Test2()
        {
            var guid = _guidGenerator.FixedGuid;
            _output.WriteLine($"Guid = {guid}");
        }
    }
}
