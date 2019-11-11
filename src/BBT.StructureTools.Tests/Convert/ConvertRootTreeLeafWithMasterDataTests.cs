﻿namespace BBT.StructureTools.Tests.Convert
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BBT.StructureTools.Convert;
    using BBT.StructureTools.Copy;
    using BBT.StructureTools.Tests.Convert.Intention;
    using BBT.StructureTools.Tests.Convert.TestStructure;
    using BBT.StructureTools.Tests.Convert.TestStructure.Registration;
    using BBT.StructureTools.Tests.Convert.TestStructure.Source;
    using BBT.StructureTools.Tests.Convert.TestStructure.Target;
    using BBT.StructureTools.Tests.TestTools;
    using FluentAssertions;
    using Ninject;
    using Xunit;

    public class ConvertRootTreeLeafWithMasterDataTests
    {
        private readonly IConvert<Root, TargetRoot, ITestConvertIntention> testcandidate;

        public ConvertRootTreeLeafWithMasterDataTests()
        {
            var kernel = TestIoContainer.Initialize();

            kernel.Bind(typeof(ITemporalDataDescriptor<>)).To<TemporalDataDescriptor>();

            kernel.Bind<IConvertRegistrations<Root, TargetRoot, ITestConvertIntention>>().To<RootTargetRootConvertRegistrations>();

            kernel.Bind<IConvertRegistrations<Tree, TargetTree, ITestConvertIntention>>().To<TreeTargetTreeConvertRegistrations>();
            kernel.Bind<IConvertRegistrations<TreeMasterData, TargetTree, ITestConvertIntention>>().To<TreeMasterDataToTreeConvertRegistrations>();

            kernel.Bind<IConvertRegistrations<Leaf, TargetLeaf, ITestConvertIntention>>().To<LeafTargetLeafConvertRegistrations>();
            kernel.Bind<IConvertRegistrations<LeafMasterData, TargetLeaf, ITestConvertIntention>>().To<LeafMasterDataTargetLeafConvertRegistrations>();
            kernel.Bind<IConvertRegistrations<TemporalLeafMasterData, TargetLeaf, ITestConvertIntention>>().To<TemporalLeafMasterDataTemporalLeafDatconvertRegistrations>();

            kernel.Bind<ICopyRegistrations<ITemporalData>>().To<TemporalDatcopyRegistrations>();

            this.testcandidate = kernel.Get<IConvert<Root, TargetRoot, ITestConvertIntention>>();
        }

        [Fact]
        public void StructureFromRootToLeafIsConvertIntoTargetStructure()
        {
            // Arrange
            // Create objects
            var root = new Root();
            var tree = new Tree();
            var treemasterdata = new TreeMasterData();
            var leaf = new Leaf()
            {
                TemporalDataRefDate = new DateTime(1993, 10, 5),
            };
            var leafmasterdata = new LeafMasterData
            {
                IsDefault = true,
            };
            var leafmasterdata2 = new LeafMasterData();
            var temporalleafmasterdata = new TemporalLeafMasterData
            {
                Begin = new DateTime(1993, 10, 4),
                End = new DateTime(2019, 10, 29),
            };
            var temporalleafmasterdata2 = new TemporalLeafMasterData
            {
                Begin = new DateTime(1994, 10, 7),
                End = new DateTime(2019, 10, 3),
            };

            // Build object tree
            root.Tree = tree;
            tree.TreeMasterData = treemasterdata;
            tree.Root = root;
            tree.Leafs.Add(leaf);
            leaf.Tree = tree;
            leaf.LeafMasterData.Add(leafmasterdata);
            leaf.LeafMasterData.Add(leafmasterdata2);
            leaf.TemporalLeafMasterData.Add(temporalleafmasterdata);
            leaf.TemporalLeafMasterData.Add(temporalleafmasterdata2);

            // Add values to properties
            root.CreateStringForProperty(x => x.RootName);
            tree.CreateStringForProperty(x => x.TreeName);
            treemasterdata.CreateStringForProperty(x => x.TreeMasterDataName);
            leaf.CreateStringForProperty(x => x.LeafName);
            leafmasterdata.CreateStringForProperty(x => x.LeafMasterDataName);
            leafmasterdata2.CreateStringForProperty(x => x.LeafMasterDataName);

            // Act
            var target = new TargetRoot();
            this.testcandidate.Convert(root, target, new List<IBaseAdditionalProcessing>());

            // Assert
            // Find target objects
            var targetTree = target.TargetTree;
            var targetLeafs = targetTree.TargetLeafs;
            var targetLeaf = targetLeafs.Single();

            // Assert structure
            targetTree.OriginRoot.Should().BeSameAs(root);
            targetTree.TargetRoot.Should().BeSameAs(target);
            targetTree.OriginTree.Should().BeSameAs(tree);

            targetLeaf.TargetTree.Should().BeSameAs(targetTree);
            targetLeaf.OriginLeaf.Should().BeSameAs(leaf);

            // Assert property content
            target.TargetRootName.Should().BeEquivalentTo(root.RootName);

            targetTree.TreeName.Should().BeEquivalentTo(tree.TreeName);
            targetTree.TreeMasterDataName.Should().BeEquivalentTo(treemasterdata.TreeMasterDataName);

            targetLeaf.LeafMasterDataName.Should().BeEquivalentTo(leafmasterdata.LeafMasterDataName);
            targetLeaf.LeafName.Should().BeEquivalentTo(leaf.LeafName);
            targetLeaf.TemporalDataOriginId.Should().Be(temporalleafmasterdata.Id);
        }
    }
}