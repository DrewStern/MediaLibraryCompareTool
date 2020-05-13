﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MediaLibraryCompareTool.UnitTests
{
    [TestClass]
    public class MusicLibraryCompareResultTests
    {
        [TestMethod]
        public void GivenAnEmptyLibrary_WhenIntersectedWithAnotherEmptyLibrary_ThenResultIsAnEmptyLibrary()
        {
            var l1 = new MusicLibrary(new List<MusicLibraryItem>());
            var l2 = new MusicLibrary(new List<MusicLibraryItem>());
            var ld = new MusicLibraryCompareResult(l1, l2);

            var expected = new MusicLibrary(new List<MusicLibraryItem>());
            var actual = ld.Intersection;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenALibrary_WhenIntersectedWithAProperSubsetOfItself_ThenResultIsTheSameProperSubset()
        {
            var l1 = new MusicLibrary(new List<MusicLibraryItem>
            {
                new MusicLibraryItem("artistName1", "releaseName1"),
                new MusicLibraryItem("artistName2", "releaseName2"),
                new MusicLibraryItem("artistName3", "releaseName3"),
            });
            var l2 = new MusicLibrary(new List<MusicLibraryItem>
            {
                new MusicLibraryItem("artistName1", "releaseName1"),
                new MusicLibraryItem("artistName2", "releaseName2"),
            });

            var ld = new MusicLibraryCompareResult(l1, l2);

            var expected = new MusicLibrary(new List<MusicLibraryItem>
            {
                new MusicLibraryItem("artistName1", "releaseName1"),
                new MusicLibraryItem("artistName2", "releaseName2"),
            });
            var actual = ld.Intersection;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenALibrary_WhenIntersectedWithAnImproperSupersetOfItself_ThenResultIsASubsetOfTheOriginalLibrary()
        {
            var l1 = new MusicLibrary(new List<MusicLibraryItem>
            {
                new MusicLibraryItem("artistName5", "releaseName5"),
                new MusicLibraryItem("artistName6", "releaseName6"),
            });
            var l2 = new MusicLibrary(new List<MusicLibraryItem>
            {
                new MusicLibraryItem("artistName4", "releaseName4"),
                new MusicLibraryItem("artistName5", "releaseName5"),
                new MusicLibraryItem("artistName7", "releaseName7"),
            });

            var ld = new MusicLibraryCompareResult(l1, l2);

            var expected = new MusicLibrary(new List<MusicLibraryItem>
            {
                new MusicLibraryItem("artistName5", "releaseName5"),
            });
            var actual = ld.Intersection;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenALibrary_WhenIntersectedWithAProperSupersetOfItself_ThenResultIsTheOriginalLibrary()
        {
            var l1 = new MusicLibrary(new List<MusicLibraryItem>
            {
                new MusicLibraryItem("artistName5", "releaseName5"),
                new MusicLibraryItem("artistName6", "releaseName6"),
            });
            var l2 = new MusicLibrary(new List<MusicLibraryItem>
            {
                new MusicLibraryItem("artistName4", "releaseName4"),
                new MusicLibraryItem("artistName5", "releaseName5"),
                new MusicLibraryItem("artistName6", "releaseName6"),
            });

            var ld = new MusicLibraryCompareResult(l1, l2);

            var expected = new MusicLibrary(new List<MusicLibraryItem>
            {
                new MusicLibraryItem("artistName5", "releaseName5"),
                new MusicLibraryItem("artistName6", "releaseName6"),
            });
            var actual = ld.Intersection;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenAnEmptyLibrary_WhenSummedWithAnotherEmptyLibrary_ThenTheResultIsAnEmptyLibrary()
        {
            var l1 = new MusicLibrary(new List<MusicLibraryItem>());
            var l2 = new MusicLibrary(new List<MusicLibraryItem>());
            var ld = new MusicLibraryCompareResult(l1, l2);

            var expected = new MusicLibrary(new List<MusicLibraryItem>());
            var actual = ld.Sum;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenALibrary_WhenLeftOutersectedWithAnImproperSubsetOfItself_ThenResultIsSubsetOfOriginalLibrary()
        {
            var l1 = new MusicLibrary(new List<MusicLibraryItem>
            {
                new MusicLibraryItem("artistName1", "releaseName1"),
                new MusicLibraryItem("artistName2", "releaseName2"),
                new MusicLibraryItem("artistName3", "releaseName3"),
            });
            var l2 = new MusicLibrary(new List<MusicLibraryItem>
            {
                new MusicLibraryItem("artistName3", "releaseName3"),
                new MusicLibraryItem("artistName4", "releaseName4"),
            });
            var ld = new MusicLibraryCompareResult(l1, l2);

            var expected = new MusicLibrary(new List<MusicLibraryItem>
            {
                new MusicLibraryItem("artistName1", "releaseName1"),
                new MusicLibraryItem("artistName2", "releaseName2"),
            });
            var actual = ld.LeftOutersection;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenALibrary_WhenRightOutersectedWithAnImproperSupersetOfItself_ThenResultIsSubsetOfThatImproperSuperset()
        {
            var l1 = new MusicLibrary(new List<MusicLibraryItem>
            {
                new MusicLibraryItem("artistName1", "releaseName1"),
                new MusicLibraryItem("artistName2", "releaseName2"),
            });
            var l2 = new MusicLibrary(new List<MusicLibraryItem>
            {
                new MusicLibraryItem("artistName2", "releaseName2"),
                new MusicLibraryItem("artistName3", "releaseName3"),
                new MusicLibraryItem("artistName4", "releaseName4"),
            });
            var ld = new MusicLibraryCompareResult(l1, l2);

            var expected = new MusicLibrary(new List<MusicLibraryItem>
            {
                new MusicLibraryItem("artistName3", "releaseName3"),
                new MusicLibraryItem("artistName4", "releaseName4"),
            });
            var actual = ld.RightOutersection;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenALibrary_WhenFullOutersectedWithSomeOtherLibrary_ThenTheResultContainsNoElementsFromTheIntersection()
        {
            var l1 = new MusicLibrary(new List<MusicLibraryItem>
            {
                new MusicLibraryItem("artistName1", "releaseName1"),
                new MusicLibraryItem("artistName2", "releaseName2"),
                new MusicLibraryItem("artistName3", "releaseName3"),
            });
            var l2 = new MusicLibrary(new List<MusicLibraryItem>
            {
                new MusicLibraryItem("artistName1", "releaseName1"),
                new MusicLibraryItem("artistName4", "releaseName4"),
            });
            var ld = new MusicLibraryCompareResult(l1, l2);

            var expected = new MusicLibrary(new List<MusicLibraryItem>
            {
                new MusicLibraryItem("artistName2", "releaseName2"),
                new MusicLibraryItem("artistName3", "releaseName3"),
                new MusicLibraryItem("artistName4", "releaseName4"),
            });
            var actual = ld.FullOutersection;

            Assert.AreEqual(expected, actual);
        }
    }
}
