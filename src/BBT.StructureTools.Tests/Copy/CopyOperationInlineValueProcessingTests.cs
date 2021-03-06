﻿namespace BBT.StructureTools.Tests.Copy
{
    using System;
    using System.Collections.Generic;
    using BBT.StructureTools.Copy;
    using BBT.StructureTools.Copy.Helper;
    using BBT.StructureTools.Tests.TestTools;
    using FluentAssertions;
    using Ninject;
    using Xunit;

    public class CopyOperationInlineValueProcessingTests
    {
        private readonly ICopy<TestClass> testCandidate;

        public CopyOperationInlineValueProcessingTests()
        {
            var kernel = TestIocContainer.Initialize();

            kernel.Bind<ICopyRegistrations<TestClass>>().To<TestClassCopyRegistrations>();

            this.testCandidate = kernel.Get<ICopy<TestClass>>();
        }

        /// <summary>
        /// Tests ICopy.Copy.
        /// </summary>
        [Fact]
        public void MustExecuteInlineCopyProcessing()
        {
            // Arrange
            var source = new TestClass();
            var target = new TestClass();

            // Act
            this.testCandidate.Copy(source, target, new List<IBaseAdditionalProcessing>());

            // Assert
            target.TestGuid.Should().NotBe(Guid.Empty);
        }

        private class TestClass
        {
            public Guid TestGuid { get; set; } = Guid.Empty;
        }

        private class TestClassCopyRegistrations : ICopyRegistrations<TestClass>
        {
            public void DoRegistrations(ICopyHelperRegistration<TestClass> registrations)
            {
                registrations.Should().NotBeNull();

                registrations
                    .RegisterInlineValueProcessing(x => x.TestGuid, () => Guid.NewGuid());
            }
        }
    }
}